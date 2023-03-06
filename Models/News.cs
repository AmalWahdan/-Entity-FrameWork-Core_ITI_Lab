using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Models
{
    public class News
    {
      public int Id { get; set; }
        public string Title { get; set; }
        public string Bref { get; set; }
        public DateTime Datetime { get; set; }
        public int NewsDetailsId { get; set; }
        public int AuthorId { get; set; }
        public virtual NewsDetails NewsDetails { get; set; }
        public virtual Author Author { get; set; }

    }

}
