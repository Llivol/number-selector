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
}
