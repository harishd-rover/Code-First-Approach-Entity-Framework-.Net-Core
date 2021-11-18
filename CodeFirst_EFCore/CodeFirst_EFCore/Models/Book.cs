using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst_EFCore.Models
{
    class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookPrice { get; set; }
        public string AuthorName { get; set; }
        public int BookAge { get; set; }
    }
}
