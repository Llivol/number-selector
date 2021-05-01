using UnityEngine;

public class FadeButtonController : MonoBehaviour
{
    [SerializeField] protected FadeButton btnFade;
    [SerializeField] protected FadeImage imgFade;
    [SerializeField] protected FadeText txtFade;

    public void Show()
    {
        imgFade.Show();
        txtFade.Show();
        btnFade.SetInteractableDelayed(true);
    }

    public void Hide()
    {
        btnFade.interactable = false;
        imgFade.Hide();
        txtFade.Hide();
    }

    private void Awake()
    {
        btnFade.onClick.AddListener(onClickNumber);
    }

    private void onClickNumber()
    {
        btnFade.interactable = false;
    }

}