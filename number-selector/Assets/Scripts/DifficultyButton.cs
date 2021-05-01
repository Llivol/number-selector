public class DifficultyButton : FadeButtonController
{
    private int difficulty;

    private void Awake()
    {
        btnFade.onClick.AddListener(() => NumberManager.Instance.SetDifficulty(difficulty));
    }

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }
}
