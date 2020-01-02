using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Shop
{
    class Customers
    {
        [Key]
        public int customer_id
        {
            get;
            set;
        }
        public string first_name
        {
            get;
            set;
        }
        public string last_name
        {
            get;
            set;
        }
    }
    class CustomersContext : DbContext
    {
        public CustomersContext()
            : base("DbConnection")
        { }
        public DbSet<Customers> Customer { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (CustomersContext db = new CustomersContext())
            {
                // создаем два объекта User
                Customers customer1 = new Customers { customer_id = 1, first_name = "Albus", last_name = "Dumbledore" };
                Customers customer2 = new Customers { customer_id = 2, first_name = "Triss", last_name = "Merigold" };

                // добавляем их в бд
                db.Customer.Add(customer1);
                db.Customer.Add(customer2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var customers = db.Customer;
                Console.WriteLine("Список объектов:");
                foreach (Customers u in customers)
                {
                    Console.WriteLine("{0}.{1} {2}", u.customer_id, u.first_name, u.last_name);
                }
            }
        }
    }
    
}
