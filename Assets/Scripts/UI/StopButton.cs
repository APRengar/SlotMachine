using UnityEngine;
using UnityEngine.UI;
using AxGrid.Base;
using AxGrid;
using AxGrid.Model;

public class StopButton : MonoBehaviourExt
{
    [SerializeField] private Button button;

    [OnAwake]
    private void Init()
    {
        button.onClick.AddListener(OnClick);
    }

    [Bind]
    public void STOP_INTERACTABLE(bool value)
    {
        Debug.Log("Stop Button " + value);
        button.interactable = value;
    }

    public void OnClick()
    {
        if (GameStarter.FSM != null)
            GameStarter.FSM.Invoke(SlotEvents.Stop);
    }
}