using PapaBobsPizzaCH.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsPizzaCH.Domain
{
    public class OrderManager
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            orderDTO.OrderId = Guid.NewGuid();
            orderDTO.TotalCost = PizzaPriceManager.CalculateCost(orderDTO);
            Persistence.OrderRepository.CreateOrder(orderDTO);
        }
        public static List<DTO.OrderDTO> GetOrders()
        {
            //var db = new PapaBobDbEntities();
            //var orders = db.Orders.ToList();
            //var ordersDTO = convertToDTO(orders);
            //return ordersDTO;
            return Persistence.OrderRepository.GetOrders();
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
        public static void CompleteOrder (Guid orderId)
        {
            Persistence.OrderRepository.CompleteOrder(orderId);

        }
    }
}
