using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        MovieDatabase movieDatabase = new MovieDatabase();

        public List<Movie> Movies;

        public void OnGet()
        {
            Movies = movieDatabase.All;
        }

        public void OnPost(string search, List<string> rating)
        {
            if(search != null&& rating.Count != 0){
                Movies = movieDatabase.SearchAndFilter(search,rating);
            }
            else if(rating.Count != 0){
                Movies = movieDatabase.Filter(rating);
            }
            else if(search != null){
                Movies = movieDatabase.Search(search);
            }
            else{
                Movies = movieDatabase.All;
            }
        }
    }
}
