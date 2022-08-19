using Common.Interface;
using MySql.Data.EntityFramework;
using Repository.Enums;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    internal class EFGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        internal EFGenericDBContext Context { get; set; }
        /// <summary>
        /// 建構EF一個Entity的Repository，需傳入此Entity的Context。
        /// </summary>
        /// <param name="Context_">Entity所在的Context</param>
        public EFGenericRepository(IDBContext Context_)
        {
            this.Context = (EFGenericDBContext)Context_;
        }
        /// <summary>
        /// 新增一筆資料到資料庫。
        /// </summary>
        /// <param name="entity">要新增到資料的庫的Entity</param>
        public void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// 取得第一筆符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <param name="Predicate_">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        public TEntity Read(Expression<Func<TEntity, bool>> Predicate_)
        {
            return Context.Set<TEntity>().Where(Predicate_).FirstOrDefault();
        }

        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        public IQueryable<TEntity> Reads()
        {
            return Context.Set<TEntity>().AsQueryable();
        }
        /// <summary>
        /// 取得符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        public IQueryable<TEntity> Reads(Expression<Func<TEntity, bool>> Predicate_)
        {
            return Context.Set<TEntity>().Where(Predicate_);
        }

        /// <summary>
        /// 更新一筆Entity內容。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        public void Update(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public void Delete(IEnumerable<TEntity> entitites)
        {
            Context.Set<TEntity>().RemoveRange(entitites);
        }

        /// <summary>
        /// 更新一筆Entity的內容。只更新有指定的Property。
        /// </summary>
        /// <param name="entity">要更新的內容。</param>
        /// <param name="UpdateProperties_">需要更新的欄位。</param>
        public void Update(TEntity entity, Expression<Func<TEntity, Object>>[] UpdateProperties_)
        {
            Context.Configuration.ValidateOnSaveEnabled = false;
            Context.Entry<TEntity>(entity).State = EntityState.Unchanged;

            if (UpdateProperties_ != null)
            {
                foreach (var property in UpdateProperties_)
                {
                    Context.Entry<TEntity>(entity).Property(property).IsModified = true;
                }
            }

        }
        /// <summary>
        /// 儲存異動。
        /// </summary>
        public void SaveChanges()
        {
            Context.SaveChanges();

            // 因為Update 單一model需要先關掉validation，因此重新打開
            if (Context.Configuration.ValidateOnSaveEnabled == false)
            {
                Context.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置 Managed 狀態 (Managed 物件)。
                    Context.Dispose();
                }

                disposedValue = true;
            }
        }
        #endregion

    }

}
