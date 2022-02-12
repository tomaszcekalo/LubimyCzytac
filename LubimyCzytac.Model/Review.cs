using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubimyCzytac.Model
{
    public class Review
    {
        [Key]
        public long BookId { get; set; }

        [Key]
        public long UserId { get; set; }

        //public DateOnly Date { get; set; }
        public DateTime Date { get; set; }

        public int RatingValue { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}