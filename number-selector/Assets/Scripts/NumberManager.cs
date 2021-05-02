using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    public static NumberManager Instance = null;

    [SerializeField] private NumberText txtNumber;
    [SerializeField] private FadeText txtDifficulty;
    [SerializeField] private Text txtScore;
    [SerializeField] private DifficultyButton[] difficultyButtons;
    [SerializeField] private NumberButton[] numberButtons;

    private int correctCount = 0;
    private int wrongCount = 0;
    private int currentNumber;
    private int currentButtonIdx;
    private int difficulty;
    private int lives;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { throw new DuplicateSingletonException("NumberManager"); }

        updateScore();

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

        StartCoroutine(startRound());
    }

    public void OnClickCorrect()
    {
        correctCount++;
        updateScore();

        StartCoroutine(finishRound());
    }

    public void OnClickError()
    {
        wrongCount++;
        updateScore();

        lives--;
        if (lives == 0) StartCoroutine(finishRound());
    }

    private IEnumerator startRound()
    {
        yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS);

        lives = Config.LIVES_PER_ROUND;
        currentNumber = generateNumber();
        txtNumber.SetNumberToText(currentNumber);
        txtNumber.Show();

        yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS * 2);

        txtNumber.Hide();

        yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS);

        showNumberButtons();
    }

    private IEnumerator finishRound()
    {
        int buttonsLength = numberButtons.Length;
        for (int i = 0; i < buttonsLength; i++)
        {
            var button = numberButtons[i];
            if (i == currentButtonIdx)
            {
                numberButtons[currentButtonIdx].SetInteractable(false);
                numberButtons[currentButtonIdx].SetCorrectColor();
            }
            else if (button.IsShown()) button.Hide();
        }

        yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS);

        numberButtons[currentButtonIdx].Hide();

        StartCoroutine(startRound());
    }

    private int generateNumber()
    {
        return Random.Range(Config.MIN_NUMBER, Config.MAX_NUMBER[difficulty]);
    }

    private void showNumberButtons()
    {
        int buttonsLength = numberButtons.Length;
        currentButtonIdx = Random.Range(0, buttonsLength - 1);

        for (int i = 0; i < buttonsLength; i++)
        {
            var button = numberButtons[i];

            button.ResetColor();

            if (i == currentButtonIdx) button.SetNumber(currentNumber);
            else
            {
                int errorNumber;

                do errorNumber = generateNumber();
                while (!isUnique(errorNumber, i));

                button.SetNumber(errorNumber);
            }

            button.Show();
        }
    }

    private bool isUnique(int newNumber, int currentIdx)
    {
        if (newNumber == currentNumber) return false;
        
        for (int i = 0; i < currentIdx; i++) if (newNumber == numberButtons[i].GetNumber()) return false;

        return true;
    }

    private void updateScore()
    {
        txtScore.text = string.Format(Config.STRING_FORMAT_SCORE, correctCount, wrongCount);
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
