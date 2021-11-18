1. create a new console project by name codefirst_sample
--------installl all 5 entity packages---Core, Design, Relational,SQLServer, Tools 
2. remove console.writeline(gvxz,vngv) from main method
3. create a folder by name models
4 inside the model folder, create a file (book.cs)
5.

public class book
{
bookid, use dataannotations --no identity--explicit give value
bookname
price
}


example: 
    class Book
    {
        [Key]      // data annotations

        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookPrice { get; set; }
    }
}



6. create a folder called data
7. Inside the data folder, create dbcntext.cs file
8. Inside dbcntext.cs file


using Microsoft.EntityFrameworkCore;
using CodeFirst_EFCore.Models;


	   class MyDBContext : DbContext
    {

        public virtual DbSet<Book> Books { get; set; }


        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BG1NBR1348;Database=new1;Trusted_Connection=True;");
            }
        }

    }

9. add-migration initial
10. update-database // this will create a table by name books


Main method
{
addnewbook();
GetallBooks();
UpdateBookbyID();
DeleteBookByID();

}

When We Do Some Changes in Models We need to do Migrations

When we want to create new Table or New Model we need to include that class in Context Class


We Have to use ContainerEntities as context for Disconnected Architecture.