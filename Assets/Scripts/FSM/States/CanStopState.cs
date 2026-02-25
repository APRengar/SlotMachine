
using AxGrid.FSM;
using UnityEngine;

[State("CanStopState")]
public class CanStopState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        Debug.Log("CanStopNow");
        Parent.Invoke("ENABLE_STOP", true);

    }

    public void STOP_CLICK()
    {
        Parent.Change("StoppingState");
    }
}