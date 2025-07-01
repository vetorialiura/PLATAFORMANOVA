using UnityEngine;

public class NoCoinState : IState
{
    SodaMachine machine;
    public NoCoinState(SodaMachine m) { machine = m; }
    public void Enter() { machine.animator.SetTrigger("NoCoin"); }
    public void InsertCoin() { machine.SetState(machine.hasCoinState); }
    public void Cancel() { }
    public void Order() { }
    public void Maintenance() { machine.SetState(machine.maintenanceState); }
    public void UpdateUI()
    {
        machine.emptyLight.SetActive(false);
        machine.okLight.SetActive(false);
        machine.compartment.SetActive(false);
    }
}
