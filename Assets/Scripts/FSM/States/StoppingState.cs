using AxGrid.FSM;
using UnityEngine;

[State("StoppingState")]
public class StoppingState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        Debug.Log("Entered StoppingState");
        Parent.Invoke("ENABLE_STOP", false);
        Parent.Invoke("STOP_REELS");
    }

    public void SPIN_FINISHED()
    {
        Parent.Change("StoppedState");
    }
}