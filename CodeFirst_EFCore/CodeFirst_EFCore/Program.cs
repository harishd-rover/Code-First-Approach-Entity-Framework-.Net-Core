using CodeFirst_EFCore.Data;
using CodeFirst_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFirst_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllBooks();
            //AddNewBook();
            //GetBookbyID(1001);
            //UpdateBookByID(1004);
            //DeleteBookByID(1004);

            //AddNewCustOrder(9999);
            //DisplayAllCustWithOrders();
            //Disconnectedarchitecture();
        }

        private static void DisplayAllCustWithOrders()
        {
            var ctx = new MyBookDBContext();

            try
            {
                var customers = ctx.Customers.Include("Orders");

                foreach (var cust in customers)
                {
                    Console.WriteLine(cust.Name);
                    Console.WriteLine("--------------------");

                    foreach (var order in cust.Orders)
                    {
                        Console.WriteLine("Amount: " + order.Amount.ToString() + " OderId" + order.Order_ID);
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }

        }

        private static void AddNewCustOrder(int id)
        {
            var ctx = new MyBookDBContext();

            Order ord = new Order();
            ord.Order_ID = 13;
            ord.Amount = 10;
            ord.OrderDate = DateTime.Now;

            var oldcust = ctx.Customers.Where(b => b.ID == id).SingleOrDefault();

            if (oldcust == null)
            {
                Customer newcust = new Customer();
                newcust.ID = id;
                newcust.Name = "Ramesh";
                newcust.Age = 21;
                ord.cust = newcust;
            }

            else
            {
                ord.cust = oldcust;
            }

            try
            {
                ctx.Add(ord);
                ctx.SaveChanges();
                Console.WriteLine("New Order Placed... and Committed Changes!!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }

        }

        private static void GetAllBooks()
        {

            var ctx = new MyBookDBContext();


            var books = ctx.Books;
            foreach (var book in books)
            {
                Console.WriteLine(book.BookID + " | " + book.BookName + " | " + book.BookPrice);
            }
        }

        private static void DeleteBookByID(int Id)
        {
            var ctx = new MyBookDBContext();

            try
            {
                var book = ctx.Books.Where(b => b.BookID == Id).SingleOrDefault();

                ctx.Remove(book);

                ctx.SaveChanges();
                Console.WriteLine("Deleted Successfully!!!!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        private static void UpdateBookByID(int Id)
        {
            var ctx = new MyBookDBContext();

            try
            {
                var book = ctx.Books.Where(b => b.BookID == Id).SingleOrDefault();

                book.BookName = "Python 4.5";

                ctx.SaveChanges();
                Console.WriteLine("Updated Successfully!!!!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        private static void GetBookbyID(int id)
        {

            var ctx = new MyBookDBContext();


            try
            {
                var book = ctx.Books.Where(b => b.BookID == id).SingleOrDefault();
                Console.WriteLine(book.BookID + " | " + book.BookName + " | " + book.BookPrice);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }

        }

        private static void AddNewBook()
        {
            var ctx = new MyBookDBContext();

            Book book = new Book();
            book.BookID = 1010;
            book.BookName = "C++ 3.5";
            book.BookPrice = 150;



            try
            {
                ctx.Add(book);
                ctx.SaveChanges();
                Console.WriteLine("New Book Added and Committed Changes!!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }





        // Disconnected Architecture Example
        private static void Disconnectedarchitecture()
        {
            var ctx = new MyBookDBContext();

            var customer = ctx.Customers.Where(c => c.ID == 100).SingleOrDefault();

            ctx.Dispose();

            UpdateCustomerName(customer);
        }


        private static void UpdateCustomerName(Customer customer)
        {
            var ctx = new MyBookDBContext(); //new connection to db
            customer.Name = "Harish Rover";
            Console.WriteLine(ctx.Entry(customer).State.ToString());



            //ctx.Update<Customer>(customer);
            //OR
            //ctx.Update(customer);
            //OR
            //ctx.Customers.Update(customer);
            //OR
            ctx.Attach(customer).State = EntityState.Modified; //modifying existing customer


            //adding new customer
            Customer cust = new Customer();
            cust.Name = "Rajesh";
            cust.ID = 123;
            cust.Age = 46;

            ctx.Attach(cust).State = EntityState.Added;
            ctx.SaveChanges();
            Console.WriteLine("customer name is updated via disconnected mode");
        }
    }
}
