using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

[State("SpinningState")]
public class SpinningState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        // Debug.Log("Enter Spinning");
        Parent.InvokeDelayAsync(3f, "ENABLE_STOP");
        
    }

    [Bind]
    public void ENABLE_STOP()
    {
        // Debug.Log("Enable Stop");
        Parent.Change("CanStopState");
    }
    
    [Bind]
    public void STOP()
    {
        // если нажали раньше 3 сек — игнор
    }
}