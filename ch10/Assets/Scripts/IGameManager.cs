public interface IGameManager
{
    ManagerStatus status { get; }
    void StartUp(NetworkService service);
}
