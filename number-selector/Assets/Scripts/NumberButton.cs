using System.Collections;
using UnityEngine;

public class NumberButton : MonoBehaviour
{
    private const float FADE_SECONDS = 2f;

    [SerializeField] private FadeButton btnNumber;
    [SerializeField] private FadeImage imgBackground;
    [SerializeField] private FadeText txtNumber;

    public void Show()
    {
        imgBackground.Show();
        txtNumber.Show();
        btnNumber.SetInteractableDelayed(true);
    }

    public void Hide()
    {
        btnNumber.interactable = false;
        imgBackground.Hide();
        txtNumber.Hide();
    }

    private void Awake()
    {
        btnNumber.onClick.AddListener(onClickNumber);
        Show();
    }

    private void onClickNumber()
    {
        Hide();
    }

    private IEnumerator waitForSecondsAndEnable(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        btnNumber.interactable = true;
    }
}
