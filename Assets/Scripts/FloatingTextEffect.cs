using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class FloatingTextEffect : MonoBehaviour
{
 public TextMeshProUGUI floatingText;
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;
    public float floatDistance = 50f;

    void Start()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0; // Make the text invisible at the start
    }

    public void ShowFloatingText(int scoreChange)
    {
        floatingText.text = scoreChange > 0 ? $"+{scoreChange}" : scoreChange.ToString();
        StartCoroutine(FadeOutText());
    }

    private IEnumerator FadeOutText()
    {
        canvasGroup.alpha = 1;
        Vector3 originalPosition = floatingText.transform.localPosition;
        Vector3 targetPosition = originalPosition + new Vector3(0, floatDistance, 0);
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            floatingText.transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0;
        floatingText.transform.localPosition = originalPosition; // Reset position
    }
}