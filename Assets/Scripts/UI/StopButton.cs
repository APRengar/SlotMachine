using UnityEngine;
using UnityEngine.UI;
using AxGrid.Base;
using AxGrid;

public class StopButton : MonoBehaviourExt
{
    [SerializeField] private Button button;

    [OnAwake]
    private void Init()
    {
        button = gameObject.GetComponent<Button>();
        button.interactable = false;
        button.onClick.AddListener(OnClick);
    }

    private void ENABLE_STOP(bool value)
    {
        button.interactable = value;
    }

    public void OnClick()
    {
        Debug.Log("Stop clicked");
        if (GameStarter.FSM != null)
            Settings.Model.EventManager.Invoke("STOP");
    }
}