using AxGrid.FSM;
using UnityEngine;

[State("IdleState")]
public class IdleState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        Debug.Log("IdleState");
        Parent.Invoke("ENABLE_START", true);
        Parent.Invoke("ENABLE_STOP", false);
    }

    public void SPIN()
    {
        Debug.Log("SPIN method exists");
        Parent.Change("StartingState");
    }
}