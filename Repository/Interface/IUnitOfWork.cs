using Common.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    /// <summary>
    /// 實作Unit Of Work的interface。
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        void Save();

        /// <summary>
        /// 使用Dapper查詢
        /// </summary>
        /// <typeparam name="T">欲轉換的物件</typeparam>
        /// <param name="Strsql_">Sql語法</param>
        /// <param name="Parameters_">參數組</param>
        /// <returns></returns>
        IEnumerable<T> UseDapper<T>(string Strsql_, DynamicParameters Parameters_);

        /// <summary>
        /// 使用Dapper查詢
        /// </summary>
        /// <typeparam name="T">欲轉換的物件</typeparam>
        /// <param name="Strsql_">Sql語法</param>
        /// <returns></returns>
        IEnumerable<T> UseDapper<T>(string Strsql_);

        /// <summary>
        /// 使用Dapper查詢
        /// </summary>
        /// <param name="Strsql_">Sql語法</param>
        /// <param name="Parameters_">參數組</param>
        /// <returns></returns>
        IEnumerable<dynamic> UseDapper(string Strsql_, DynamicParameters Parameters_);


        /// <summary>
        /// 取得某一個Entity的Repository。
        /// 如果沒有取過，會initialise一個
        /// 如果有就取得之前initialise的那個。
        /// </summary>
        /// <typeparam name="T">此Context裡面的Entity Type</typeparam>
        /// <returns>Entity的Repository</returns>
        IRepository<T> Repository<T>() where T : class, IEntity;
    }

}
