//associate a Movie with 1 or more collections
//AND order Movies within a Collection

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProApp.Models.Database
{
    public class MovieCollection
    {
        public int Id { get; set; }     //PK
        public int CollectionId { get; set; }   //FK
        public int MovieId { get; set; }        //FK

        public int Order { get; set; }

        public Collection Collection { get; set; }
        public Movie Movie { get; set; }
    }
}
