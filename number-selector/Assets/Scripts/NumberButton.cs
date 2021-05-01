public class NumberButton : FadeButtonController
{
    private int number;

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
