namespace Repository.Enums
{
    /// <summary>
    /// DBContext初始化類型
    /// </summary>
    public enum InitializerType
    {
        /// <summary>
        /// 若資料庫不存在,創建一個新的資料庫
        /// <para>若有同名存在且版本不同會跳異常</para>
        /// </summary>
        CreateDatabaseIfNotExists,
        /// <summary>
        /// 執行時永遠捨棄當前資料庫,並創建一個新的
        /// </summary>
        DropCreateDatabaseAlways,
        /// <summary>
        /// 執行時若版本不同捨棄當前資料庫,並創建一個新的
        /// </summary>
        DropCreateDatabaseIfModelChanges,
    }
}
