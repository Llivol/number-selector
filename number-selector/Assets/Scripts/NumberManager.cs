using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    private const int MIN_VALUE = 0;
    private const int MAX_VALUE = 100;

    [SerializeField] private NumberText numberText;
    
    private int currentNumber;

    private void Start()
    {
        generateNumber();
        numberText.SetNumber(currentNumber);
        numberText.Show();
    }

    private void generateNumber()
    {
        currentNumber = Random.Range(MIN_VALUE, MAX_VALUE);
    }
}
