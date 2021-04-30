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
        txtNumber.text = num.ToString() + "- " + NumberToText(num);
    }

    private string NumberToText(int num)
    {
        if (num <= 29)
            return new string[] {"", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO",
         "NUEVE", "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISÉIS",
         "DIECISIETE", "DIECIOCHO", "DIECINUEVE", "VEINTE", "VEINTIUNO", "VEINTIDÓS", "VEINTITRÉS",
         "VEINTICUATRO", "VEINTICINCO", "VEINTISÉIS", "VEINTISIETE", "VEINTIOCHO", "VEINTINUEVE"}[num];
        else if (num <= 99)
        {
            string str = new string[] {"TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA",
         "OCHENTA", "NOVENTA"}[num / 10 - 3];

            if ((num % 10) != 0) str += " Y " + NumberToText(num % 10);

            return str;
        }
        else if (num == 100)
            return "CIEN";
        else if (num <= 199)
            return "CIENTO " + NumberToText(num % 100);
        else if (num <= 999)
            return new string[] { "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS",
            "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS" }[num / 100 - 2] + " " + NumberToText(num % 100);
        else if (num <= 1999)
            return "MIL " + NumberToText(num % 1000);
        else if (num <= 999999)
            return NumberToText(num / 1000) + " MIL " + NumberToText(num % 1000);
        else if (num <= 1999999)
            return "UN MILLÓN " + NumberToText(num % 1000000);
        else
            return NumberToText(num / 1000000) + " MILLONES " + NumberToText(num % 1000000);
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
