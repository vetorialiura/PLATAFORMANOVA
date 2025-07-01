using UnityEngine;
using System.Collections;
public class VendingState : IState
{
    SodaMachine machine;
    public VendingState(SodaMachine m) { machine = m; }
    public void Enter()
    {
        machine.animator.SetTrigger("Vend");
        machine.stock--;
        machine.UpdateCans();
        machine.StartCoroutine(EndVending());
    }
    public void InsertCoin() { }
    public void Cancel() { }
    public void Order() { }
    public void Maintenance() { }
    public void UpdateUI()
    {
        machine.emptyLight.SetActive(false);
        machine.okLight.SetActive(false);
        machine.compartment.SetActive(false);
    }
    private IEnumerator EndVending()
    {
        yield return new WaitForSeconds(2f);
        if (machine.stock == 0)
            machine.SetState(machine.outOfStockState);
        else
            machine.SetState(machine.noCoinState);
    }
}
