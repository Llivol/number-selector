using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeButton : Button
{
    public void SetInteractableDelayed(bool value)
    {
        StartCoroutine(waitForSecondsAndSetInteractable(value));
    }

    private IEnumerator waitForSecondsAndSetInteractable(bool value)
    {
        yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS);
        this.interactable = value;
    }
}
