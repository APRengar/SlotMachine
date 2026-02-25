using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public static SlotFSM FSM;

    private void Start()
    {
        FSM = new SlotFSM();
        Debug.Log("FSM created");
    }

    private void Update()
    {
        FSM?.Update(Time.deltaTime);
    }
}