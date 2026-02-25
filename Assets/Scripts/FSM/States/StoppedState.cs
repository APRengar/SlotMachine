using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

[State("StoppedState")]
public class StoppedState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        // Debug.Log("Enter Stopped");
        GameEvents.OnIdle?.Invoke();
        // Parent.Invoke(SlotEvents.SpinVisible, true);  // не работает
    }

    [Bind]
    public void SPIN()
    {
        Parent.Change("StartingState");
    }
}