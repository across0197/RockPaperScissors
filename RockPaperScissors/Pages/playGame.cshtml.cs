using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using RockPaperScissors.Models;


namespace RockPaperScissors.Pages
{
    public class playGameModel : PageModel
    {
        [BindProperty]
        public gameSession? gameSession { get; set; }

        private List<string> _choices = Globals.choices;

        public void OnGet()
        {
        }

        public void OnPostChoice()
        {
            if (HttpContext.Session.Keys.Contains("noOfUserGames"))
            {
                int noOfUserGames = (int)HttpContext.Session.GetInt32("noOfUserGames") + 1;
                HttpContext.Session.SetInt32("noOfUserGames", noOfUserGames);
            }
            else
            {
                HttpContext.Session.SetInt32("noOfUserGames", 1);
            }

            var rand = new Random();
            string userChoice = gameSession.userChoice;
            string computerChoice = _choices[rand.Next(_choices.Count)];
            string result = string.Empty;

            Globals.selectedMode = "user";
            Globals.computerChoice = computerChoice;

            result = Globals.calculateWinner(userChoice, computerChoice);

            Globals.lastResult = result; 

            addResultToSession(Globals.lastResult);

        }

        private void addResultToSession(string result)
        {

            if (result == Globals.winResult)
            {
                if (HttpContext.Session.Keys.Contains("noOfUserWins"))
                {
                    int noOfUserWins = (int)HttpContext.Session.GetInt32("noOfUserWins") + 1;
                    HttpContext.Session.SetInt32("noOfUserWins", noOfUserWins);
                }
                else
                {
                    HttpContext.Session.SetInt32("noOfUserWins", 1);
                }
            }
            else
            {
                HttpContext.Session.SetInt32("noOfUserWins", 0);
            }

            RedirectUser();
        }

        private void RedirectUser()
        {
            Response.Redirect("/Result");
        }
    }
}
