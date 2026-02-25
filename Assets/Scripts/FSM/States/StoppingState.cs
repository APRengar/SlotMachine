using System.Collections;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

[State("StoppingState")]
public class StoppingState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        // Debug.Log("Enter Stopping");
        GameEvents.OnStop?.Invoke();
        // Parent.Invoke(SlotEvents.StopReels);   // не работает

        Parent.InvokeDelayAsync(3f, "STOP_COMPLETE");
    }

    [Bind]
    public void STOP_COMPLETE()
    {
        Parent.Change("StoppedState");
    }
}