using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using RockPaperScissors.Models;


namespace RockPaperScissors.Pages
{
    public class computerGameModel : PageModel
    {
        [BindProperty]
        public gameSession? gameSession { get; set; }

        private List<String> _choices = Globals.choices;

        public void OnGet()
        {
        }

        public void OnPostChoice()
        {
            var rand = new Random();
            string computer1Choice = _choices[rand.Next(_choices.Count)];
            string computer2Choice = _choices[rand.Next(_choices.Count)];
            string result = string.Empty;

            Globals.selectedMode = "computer";
            Globals.computerChoice = computer1Choice;
            Globals.computer2Choice = computer2Choice;

            result = Globals.calculateWinner(computer1Choice, computer2Choice);

            Globals.lastResult = result;

            RedirectUser();

        }

        private void RedirectUser()
        {
            Response.Redirect("/Result");
        }
    }
}
