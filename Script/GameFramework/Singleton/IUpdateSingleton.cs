/// <summary>
/// ��Ҫ֡���µĵ���
/// </summary>
public interface IUpdateSingleton : ISingleton
{
    /// <summary>
    /// ֡���·���
    /// </summary>
    abstract void OnUpdate();
}