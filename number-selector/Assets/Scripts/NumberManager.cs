using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberManager : MonoBehaviour
{
    [SerializeField] private NumberText txtNumber;
    [SerializeField] private FadeText txtDifficulty;
    [SerializeField] private DifficultyButton[] difficultyButtons;

    private int currentNumber;
    private int difficulty;

    private void Start()
    {
        txtDifficulty.Show();
        int buttonsLength = difficultyButtons.Length;
        for(int i = 0; i < buttonsLength; i++)
        {
            var button = difficultyButtons[i];
            button.SetDifficulty(i);
            button.Show();
            button.GetComponent<FadeButton>().onClick.AddListener(() => onSelectDifficulty(button.GetDifficulty()));
        }
    }

    private void onSelectDifficulty(int difficulty)
    {
        int buttonsLength = difficultyButtons.Length;
        for (int i = 0; i < buttonsLength; i++) difficultyButtons[i].Hide();
        txtDifficulty.Hide();

        this.difficulty = difficulty;

        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        while (true)
        {
            yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS);

            generateNumber();
            txtNumber.SetNumberToText(currentNumber);
            txtNumber.Show();

            yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS * 2);

            txtNumber.Hide();

            yield return new WaitForSeconds(Config.FADE_TIME_IN_SECONDS);

            Debug.Log("now show buttons");
        }
    }

    private void generateNumber()
    {
        Debug.Log(difficulty);
        currentNumber = Random.Range(Config.MIN_VALUE, Config.MAX_VALUES[difficulty]);
    }
}
