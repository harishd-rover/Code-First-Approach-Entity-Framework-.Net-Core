using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CodeFirst_EFCore.Models;


namespace CodeFirst_EFCore.Data
{
    class MyBookDBContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authours { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }



        public MyBookDBContext()
        {
        }

        public MyBookDBContext(DbContextOptions<MyBookDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BG1NBR1348;Database=BooksDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Property Configurations FLuent API

            modelBuilder.Entity<Book>()
            .Property(b => b.BookAge)
            .IsRequired() //[Required]
            .HasColumnName("Book_Age") //[Column("Book_Age")]
            .HasDefaultValue(2);

        }
    }
}
