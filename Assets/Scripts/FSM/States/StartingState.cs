using AxGrid.FSM;
using UnityEngine;

[State("StartingState")]
public class StartingState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        Debug.Log("Entered StartingState");
        Parent.Invoke("ENABLE_START", false);
        Parent.Invoke("ENABLE_STOP", false);
        Parent.Invoke("SPIN_START");

        Parent.InvokeDelayAsync(3f, "ENABLE_STOP_PHASE");
        Parent.Change("SpinningState");
    }

    public void ENABLE_STOP_PHASE()
    {
        Parent.Change("CanStopState");
    }
}