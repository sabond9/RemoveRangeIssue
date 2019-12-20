using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public interface IFoo2
    {
        Task Update(Order order);
    }

    public class Foo2 : IFoo2
    {
        private MyContext context;

        public Foo2(MyContext context)
        {
            this.context = context;
        }

        public async Task Update(Order order)
        {
            context.Orders.RemoveRange(context.Orders.Where(r => r.CustomerID == 100));
            context.Orders.RemoveRange(context.Orders.Where(r => r.CustomerID == 120));
            order.EmployeeID = 2;
            context.Update(order);
            await context.SaveChangesAsync();
        }
    }
}
