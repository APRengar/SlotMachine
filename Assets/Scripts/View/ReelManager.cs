using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReelManager : MonoBehaviour
{
    [Header("Symbols")]
    [SerializeField] private List<RectTransform> symbols;
    [SerializeField] private float symbolHeight = 200f;

    [Header("Speed")]
    [SerializeField] private float maxSpeed = 2500f;
    [SerializeField] private float accelerationTime = 1.2f;
    [SerializeField] private float decelerationTime = 1.5f;

    [Header("Curves")]
    [SerializeField] private AnimationCurve accelerationCurve;
    [SerializeField] private AnimationCurve decelerationCurve;

    [Header("Spin")]
    [SerializeField] private int minLoopsBeforeStop = 2;

    [Header("Bounce")]
    [SerializeField] private float bounceDistance = 20f;
    [SerializeField] private float bounceTime = 0.15f;

    [Header("Audio")]
    private float distanceAccumulated;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip stopClip;

    [Header("Tick Sound")]
    [SerializeField] private AudioClip tickClip;
    [SerializeField] private float tickVolume = 0.25f;

    private float lastTickPosition;

    public System.Action OnReelStopped;

    private float currentSpeed;
    private bool requestStop;
    private int loopsDone;
    private int targetIndex;

    public IEnumerator SpinCoroutine(int targetSymbolIndex)
    {
        requestStop = false;
        loopsDone = 0;
        targetIndex = targetSymbolIndex;

        float timer = 0f;

        // ================= ACCELERATION =================
        while (timer < accelerationTime)
        {
            timer += Time.deltaTime;
            float t = timer / accelerationTime;

            currentSpeed = maxSpeed * accelerationCurve.Evaluate(t);
            MoveSymbols(currentSpeed);

            yield return null;
        }

        currentSpeed = maxSpeed;

        // ================= MAX SPEED =================
        while (!requestStop || loopsDone < minLoopsBeforeStop)
        {
            MoveSymbols(currentSpeed);
            yield return null;
        }

        // ================= DECELERATION =================

        float distanceToTarget = GetDistanceToTarget();
        float fullLoopDistance = symbolHeight * symbols.Count;

        // добавляем минимальные обороты
        distanceToTarget += fullLoopDistance * minLoopsBeforeStop;

        float startSpeed = currentSpeed;

        // вычисляем сколько нужно тормозить
        // distance = v * t / 2  =>  t = 2 * distance / v
        float requiredTime = (2f * distanceToTarget) / startSpeed;

        timer = 0f;

        while (timer < requiredTime)
        {
            timer += Time.deltaTime;
            float t = timer / requiredTime;

            currentSpeed = Mathf.Lerp(startSpeed, 0f, t);
            MoveSymbols(currentSpeed);

            yield return null;
        }

        yield return StartCoroutine(BounceEffect());
        if (stopClip != null && audioSource != null)
            audioSource.PlayOneShot(stopClip);
    }

    private IEnumerator BounceEffect()
    {
        float timer = 0f;

        while (timer < bounceTime)
        {
            timer += Time.deltaTime;
            float t = timer / bounceTime;

            float offset = Mathf.Lerp(0, bounceDistance, t);

            foreach (var s in symbols)
                s.anchoredPosition -= new Vector2(0, offset * Time.deltaTime * 10f);

            yield return null;
        }

        timer = 0f;

        while (timer < bounceTime)
        {
            timer += Time.deltaTime;
            float t = timer / bounceTime;

            float offset = Mathf.Lerp(bounceDistance, 0, t);

            foreach (var s in symbols)
                s.anchoredPosition += new Vector2(0, offset * Time.deltaTime * 10f);

            yield return null;
        }

        foreach (var s in symbols)
        {
            float snapped =
                Mathf.Round(s.anchoredPosition.y / symbolHeight) * symbolHeight;

            s.anchoredPosition =
                new Vector2(s.anchoredPosition.x, snapped);
        }
        OnReelStopped?.Invoke();
    }

    private float GetDistanceToTarget()
    {
        RectTransform target = symbols[targetIndex];

        float distance = target.anchoredPosition.y;

        if (distance < 0)
            distance += (symbolHeight-100) * symbols.Count;

        return distance;
    }

    public void RequestStop()
    {
        requestStop = true;
    }

    // ==================================================


    private void MoveSymbols(float speed)
    {
        foreach (var symbol in symbols)
        {
            symbol.anchoredPosition -= Vector2.up * speed * Time.deltaTime;
        }

        LoopSymbols();
        float delta = currentSpeed * Time.deltaTime;
        distanceAccumulated += delta;

        if (distanceAccumulated >= symbolHeight)
        {
            distanceAccumulated -= symbolHeight;
            PlayTick();
        }
        // CheckTick();
    }

    private void LoopSymbols()
    {
        foreach (var symbol in symbols)
        {
            if (symbol.anchoredPosition.y < -symbolHeight * 3f)
            {
                float highestY = GetHighestY();

                symbol.anchoredPosition = new Vector2(
                    symbol.anchoredPosition.x,
                    highestY + symbolHeight
                );

                loopsDone++;
            }
        }
    }

    private void CheckTick()
    {
        foreach (var symbol in symbols)
        {
            if (symbol.anchoredPosition.y < symbolHeight * 0.5f &&
                symbol.anchoredPosition.y > -symbolHeight * 0.5f)
            {
                float currentPos = symbol.anchoredPosition.y;

                
                if (Mathf.Abs(currentPos) < symbolHeight * 0.1f)
                {
                    PlayTick();
                    break; 
                }
            }
        }
    }

    private void PlayTick()
    {
        if (tickClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(tickClip, tickVolume);
        }
    }

    private float GetHighestY()
    {
        float max = float.MinValue;

        foreach (var s in symbols)
            if (s.anchoredPosition.y > max)
                max = s.anchoredPosition.y;

        return max;
    }


    }