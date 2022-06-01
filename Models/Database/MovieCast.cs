using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProApp.Models.Database
{
    public class MovieCast
    {
        public int Id { get; set; }     //PK
        public int MovieId { get; set; }    //FK

        public int CastID { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public string ImageUrl { get; set; }

        //holds entire Movie record pointed to by FK MovieId
        public Movie Movie { get; set; }
    }
}
