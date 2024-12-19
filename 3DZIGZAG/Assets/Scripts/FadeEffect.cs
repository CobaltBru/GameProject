using System.Collections;
using TMPro;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    private float fadeTime = 0.5f;
    [SerializeField]
    private AnimationCurve fadeCurve;
    private TextMeshProUGUI fadeText;

    private float endAlpha;

    private void Awake()
    {
        fadeText = GetComponent<TextMeshProUGUI>();
        endAlpha = fadeText.color.a;
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0, endAlpha));
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while(percent<1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;

            Color color = fadeText.color;
            color.a = Mathf.Lerp(start,end,fadeCurve.Evaluate(percent));
            fadeText.color = color;

            yield return null;
        }
    }
}
