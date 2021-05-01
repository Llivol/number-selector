using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : Text
{
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
            curColor.a = curColor.a + (1 / Config.FADE_TIME_IN_SECONDS * Time.deltaTime);
            this.color = curColor;
            yield return null;
        }
    }

    private IEnumerator fadeOut()
    {
        Color curColor = this.color;
        while (curColor.a > 0f)
        {
            curColor.a = curColor.a - (1 / Config.FADE_TIME_IN_SECONDS * Time.deltaTime);
            this.color = curColor;
            yield return null;
        }
    }
}
