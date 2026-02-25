using AxGrid;
using AxGrid.FSM;
using UnityEngine;

[State("StartingState")]
public class StartingState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        GameEvents.OnSpinStart?.Invoke();
        // Debug.Log("Enter Starting");
        // Settings.Model.Set("SpinAvailable", false);
        // Parent.Invoke(SlotEvents.SpinVisible, false);  // не работает
        // Parent.Invoke(SlotEvents.StopInteractable, false);
        // Parent.Invoke(SlotEvents.SpinStart); 

        Parent.Change("SpinningState");
    }
}