using Cibertec.UnitOfWork;
using System;
using Cibertec.Repositories.Northwind;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.Repositories.EntityFramework.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        private string v;

        public NorthwindUnitOfWork(DbContext context)
        {
            Customers = new CustomerRepository(context);
        }

        public NorthwindUnitOfWork(string v)
        {
            this.v = v;
        }

        public ICustomerRepository Customers { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IOrderItemRepository OrderItems { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }
    }
}
