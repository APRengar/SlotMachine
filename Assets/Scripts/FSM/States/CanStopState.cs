
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

[State("CanStopState")]
public class CanStopState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        // Debug.Log("Enter CanStop");
        
        GameEvents.OnCanStop?.Invoke();
    }

    [Bind]
    public void STOP()
    {
        Parent.Change("StoppingState");
    }
}