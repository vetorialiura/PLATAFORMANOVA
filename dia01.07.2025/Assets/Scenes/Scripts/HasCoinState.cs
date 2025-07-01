using UnityEngine;

public class HasCoinState : IState
{
    SodaMachine machine;
    public HasCoinState(SodaMachine m) { machine = m; }
    public void Enter() { machine.animator.SetTrigger("HasCoin"); }
    public void InsertCoin() { }
    public void Cancel() { machine.SetState(machine.noCoinState); }
    public void Order()
    {
        machine.SetState(machine.vendingState);
    }
    public void Maintenance() { }
    public void UpdateUI()
    {
        machine.emptyLight.SetActive(false);
        machine.okLight.SetActive(true);
        machine.compartment.SetActive(false);
    }
}
