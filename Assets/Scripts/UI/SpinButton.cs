using UnityEngine;
using UnityEngine.UI;
using AxGrid.Base;
using AxGrid;

public class SpinButton : MonoBehaviourExt
{
    [SerializeField] private Button button;

    [OnAwake]
    private void Init()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void ENABLE_SPIN(bool value)
    {
        button.interactable = value;
    }

    public void OnClick()
    {
        Debug.Log("FSM instance ID from button: " + GameStarter.FSM?.GetHashCode());
        Debug.Log("FSM is null? " + (GameStarter.FSM == null));
        Debug.Log("Current state: " + GameStarter.FSM?.CurrentStateName);
        Debug.Log("Spin clicked");
        if (GameStarter.FSM == null)
        {
            Debug.LogError("FSM IS NULL");
            return;
        }
        if (GameStarter.FSM != null)
            // Settings.Model.EventManager.Invoke("SPIN");
            GameStarter.FSM.Invoke("SPIN");
    }
}