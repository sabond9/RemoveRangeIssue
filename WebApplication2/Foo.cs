using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public interface IFoo
    {
        Task Update(Order order);
    }

    public class Foo : IFoo
    {
        private MyContext context;

        public Foo(MyContext context)
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
