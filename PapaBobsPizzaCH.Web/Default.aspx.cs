using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobsPizzaCH.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if (!textBoxDataIsValid())
            {
                return;
            }
            var orderDTO = buildOrder();

            Domain.OrderManager.CreateOrder(orderDTO);
            Response.Redirect("Success.aspx");

            //Domain.OrderManager.CreateOrder();
        }

        private bool textBoxDataIsValid()
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError(" name");
                return false;
            }
            else if (addressTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError("n address");
                return false;
            }
            else if (zipTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError(" zip code");
                return false;
            }
            else if (phoneTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError(" phone number");
                return false;
            }
            else
                return true;
        }

        private DTO.Enums.PaymentType determinePayment()
        {           
            DTO.Enums.PaymentType paymentMethod;
            if (cashRadioButton.Checked)
            {
                paymentMethod = DTO.Enums.PaymentType.Cash;
            }
            else if (true)
            {
                paymentMethod = DTO.Enums.PaymentType.Credit;
            }
            else
            {
                throw new Exception("Could not determine Payment type.");
            }                        
            return paymentMethod;
        }

        private DTO.Enums.SizeType determineSize()
        {
            DTO.Enums.SizeType size;

            if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
            {
                throw new Exception("Could not determine Pizza size.");
            }
            return size;
        }

        private DTO.Enums.CrustType determineCrust()
        {
            DTO.Enums.CrustType crust;

            if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
            {
                throw new Exception("Could not determine Pizza crust.");
            }
            return crust;
        }

        private void textBoxValidationError(string errorType)
        {
            string errorMessage = "";
            errorMessage += String.Format("<strong>Please enter a{0}. </strong>", errorType);
            validationLabel.Text = errorMessage;
            validationLabel.Visible = true;
        }

        private DTO.OrderDTO buildOrder()
        {
            PapaBobsPizzaCH.DTO.OrderDTO orderDTO = new DTO.OrderDTO();

            orderDTO.Size = determineSize();
            orderDTO.Crust = determineCrust();
            orderDTO.Sausage = sausageCheckBox.Checked;
            orderDTO.Pepperoni = pepperoniCheckBox.Checked;
            orderDTO.Onions = onionCheckBox.Checked;
            orderDTO.GreenPeppers = greenPeppersCheckBox.Checked;
            orderDTO.Name = nameTextBox.Text;
            orderDTO.Address = addressTextBox.Text;
            orderDTO.ZipCode = zipTextBox.Text;
            orderDTO.Phone = phoneTextBox.Text;
            orderDTO.PaymentType = determinePayment();
            orderDTO.TotalCost = 0.0M;

            return orderDTO;
        }

        protected void recalculateTotalCost(object sender, EventArgs e)
        {
            if (sizeDropDownList.SelectedValue == String.Empty)
                {
                //textBoxValidationError(" pizza size.");
                return;
                }
            if (crustDropDownList.SelectedValue == String.Empty)
                {
                //textBoxValidationError(" pizza crust.");
                return;
                }
            var order = buildOrder();

            decimal cost = Domain.PizzaPriceManager.CalculateCost(order);
            resultlLabel.Text = string.Format("<h3>{0:C}</h3>", cost);
        }
    }
}