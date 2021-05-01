using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberManager : MonoBehaviour
{
    public static NumberManager Instance = null;

    [SerializeField] private NumberText txtNumber;
    [SerializeField] private FadeText txtDifficulty;
    [SerializeField] private DifficultyButton[] difficultyButtons;
    [SerializeField] private NumberButton[] numberButtons;

    private int currentNumber;
    private int currentButtonIdx;
    private int difficulty;

    private void Awake()
    {

        if (Instance == null) { Instance = this; }
        else if (Instance != this) { throw new DuplicateSingletonException("NumberManager"); }

        txtDifficulty.Show();

        int difficultyButtonsLength = difficultyButtons.Length;
        for (int i = 0; i < difficultyButtonsLength; i++)
        {
            var button = difficultyButtons[i];
            button.SetDifficulty(i);
            button.Show();
        }
    }

    public int GetCurrentNumber()
    {
        return currentNumber;
    }

    public void SetDifficulty(int difficulty)
    {
        int buttonsLength = difficultyButtons.Length;
        for (int i = 0; i < buttonsLength; i++) difficultyButtons[i].Hide();
        txtDifficulty.Hide();

        this.difficulty = difficulty;

        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS);

        currentNumber = generateNumber();
        txtNumber.SetNumberToText(currentNumber);
        txtNumber.Show();

        yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS * 2);

        txtNumber.Hide();

        yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS);

        showNumberButtons();
    }

    private void showNumberButtons()
    {
        int buttonsLength = numberButtons.Length;
        currentButtonIdx = Random.Range(0, buttonsLength - 1);

        for (int i = 0; i < buttonsLength; i++)
        {
            var button = numberButtons[i];

            if (i == currentButtonIdx) button.SetNumber(currentNumber);
            else
            {
                int errorNumber;

                do errorNumber = generateNumber();
                while (errorNumber == currentNumber);

                button.SetNumber(errorNumber);
            }

            button.Show();
        }
    }

    private int generateNumber()
    {
        return Random.Range(Config.MIN_VALUE, Config.MAX_VALUES[difficulty]);
    }

    class DuplicateSingletonException : System.Exception
    {
        public DuplicateSingletonException(string singletonName)
            : base(string.Format("An error ocurred, a {0} duplicate was found", singletonName))
        {
            Application.Quit();
        }
    }
}
