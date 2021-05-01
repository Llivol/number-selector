using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : Image
{
    private const float FADE_SECONDS = 2f;

    public void Show()
    {
        StartCoroutine(fadeIn());
    }

    public void Hide()
    {
        StartCoroutine(fadeOut());
    }

    private IEnumerator fadeIn()
    {
        Color curColor = this.color;
        while (curColor.a < 1f)
        {
            curColor.a = curColor.a + (1 / FADE_SECONDS * Time.deltaTime);
            this.color = curColor;
            yield return null;
        }
    }

    private IEnumerator fadeOut()
    {
        Color curColor = this.color;
        while (curColor.a > 0f)
        {
            curColor.a = curColor.a - (1 / FADE_SECONDS * Time.deltaTime);
            this.color = curColor;
            yield return null;
        }
    }
}
