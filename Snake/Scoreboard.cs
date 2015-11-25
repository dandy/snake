namespace Snake
{
    public class Scoreboard
    {
        public int CurrentScore { get; set; }

        public void Score()
        {
            CurrentScore = 0;
        }

        public void AddScore()
        {
            CurrentScore = CurrentScore + 10;
        }

    }
}
