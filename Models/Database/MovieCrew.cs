using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProApp.Models.Database
{
    public class MovieCrew
    {
        public int Id { get; set; }     //PK
        public int MovieId { get; set; }        //FK

        public int CrewID { get; set; }     //FK (TMDB's Crew table)
        public string Department { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string ImageUrl { get; set; }

        //holds the entire record pointed to by the MovieId
        public Movie Movie { get; set; }
    }
}
