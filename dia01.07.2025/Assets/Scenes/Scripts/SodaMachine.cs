using UnityEngine;

public class SodaMachine : MonoBehaviour
{
    public int maxStock = 5;
    public int stock = 0;

    [HideInInspector]
    public IState currentState;

    // Referências para UI e Animator
    public Animator animator;
    public GameObject emptyLight, okLight, compartment, cansParent;
    public GameObject[] canImages;

    // Estados
    public MaintenanceState maintenanceState;
    public OutOfStockState outOfStockState;
    public NoCoinState noCoinState;
    public HasCoinState hasCoinState;
    public VendingState vendingState;

    private void Awake()
    {
        // Inicialize os estados
        maintenanceState = new MaintenanceState(this);
        outOfStockState = new OutOfStockState(this);
        noCoinState = new NoCoinState(this);
        hasCoinState = new HasCoinState(this);
        vendingState = new VendingState(this);
    }

    void Start()
    {
        // Iniciar estado (exemplo: sem estoque)
        if (stock == 0)
            SetState(outOfStockState);
        else
            SetState(noCoinState);
    }

    public void SetState(IState state)
    {
        currentState = state;
        currentState.Enter();
        currentState.UpdateUI();
    }

    // Métodos dos botões
    public void OnInsert() => currentState.InsertCoin();
    public void OnCancel() => currentState.Cancel();
    public void OnOrder() => currentState.Order();
    public void OnMaintenance() => currentState.Maintenance();

    // Atualiza UI das latinhas
    public void UpdateCans()
    {
        for (int i = 0; i < canImages.Length; i++)
            canImages[i].SetActive(i < stock);
    }
}
