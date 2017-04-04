using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntityFrameworkModelFirst
{
    public partial class Default : System.Web.UI.Page
    {

        //In this field the info of the db is saved
        Model1Container dbContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbContext = new Model1Container();
            ListView1.InsertItemPosition = InsertItemPosition.LastItem;
        }




        // Show all the customers
        public IQueryable<Customer> GetCustomers()
        {
            // Use a LINQ Querry to get the info
            return dbContext.Customers.AsQueryable<Customer>(); //lazy loading
        }

        // Edit Customers details
        public void EditCustomer(int? customerId)
        {
            Customer customer = dbContext.Customers.FirstOrDefault(c => c.CustomerID == customerId);

            if (customer != null && TryUpdateModel<Customer>(customer))
            {
                // With a help of EF, update the tables
                dbContext.Entry<Customer>(customer).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        // Delete a customer
        public void DeleteCustomer()
        {
            Customer customer = new Customer();

            if (TryUpdateModel<Customer>(customer))
            {
                dbContext.Entry<Customer>(customer).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        // Inserts a new Customer
        public void InsertCustomer()
        {
            Customer customer = new Customer();

            if (TryUpdateModel<Customer>(customer))
            {
                dbContext.Entry<Customer>(customer).State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }
    }
}