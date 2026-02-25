using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

[State("IdleState")]
public class IdleState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        // Debug.Log("Enter Idle");
        
        GameEvents.OnIdle?.Invoke();

        // Parent.Invoke(SlotEvents.SpinVisible, true);  // не работает
        // Parent.Invoke(SlotEvents.StopInteractable, false);
    }

    [Bind]
    public void SPIN()
    {
        Parent.Change("StartingState");
    }
}