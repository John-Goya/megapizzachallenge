<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobsPizzaCH.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            position: relative;
            display: block;
            margin-top: 10px;
            margin-bottom: 10px;
            left: 0px;
            top: 0px;
        }
        .auto-style2 {
            margin-bottom: 15px;
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="page-header">
                <h2>Papa Bob's Pizza</h2>
                <p>Pizza to Code By</p>
            </div>

            <div class="form-group">
                <label>Size: </label>
                <asp:DropDownList ID="sizeDropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="recalculateTotalCost" AutoPostBack="true">
                    <asp:ListItem Text="Choose Pizza Size..." Selected="True" Value=""></asp:ListItem>
                    <asp:ListItem Text="Small (12 inch - $12)" Value="Small"></asp:ListItem>
                    <asp:ListItem Text="Medium (14 inch - $14)" Value="Medium"></asp:ListItem>
                    <asp:ListItem Text="Large (16 inch - $16)" Value="Large"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <label>Crust: </label>
                <asp:DropDownList ID="crustDropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="recalculateTotalCost" AutoPostBack="true">
                    <asp:ListItem Text="Choose Crust Type..." Selected="True" Value=""></asp:ListItem>
                    <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                    <asp:ListItem Text="Thin" Value="Thin"></asp:ListItem>
                    <asp:ListItem Text="Thick (+ $2)" Value="Thick"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="auto-style1">
                <label><asp:CheckBox ID="sausageCheckBox" runat="server" OnCheckedChanged="recalculateTotalCost" AutoPostBack="true" /> Sausage</label><br />
                <label><asp:CheckBox ID="pepperoniCheckBox" runat="server" OnCheckedChanged="recalculateTotalCost" AutoPostBack="true" /> Pepperoni</label><br />
                <label><asp:CheckBox ID="onionCheckBox" runat="server" OnCheckedChanged="recalculateTotalCost" AutoPostBack="true" /> Onions</label><br />
                <label><asp:CheckBox ID="greenPeppersCheckBox" runat="server" OnCheckedChanged="recalculateTotalCost" AutoPostBack="true" /> Green Peppers</label><br />
            </div>
            
            
            <h3>Deliver To: (all fields required)</h3>
            <div class="auto-style2">

            <label>Name:</label>
                <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Address:</label>
                <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Zip Code</label>
                <asp:TextBox ID="zipTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Phone: </label>
                <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control"></asp:TextBox>

            </div>

            <h3>Payment:</h3>

            <div class="radio"><label><asp:RadioButton ID="cashRadioButton" runat="server" GroupName="PaymentGroup" Checked="true" /> Cash </label></div>
            <div class="radio"><label><asp:RadioButton ID="creditRadioButton" runat="server" GroupName="PaymentGroup" /> Credit </label></div>

            <div class ="form-group"><asp:Button ID="orderButton" runat="server" Text="Order" OnClick="orderButton_Click" CssClass="btn btn-lg btn-primary"/></div>
            
            <br />
            
            <asp:Label ID="validationLabel" Text="" runat="server" Visible="False" CssClass="bg-danger"></asp:Label>

            <h3>Total Cost:</h3>
            <div class="form-group"><asp:Label ID="resultlLabel" runat="server"></asp:Label></div>

            <p>&nbsp;</p>
            <p>&nbsp;</p>
            
        </div>
    </form>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
