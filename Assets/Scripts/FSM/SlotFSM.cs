using AxGrid.FSM;
using AxGrid;
using UnityEngine;

public class SlotFSM : FSM
{
    public SlotFSM()
    {
        Name = "SlotFSM";

        Add(
            new IdleState(),
            new StartingState(),
            new SpinningState(),
            new CanStopState(),
            new StoppingState(),
            new StoppedState()
        );

        Start("IdleState");

        Debug.Log("FSM instance ID: " + this.GetHashCode());
        // Debug.Log("States count: " + StatesCount);
        // Debug.Log("Has Idle: " + ContainsState("IdleState"));
        // Debug.Log("Has Starting: " + ContainsState("StartingState"));
        // Debug.Log("Has Spinning: " + ContainsState("SpinningState"));
    }
}