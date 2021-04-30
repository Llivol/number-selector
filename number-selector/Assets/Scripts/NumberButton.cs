using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    private const float FADE_SECONDS = 2f;

    [SerializeField] private Button btnNumber;
    [SerializeField] private Image imgBackground;
    [SerializeField] private Text txtNumber;

    public void Show()
    {
        StartCoroutine(fadeIn(imgBackground));
        StartCoroutine(fadeIn(txtNumber));
        StartCoroutine(waitForSecondsAndEnable(FADE_SECONDS));
    }

    public void Hide()
    {
        btnNumber.interactable = false;
        StartCoroutine(fadeOut(imgBackground));
        StartCoroutine(fadeOut(txtNumber));
    }

    private void Awake()
    {
        btnNumber.onClick.AddListener(onClickNumber);
    }

    private void onClickNumber()
    {
        Hide();
    }

    private IEnumerator fadeIn(Image image)
    {
        Color curColor = image.color;
        while (curColor.a < 1f)
        {
            curColor.a = curColor.a + (1 / FADE_SECONDS * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }

    private IEnumerator fadeIn(Text text)
    {
        Color curColor = text.color;
        while (curColor.a < 1f)
        {
            curColor.a = curColor.a + (1 / FADE_SECONDS * Time.deltaTime);
            text.color = curColor;
            yield return null;
        }
    }

    private IEnumerator fadeOut(Image image)
    {
        Color curColor = image.color;
        while (curColor.a > 0f)
        {
            curColor.a = curColor.a - (1 / FADE_SECONDS * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }

    private IEnumerator fadeOut(Text text)
    {
        Color curColor = text.color;
        while (curColor.a > 0f)
        {
            curColor.a = curColor.a - (1 / FADE_SECONDS * Time.deltaTime);
            text.color = curColor;
            yield return null;
        }
    }

    private IEnumerator waitForSecondsAndEnable(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        btnNumber.interactable = true;
    }
}
