using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Program
    {


       
        static void Main(string[] args)
        {
            List<Order> order= new List<Order>();

            Order o1 = new Order(2, "56465154");
            Order o2 = new Order(1, "12478337");
            Order o3 = new Order(2, "79534578");

            order.Add(o1);
            order.Add(o2);
            order.Add(o3);

            OrderType orderType = new OrderType(order);
            Console.WriteLine("Виберіть тип замовлення \n 1-Фаст-фуд \n 2-Суші");
            int i = Convert.ToInt32( Console.ReadLine());
            if(i == 1)
            {
                orderType.fastFood();
            }
            else if (i == 2)
            {
                orderType.Sushi();
            }

            Console.ReadLine();
        }
    }
    class Order
    {
        public int orderCount;
        public string id;
        public Order(int orderCount, string id)
        {
            this.orderCount = orderCount;
            this.id = id;
        }
    }
    class OrderType
    {
        List<Order> order;
        public OrderType(List<Order> order)
        {
            this.order = order;
        }

        public void fastFood()
        {
            foreach (Order o in order)
            {
                Console.WriteLine($"{o.orderCount} {o.id}");
            }
        }
        public void Sushi()
        {
            string a="";
            foreach (Order o in order)
            {
               a+=($"{o.orderCount} ");
            }
            foreach (Order o in order)
            {
                a += ($" {o.id}");
            }
            Console.WriteLine(a);
        }
    }


}
