using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeButton : Button
{
    private const float FADE_SECONDS = 2f;

    public void SetInteractableDelayed(bool value)
    {
        StartCoroutine(waitForSecondsAndSetInteractable(FADE_SECONDS));
    }

    private IEnumerator waitForSecondsAndSetInteractable(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.interactable = true;
    }
}
