using AxGrid.FSM;
using UnityEngine;

[State("StoppedState")]
public class StoppedState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        Debug.Log("Entered Stopped");
        Parent.Invoke("ENABLE_START", true);
    }
}