public class DifficultyButton : FadeButtonController
{
    private int difficulty;

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }
}
