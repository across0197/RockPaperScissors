using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using RockPaperScissors.Models;

namespace RockPaperScissors.Pages
{
    public class StatisticsModel : PageModel
    {
        public int noOfGamesPlayed = 0;
        public int noOfUserWins = 0;
        public double winPercentage = 0;

        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("noOfUserGames") != null)
            {
                noOfGamesPlayed = (int)HttpContext.Session.GetInt32("noOfUserGames");
            }

            if (HttpContext.Session.GetInt32("noOfUserWins") != null)
            {
                noOfUserWins = (int)HttpContext.Session.GetInt32("noOfUserWins");
            }

            if (noOfUserWins == 0)
            {
                winPercentage = 0;
            }
            else
            {
                winPercentage = Math.Round(((double)noOfUserWins / (double)noOfGamesPlayed) * 100);
            }
            
        }
    }
}
