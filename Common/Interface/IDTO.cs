namespace Common.Interface
{
    public interface IDTO
    {
    }

    /// <summary>
    /// 設定ViewModel要對應的IEntity。
    /// 這個用預設的Convention來對應
    /// </summary>
    /// <typeparam name="T">要被對應到的Type</typeparam>
    public interface IMapperForm<T> : IDTO where T : IEntity
    {
    }

    /// <summary>
    /// 設定ViewModel要對應的IEntity。
    /// 如果需要客制AutoMapper的邏輯，讓ViewModel實作此Interface
    /// </summary>
    public interface IHaveCustomMapping : IDTO
    {
    }
}
