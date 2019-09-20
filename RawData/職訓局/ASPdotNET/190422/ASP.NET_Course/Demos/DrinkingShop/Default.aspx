<%@ Page Title="首頁" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table class="style1">
        <tr>
            <td width="65">
                客戶名稱:</td>
            <td>
                <asp:TextBox ID="CustomerNameTextBox" runat="server" Width="200px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="CustomerNameTextBox" ErrorMessage="請輸入客戶名稱"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="65">
                電話號碼:</td>
            <td>
                <asp:TextBox ID="PhoneTextBox" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="PhoneTextBox" ErrorMessage="請輸入電話號碼"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="65">
                備註事項:</td>
            <td>
                <asp:TextBox ID="MemoTextBox" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" width="65">
                總價:</td>
            <td>
                <asp:Label ID="TotalPriceLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <p>


        <asp:GridView ID="OrderGridView" runat="server" AutoGenerateColumns="False" 
            onrowcancelingedit="OrderGridView_RowCancelingEdit" 
            onrowediting="OrderGridView_RowEditing" 
            onrowupdating="OrderGridView_RowUpdating" CellPadding="4" 
            ForeColor="#333333" GridLines="None" ondatabound="OrderGridView_DataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="產品名稱">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList3" runat="server" 
                            DataSourceID="ProductSqlDataSource" DataTextField="ProductNamePrice" 
                            DataValueField="ProductID" SelectedValue='<%# Bind("ProductID") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="ProductSqlDataSource" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:DrinkDBConnectionString %>" 
                            
                            SelectCommand="select 0 as ProductID, '請選擇' as ProductNamePrice
union
SELECT ProductID, ProductName + ' (' + Convert(varchar(20), Price) + '元)' as ProductNamePrice FROM Products">
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Quantity" HeaderText="數量" />
                <asp:TemplateField HeaderText="冷/熱">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            SelectedValue='<%# Bind("Ice") %>'>
                            <asp:ListItem>去冰</asp:ListItem>
                            <asp:ListItem>少冰</asp:ListItem>
                            <asp:ListItem>正常</asp:ListItem>
                            <asp:ListItem>溫</asp:ListItem>
                            <asp:ListItem>熱</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Ice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="糖量">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" 
                            SelectedValue='<%# Bind("Sugar") %>'>
                            <asp:ListItem>無糖</asp:ListItem>
                            <asp:ListItem>少糖</asp:ListItem>
                            <asp:ListItem>半糖</asp:ListItem>
                            <asp:ListItem>正常</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Sugar") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="單價">
                    <EditItemTemplate>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" EditText="我要修改" UpdateText="確認單筆訂購內容" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>


    </p>
    <p>


        &nbsp;</p>
    <p>


        <asp:Button ID="OrderButton" runat="server" onclick="OrderButton_Click" 
            Text="確認訂購" Width="120px" />


    </p>
    <p>


        <asp:SqlDataSource ID="OrdersSqlDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DrinkDBConnectionString %>" 
            DeleteCommand="DELETE FROM [Orders] WHERE [OrderID] = @OrderID" 
            InsertCommand="INSERT INTO [Orders] ([OrderID], [CustomerName], [Phone], [memo]) VALUES (@OrderID, @CustomerName, @Phone, @memo)" 
            SelectCommand="SELECT [OrderID], [CustomerName], [Phone], [memo] FROM [Orders]" 
            UpdateCommand="UPDATE [Orders] SET [CustomerName] = @CustomerName, [Phone] = @Phone, [memo] = @memo WHERE [OrderID] = @OrderID">
            <DeleteParameters>
                <asp:Parameter Name="OrderID" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:SessionParameter Name="OrderID" SessionField="orderid" Type="String" />
                <asp:ControlParameter ControlID="CustomerNameTextBox" Name="CustomerName" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="PhoneTextBox" Name="Phone" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="MemoTextBox" Name="memo" PropertyName="Text" 
                    Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="CustomerName" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="memo" Type="String" />
                <asp:Parameter Name="OrderID" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>


    </p>
    <p>


        <asp:SqlDataSource ID="OrderDetailsSqlDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DrinkDBConnectionString %>" 
            DeleteCommand="DELETE FROM [OrderDetails] WHERE [OrderDetailsID] = @OrderDetailsID" 
            InsertCommand="INSERT INTO [OrderDetails] ([OrderID], [ProductID], [ProductName], [Price], [Quantity], [Ice], [Sugar]) VALUES (@OrderID, @ProductID, @ProductName, @Price, @Quantity, @Ice, @Sugar)" 
            SelectCommand="SELECT [OrderDetailsID], [OrderID], [ProductID], [ProductName], [Price], [Quantity], [Ice], [Sugar] FROM [OrderDetails]" 
            UpdateCommand="UPDATE [OrderDetails] SET [OrderID] = @OrderID, [ProductID] = @ProductID, [ProductName] = @ProductName, [Price] = @Price, [Quantity] = @Quantity, [Ice] = @Ice, [Sugar] = @Sugar WHERE [OrderDetailsID] = @OrderDetailsID">
            <DeleteParameters>
                <asp:Parameter Name="OrderDetailsID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="OrderID" Type="String" />
                <asp:Parameter Name="ProductID" Type="Int32" />
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="Price" Type="Decimal" />
                <asp:Parameter Name="Quantity" Type="Int32" />
                <asp:Parameter Name="Ice" Type="String" />
                <asp:Parameter Name="Sugar" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="OrderID" Type="String" />
                <asp:Parameter Name="ProductID" Type="Int32" />
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="Price" Type="Decimal" />
                <asp:Parameter Name="Quantity" Type="Int32" />
                <asp:Parameter Name="Ice" Type="String" />
                <asp:Parameter Name="Sugar" Type="String" />
                <asp:Parameter Name="OrderDetailsID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>


    </p>
    <p>


    </p>
</asp:Content>
