using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

public class SpinUIController : MonoBehaviour
{
    [SerializeField] private GameObject spinButton;
    [SerializeField] private Button stopButton;

    [Bind]
    public void SHOW_SPIN()
    {
        spinButton.SetActive(true);
    }

    [Bind]
    public void HIDE_SPIN()
    {
        spinButton.SetActive(false);
    }

    [Bind]
    public void ENABLE_STOP(bool value)
    {
        stopButton.interactable = value;
    }
}