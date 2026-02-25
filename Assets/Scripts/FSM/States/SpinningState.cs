using AxGrid.FSM;
using UnityEngine;

[State("SpinningState")]
public class SpinningState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        Debug.Log("Entered SpinningState");
        Parent.Invoke(SlotEvents.EnableSpin, false);
        Parent.Invoke(SlotEvents.EnableStop, true);
        Parent.InvokeDelayAsync(2f, "CAN_STOP");
    }

    [Exit]
    private void OnExit()
    {
        // Parent.Invoke(SlotEvents.EnableSpin, true);
        Parent.Invoke(SlotEvents.EnableStop, false);
    }
}