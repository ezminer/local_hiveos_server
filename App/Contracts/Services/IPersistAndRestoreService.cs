namespace MyApp.Contracts.Services
{
    public interface IPersistAndRestoreService
    {/// <summary>
    /// 加载数据
    /// </summary>
        void RestoreData();
        /// <summary>
        /// 持久化数据
        /// </summary>
        void PersistData();
    }
}
