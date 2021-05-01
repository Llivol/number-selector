using UnityEngine;

public class NumberManager : MonoBehaviour
{
    [SerializeField] private NumberText numberText;
    private int currentNumber;
    private int difficulty = 0;

    private void Start()
    {
        generateNumber();
        numberText.SetNumberToText(currentNumber);
    }

    private void generateNumber()
    {
        currentNumber = Random.Range(Config.MIN_VALUE, Config.MAX_VALUES[difficulty]);
    }
}
