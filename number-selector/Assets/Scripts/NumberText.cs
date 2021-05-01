using UnityEngine;

public class NumberText : MonoBehaviour
{
    [SerializeField] private FadeText txtNumber;

    public void Show()
    {
        txtNumber.Show();
    }

    public void Hide()
    {
        txtNumber.Hide();
    }

    public void SetNumberToText(int num)
    {
        txtNumber.text = num.ToString() + "- " + numberToText(num);
    }

    private string numberToText(int num)
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

            if ((num % 10) != 0) str += " Y " + numberToText(num % 10);

            return str;
        }
        else if (num == 100)
            return "CIEN";
        else if (num <= 199)
            return "CIENTO " + numberToText(num % 100);
        else if (num <= 999)
            return new string[] { "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS",
            "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS" }[num / 100 - 2] + " " + numberToText(num % 100);
        else if (num <= 1999)
            return "MIL " + numberToText(num % 1000);
        else if (num <= 999999)
            return numberToText(num / 1000) + " MIL " + numberToText(num % 1000);
        else if (num <= 1999999)
            return "UN MILLÓN " + numberToText(num % 1000000);
        else
            return numberToText(num / 1000000) + " MILLONES " + numberToText(num % 1000000);
    }
}
