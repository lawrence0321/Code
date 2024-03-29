﻿using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    /// <summary>
    /// 代表一個Repository的interface。
    /// </summary>
    /// <typeparam name="T">任意model的class</typeparam>
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        /// <summary>
        /// 新增一筆資料。
        /// </summary>
        /// <param name="Entity_">要新增到的Entity</param>
        void Insert(T Entity_);
        /// <summary>
        /// 取得第一筆符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        T Read(Expression<Func<T, bool>> Predicate_);
        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        IQueryable<T> Reads();
        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        IQueryable<T> Reads(Expression<Func<T, bool>> Predicate_);
        /// <summary>
        /// 更新一筆資料的內容。
        /// </summary>
        /// <param name="Entity_">要更新的內容</param>
        void Update(T Entity_);
        /// <summary>
        /// 刪除一筆資料的內容。
        /// </summary>
        /// <param name="Entity_">要刪除的內容</param>
        void Delete(T Entity_);
        /// <summary>
        /// 刪除一筆資料的內容。
        /// </summary>
        /// <param name="Entity_">要刪除的內容</param>
        void Delete(IEnumerable<T> Entities_);
        /// <summary>
        /// 儲存異動。
        /// </summary>
        void SaveChanges();
    }

}
