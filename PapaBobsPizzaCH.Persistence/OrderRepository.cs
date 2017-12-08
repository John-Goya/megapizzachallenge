using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PapaBobsPizzaCH.DTO;

namespace PapaBobsPizzaCH.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            var db = new PapaBobDbEntities();

            var order = convertToEntity(orderDTO);
            db.Orders.Add(order);
            db.SaveChanges();
        }

        private static Order convertToEntity(OrderDTO orderDTO)
        {
            var order = new Order();

            order.OrderId = orderDTO.OrderId;
            order.Size = orderDTO.Size;
            order.Crust = orderDTO.Crust;
            order.Sausage = orderDTO.Sausage;
            order.Pepperoni = orderDTO.Pepperoni;
            order.Onions = orderDTO.Onions;
            order.GreenPeppers = orderDTO.GreenPeppers;
            order.Name = orderDTO.Name;
            order.Address = orderDTO.Address;
            order.ZipCode = orderDTO.ZipCode;
            order.Phone = orderDTO.Phone;
            order.TotalCost = orderDTO.TotalCost;
            order.PaymentType = orderDTO.PaymentType;
            order.Completed = orderDTO.Completed;

            return order;
        }

        public static List<DTO.OrderDTO> GetOrders()
        {
            var db = new PapaBobDbEntities();
            var orders = db.Orders.Where(p => p .Completed == false).ToList();
            var ordersDTO = convertToDTO(orders);
            return ordersDTO;
        }

        private static List<DTO.OrderDTO> convertToDTO(List<Order> orders)
        {
            var ordersDTO = new List<DTO.OrderDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new DTO.OrderDTO();

                orderDTO.OrderId = order.OrderId;
                orderDTO.Size = order.Size;
                orderDTO.Crust = order.Crust;
                orderDTO.Sausage = order.Sausage;
                orderDTO.Pepperoni = order.Pepperoni;
                orderDTO.Onions = order.Onions;
                orderDTO.GreenPeppers = order.GreenPeppers;
                orderDTO.Name = order.Name;
                orderDTO.Address = order.Address;
                orderDTO.ZipCode = order.ZipCode;
                orderDTO.Phone = order.Phone;
                orderDTO.PaymentType = order.PaymentType;
                orderDTO.TotalCost = order.TotalCost;
                orderDTO.Completed = order.Completed;

                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;
        }

        public static void CompleteOrder(Guid orderId)
        {
            var db = new PapaBobDbEntities();
            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderId);
            order.Completed = true;
            db.SaveChanges();
        }
    }
}
