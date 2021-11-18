using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst_EFCore.Models
{
    [Table("Auth")]
    class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorID { get; set; }

        [Required, Column("AuthorName")]
        public string AuthName { get; set; }

        [StringLength(25)]
        public string BookName { get; set; }
    }
}
