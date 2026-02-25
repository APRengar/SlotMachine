using UnityEngine;
using UnityEngine.UI;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid;

public class SpinButton : Binder
{
    [SerializeField] private Button button;

    [OnAwake]
    private void Init()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Settings.Fsm?.Invoke(SlotEvents.Spin);
    }

    // Слушаем модель
    [Bind]
    private void SpinButtonActive(bool value)
    {
        Debug.LogWarning("SpinButtonActive Bind: " + value);
        button.gameObject.SetActive(value);
    }
}