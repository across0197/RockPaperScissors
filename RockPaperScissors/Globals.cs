namespace RockPaperScissors
{
    public static class Globals
    {
        public static string selectedMode = string.Empty;

        public static List<string> choices = new List<string>() { "rock", "paper", "scissors" };

        public static string winResult = "win";
        public static string drawResult = "draw";
        public static string loseResult = "lose";

        public static string lastResult = string.Empty;

        public static string winningUser = string.Empty;

        public static string computerChoice = string.Empty;
        public static string computer2Choice = string.Empty;

        // global methods

        public static string calculateWinner(string player1choice, string player2choice)
        {
            string result = string.Empty;


            if (player1choice == player2choice)
            {
                result = drawResult;
            }
            else
            {
                if (player1choice == "rock")
                {
                    if (player2choice == "paper")
                    {
                        result = loseResult;
                    }
                    else if (player2choice == "scissors")
                    {
                        result = winResult;
                    }
                }
                else if (player1choice == "paper")
                {
                    if (player2choice == "rock")
                    {
                        result = winResult;
                    }
                    else if (player2choice == "scissors")
                    {
                        result = loseResult;
                    }
                }
                else if (player1choice == "scissors")
                {
                    if (player2choice == "paper")
                    {
                        result = winResult;
                    }
                    else if (player2choice == "rock")
                    {
                        result = loseResult;
                    }
                }
            }

            return result;
        }
    }
}
