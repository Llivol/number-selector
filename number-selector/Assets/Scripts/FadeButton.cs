using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeButton : Button
{
    public void SetInteractableDelayed(bool value)
    {
        StartCoroutine(waitForSecondsAndSetInteractable());
    }

    private IEnumerator waitForSecondsAndSetInteractable()
    {
        yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS);
        this.interactable = true;
    }
}
