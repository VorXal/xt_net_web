using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._3
{

    class Pizzeria
    {
        public List<Order> Orders { get; private set; }

        public event Action<Order> OnCreate;
        public event Action<Order> OnDone;
        public event Action<Order> OnGet;

        
        public Pizzeria()
        {
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            OnCreate += ChangeOrderStatus;
            OnCreate(order);
            Orders.Add(order);
            OnCreate -= ChangeOrderStatus;
        }

        public void FinishOrder(Order order)
        {
            OnGet += RemoveOrder;
            OnGet(order);
        }
        private void RemoveOrder(Order order)
        {
            
            
            OnGet -= RemoveOrder;
            Orders.Remove(order);
        }

        public void ReadyOrder(Order order)
        {
            OnDone += ChangeOrderStatus;
            OnDone(order);
            OnDone -= ChangeOrderStatus;
        }

        public void ChangeOrderStatus(Order order)
        {
            order.ChangeStatus(order);
        }

        public void PrintOrders()
        {
            foreach(var item in Orders)
            {
                Console.WriteLine(item);
            }
            
        }

        //todo  compliteorder(id) 
    }
}
