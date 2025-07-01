using UnityEngine;

public class MaintenanceState : IState
{
    SodaMachine machine;
    public MaintenanceState(SodaMachine m) { machine = m; }
    public void Enter()
    {
        machine.animator.SetTrigger("Maintenance");
        machine.compartment.SetActive(true);
    }
    public void InsertCoin()
    {
        if (machine.stock < machine.maxStock)
        {
            machine.stock++;
            machine.UpdateCans();
        }
    }
    public void Cancel() { }
    public void Order() { }
    public void Maintenance()
    {
        machine.compartment.SetActive(false);
        if (machine.stock == 0)
            machine.SetState(machine.outOfStockState);
        else
            machine.SetState(machine.noCoinState);
    }
    public void UpdateUI()
    {
        machine.emptyLight.SetActive(false);
        machine.okLight.SetActive(false);
    }
}
