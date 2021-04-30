using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    private const int MIN_VALUE = 1;
    private const int MAX_VALUE = 10000000;

    [SerializeField] private NumberText numberText;
    [SerializeField] private Button btnNext;
    private int currentNumber = 1000;

    private void Start()
    {
        btnNext.onClick.AddListener(onNext);
        generateNumber();
        numberText.SetNumber(currentNumber);
        numberText.Show();
    }

    private void onNext()
    {
        generateNumber();
        numberText.SetNumber(currentNumber);
    }

    private void generateNumber()
    {
        currentNumber = Random.Range(MIN_VALUE, MAX_VALUE);
    }
}
