using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubimyCzytac.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }

        public List<Review> Reviews { get; set; }

        public Book()
        {
        }

        public Book(Book book)
        {
            this.Id = book.Id;
            this.Image = book.Image;
            this.Name = book.Name;
            this.Url = book.Url;
        }
    }
}