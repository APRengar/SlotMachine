using UnityEngine;
using AxGrid;
using AxGrid.Model;
using Unity.VisualScripting;

public class GameStarter : MonoBehaviour
{
    public static SlotFSM FSM;

    [SerializeField] private ReelManager reelManager;
    [SerializeField] private string currentStateName;

    private void Awake()
    {
        FSM = new SlotFSM();
        Settings.Fsm = FSM;
    }

    private void Start()
    {
        Settings.Model.Set("SpinButtonActive", true);
        Settings.Model.Set("StopButtonActive", false);
    }

    private void Update()
    {
        Settings.Model?.EventManager?.Update(Time.deltaTime);
        Settings.Fsm?.Update(Time.deltaTime);

        if (FSM != null)
            currentStateName = FSM.CurrentStateName;
    }

    // [Bind]
    // public void SPIN_START()
    // {
    //     reelManager.SPIN_START();
    // }

    // [Bind]
    // public void STOP_REELS()
    // {
    //     reelManager.STOP_REELS();
    // }
}