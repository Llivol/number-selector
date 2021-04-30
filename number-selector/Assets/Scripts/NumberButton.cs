using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    [SerializeField] private Button btnNumber;
    [SerializeField] private Image imgBackground;
    [SerializeField] private Text txtNumber;

    private void Awake() 
    {
        btnNumber.onClick.AddListener(onClickNumber);
    }

    private void onClickNumber()
    {
        btnNumber.interactable = false;
        StartCoroutine(fadeOut(imgBackground));
        StartCoroutine(fadeOut(txtNumber));
    }

    private IEnumerator fadeOut(Image image)
    {
        Color curColor = image.color;
        while(curColor.a > 0.0001f) 
        {
            curColor.a = curColor.a - (.5f * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }

    private IEnumerator fadeOut(Text text)
    {
        Color curColor = text.color;
        while(curColor.a > 0.0001f) 
        {
            curColor.a = curColor.a - (.5f * Time.deltaTime);
            text.color = curColor;
            yield return null;
        }
    }

}
