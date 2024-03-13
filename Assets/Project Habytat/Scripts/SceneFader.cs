using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image progressBar;

    public event Action OnFadeComplete;

    public IEnumerator FadeIn(float duration)
    {
        yield return StartCoroutine(FadeCanvasGroup(canvasGroup.alpha, 1f, duration));
        OnFadeComplete?.Invoke();
    }

    public IEnumerator FadeOut(float duration)
    {
        yield return StartCoroutine(FadeCanvasGroup(canvasGroup.alpha, 0f, duration));
        OnFadeComplete?.Invoke();
    }

    public void SetProgressBar(float progress)
    {
        if (progressBar != null)
        {
            progressBar.fillAmount = progress;
        }
    }

    private IEnumerator FadeCanvasGroup(float start, float end, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(start, end, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = end;
    }
}