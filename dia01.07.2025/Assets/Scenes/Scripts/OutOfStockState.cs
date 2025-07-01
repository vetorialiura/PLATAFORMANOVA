using UnityEngine;

public class OutOfStockState : IState
{
    SodaMachine machine;
    public OutOfStockState(SodaMachine m) { machine = m; }
    public void Enter() { machine.animator.SetTrigger("Empty"); }
    public void InsertCoin() { }
    public void Cancel() { }
    public void Order() { }
    public void Maintenance() { machine.SetState(machine.maintenanceState); }
    public void UpdateUI()
    {
        machine.emptyLight.SetActive(true);
        machine.okLight.SetActive(false);
        machine.compartment.SetActive(false);
    }
}