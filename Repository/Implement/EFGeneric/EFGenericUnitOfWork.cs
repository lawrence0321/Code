using Common.Interface;
using Dapper;
using MySql.Data.MySqlClient;
using Repository.Enums;
using Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Repository.Implement
{
    /// <summary>
    /// 實作Entity Framework Unit Of Work的class
    /// </summary>
    internal class EFGenericUnitOfWork : IUnitOfWork
    {
        readonly IDBContext Context;
        private Hashtable _repositories;

        public string ConnectStr => Context.ConnectStr;

        public EFGenericUnitOfWork(string ConnectionString_, InitializerType Initializer_ = InitializerType.CreateDatabaseIfNotExists)
        {
            this.Context = new EFGenericDBContext(ConnectionString_, Initializer_);
        }

        public IEnumerable<T> UseDapper<T>(string Strsql_, DynamicParameters Parameter_)
        {
            using (MySqlConnection connection = new MySqlConnection(Context.ConnectStr))
            {
                return connection.Query<T>(Strsql_, Parameter_);
            }
        }

        public IEnumerable<T> UseDapper<T>(string Strsql_)
        {
            using (MySqlConnection connection = new MySqlConnection(Context.ConnectStr))
            {
                return connection.Query<T>(Strsql_);
            }
        }

        public IEnumerable<dynamic> UseDapper(string Strsql_, DynamicParameters Parameter_)
        {
            using (MySqlConnection connection = new MySqlConnection(Context.ConnectStr))
            {
                return connection.Query(Strsql_, Parameter_);
            }
        }

        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        public void Save()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// 取得某一個Entity的Repository。
        /// 如果沒有取過，會initialise一個
        /// 如果有就取得之前initialise的那個。
        /// </summary>
        /// <typeparam name="T">此Context裡面的Entity Type</typeparam>
        /// <returns>Entity的Repository</returns>
        public IRepository<T> Repository<T>() where T : class, IEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(EFGenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), Context);

                _repositories.Add(type, repositoryInstance);
            }

            return (EFGenericRepository<T>)_repositories[type];

        }

        #region Dispose
        private bool _disposed;
        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        /// <param name="disposing">是否在清理中？</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }

            _disposed = true;
        }
        #endregion

    }
}
