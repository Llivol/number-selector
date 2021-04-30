using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberText : MonoBehaviour
{
    private const float FADE_SECONDS = 2f;

    [SerializeField] private Text txtNumber;

    public void Show()
    {
        StartCoroutine(fadeIn(txtNumber));
    }

    public void Hide()
    {
        StartCoroutine(fadeOut(txtNumber));
    }

    public void SetNumber(int num)
    {
        txtNumber.text = NumberToText(num);
    }

    private string NumberToText(int num)
    {
        if (num < 0)
            return "Minus " + NumberToText(-num);
        else if (num == 0)
            return "";
        else if (num <= 19)
            return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
         "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
         "Seventeen", "Eighteen", "Nineteen"}[num - 1] + " ";
        else if (num <= 99)
            return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
         "Eighty", "Ninety"}[num / 10 - 2] + " " + NumberToText(num % 10);
        else if (num <= 199)
            return "One Hundred " + NumberToText(num % 100);
        else if (num <= 999)
            return NumberToText(num / 100) + "Hundreds " + NumberToText(num % 100);
        else if (num <= 1999)
            return "One Thousand " + NumberToText(num % 1000);
        else if (num <= 999999)
            return NumberToText(num / 1000) + "Thousands " + NumberToText(num % 1000);
        else if (num <= 1999999)
            return "One Million " + NumberToText(num % 1000000);
        else if (num <= 999999999)
            return NumberToText(num / 1000000) + "Millions " + NumberToText(num % 1000000);
        else if (num <= 1999999999)
            return "One Billion " + NumberToText(num % 1000000000);
        else
            return NumberToText(num / 1000000000) + "Billions " + NumberToText(num % 1000000000);
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
}
