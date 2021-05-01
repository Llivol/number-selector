using UnityEngine;

public class FadeButtonController : MonoBehaviour
{
    [SerializeField] protected FadeButton btnFade;
    [SerializeField] protected FadeImage imgFade;
    [SerializeField] protected FadeText txtFade;

    private bool isShown = false;

    public void Show()
    {
        isShown = true;
        imgFade.Show();
        txtFade.Show();
        btnFade.SetInteractableDelayed(true);
    }

    public void Hide()
    {
        isShown = false;
        btnFade.interactable = false;
        imgFade.Hide();
        txtFade.Hide();
    }

    public bool IsShown()
    {
        return isShown;
    }

    public void SetInteractable(bool value)
    {
        btnFade.interactable = value;
    }
}