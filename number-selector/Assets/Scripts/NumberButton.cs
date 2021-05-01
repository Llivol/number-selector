public class NumberButton : FadeButtonController
{
    private int number;

    private void Awake()
    {
        btnFade.onClick.AddListener(onClickNumber);
    }

    private void onClickNumber()
    {
        if (number == NumberManager.Instance.GetCurrentNumber())
        {
            SetCorrectColor();
            NumberManager.Instance.OnClickCorrect();
        }
        else
        {
            setWrongColor();
            NumberManager.Instance.OnClickError();
            Hide();
        }
    }

    public void ResetColor()
    {
        imgFade.color = Config.COLOR_BG_DEFAULT;
        txtFade.color = Config.COLOR_TXT_DEFAULT;
    }

    public void SetCorrectColor()
    {
        imgFade.color = Config.COLOR_BG_CORRECT;
        txtFade.color = Config.COLOR_TXT_CORRECT;
    }

    private void setWrongColor()
    {
        imgFade.color = Config.COLOR_BG_WRONG;
        txtFade.color = Config.COLOR_TXT_WRONG;
    }

    public void SetNumber(int number)
    {
        this.number = number;
        txtFade.text = number.ToString();
    }

    public int GetNumber()
    {
        return number;
    }
}
