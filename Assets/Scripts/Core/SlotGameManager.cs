using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlotGameManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button spinButton;
    [SerializeField] private Button stopButton;

    [Header("Reels")]
    [SerializeField] private ReelManager reelManager;

    [Header("Effects")]
    [SerializeField] private ParticleSystem[] spinningEffect;
    [SerializeField] private ParticleSystem[] winEffect;

    private Coroutine spinRoutine;

    private void OnEnable()
    {
        GameEvents.OnIdle += HandleIdle;
        GameEvents.OnSpinStart += HandleSpinStart;
        GameEvents.OnCanStop += HandleCanStop;
        GameEvents.OnStop += HandleStop;
        reelManager.OnReelStopped += HandleReelStopped;
    }

    private void OnDisable()
    {
        GameEvents.OnIdle -= HandleIdle;
        GameEvents.OnSpinStart -= HandleSpinStart;
        GameEvents.OnCanStop -= HandleCanStop;
        GameEvents.OnStop -= HandleStop;
    }

    private void HandleIdle()
    {
        spinButton.gameObject.SetActive(true);
        stopButton.interactable = false;
    }

    private void HandleSpinStart()
    {
        spinButton.gameObject.SetActive(false);
        stopButton.interactable = false;

        int randomResult = Random.Range(0, 6);
        spinRoutine = StartCoroutine(reelManager.SpinCoroutine(randomResult));
        foreach (ParticleSystem effect in spinningEffect)
        {
            effect.Play();
        }
    }

    private void HandleCanStop()
    {
        stopButton.interactable = true;
    }

    private void HandleStop()
    {
        stopButton.interactable = false;
        reelManager.RequestStop();
    }


    private void HandleReelStopped()
    {
        foreach (ParticleSystem effect in spinningEffect)
        {
            effect.Stop();
        }
        foreach (ParticleSystem effect in winEffect)
        {
            effect.Play();
        }
    }
}