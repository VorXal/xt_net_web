using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._3
{
    public enum StatusOrder
    {
        None,
        Ready,
        Cooking,
        Done
    }
    
    public class Order
    {
        private int _id;
        public string Username { get; private set; }

        private Pizza[] Pizzas;

        private StatusOrder status;

        public Order(int id, string username, Pizza[] pizzas){
            _id = id;
            Username = username;
            Pizzas = pizzas;
            status = StatusOrder.None;
        }

        public int GetId() => _id;

        public StatusOrder GetStatusOrder() => status;

        public void ChangeStatus(Order order)
        {
            if(order.status == StatusOrder.None)
            {
                order.status = StatusOrder.Cooking;
            }
            else if(order.status == StatusOrder.Cooking)
            {
                order.status = StatusOrder.Done;
            }        
        }
        public override string ToString()
        {
            string output = $"Order: {_id}  \n\tName: {Username} ";
            string pizzasNames = "";
            int cost = 0;
            foreach(var item in Pizzas)
            {
                pizzasNames = pizzasNames.Insert(pizzasNames.Length, $" \n\t{item} ");
                cost += item.Cost;   
            }

            output = output.Insert(output.Length, $"{pizzasNames} \n\tCost: {cost} \n\tStatus: {status}" +
                $"\n --------------------");
            return output;
        }
    }
}
