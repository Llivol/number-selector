using UnityEngine;

public class NumberManager : MonoBehaviour
{
    [SerializeField] private NumberText txtNumber;
    [SerializeField] private FadeText txtDifficulty;
    [SerializeField] private FadeButtonController[] difficultyButtons;

    private int currentNumber;
    private int difficulty = 0;

    private void Start()
    {
        txtDifficulty.Show();
        foreach(var button in difficultyButtons) button.Show();
        // generateNumber();
        // numberText.SetNumberToText(currentNumber);
    }

    private void generateNumber()
    {
        currentNumber = Random.Range(Config.MIN_VALUE, Config.MAX_VALUES[difficulty]);
    }
}
