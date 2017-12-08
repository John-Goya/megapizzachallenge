using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsPizzaCH.Persistence
{
    public class PizzaPriceRepository
    {
        public static DTO.PizzaPriceDTO GetPizzaPrices()
        {
            var db = new PapaBobDbEntities();
            var prices = db.PizzaPrices.First();
            var dto = convertToDTO(prices);
            return dto;
        }

        private static DTO.PizzaPriceDTO convertToDTO(PizzaPrice pizzaPrice)
        {
            var dto = new DTO.PizzaPriceDTO();

            dto.LargeSizeCost = pizzaPrice.LargeSizeCost;
            dto.MediumSizeCost = pizzaPrice.MediumSizeCost;
            dto.SmallSizeCost = pizzaPrice.SmallSizeCost;
            dto.ThinCrustCost = pizzaPrice.ThinCrustCost;
            dto.ThickCrustCost = pizzaPrice.ThickCrustCost;
            dto.RegularCrustCost = pizzaPrice.RegularCrustCost;
            dto.SausageCost = pizzaPrice.SausageCost;
            dto.PepperoniCost = pizzaPrice.PepperoniCost;
            dto.OnionsCost = pizzaPrice.OnionsCost;
            dto.GreenPeppersCost = pizzaPrice.GreenPeppersCost;

            return dto;
        }

    }
}
