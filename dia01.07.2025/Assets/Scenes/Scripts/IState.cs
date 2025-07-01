public interface IState
{
    void Enter();
    void InsertCoin();
    void Cancel();
    void Order();
    void Maintenance();
    void UpdateUI();
}
