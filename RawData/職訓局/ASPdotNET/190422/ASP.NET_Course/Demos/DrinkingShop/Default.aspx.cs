using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    DrinkDataSet ds;

    void DBInit()
    {
        if (Session["ds"] == null)
        {
            ds = new DrinkDataSet();
            DrinkDataSetTableAdapters.ProductsTableAdapter da = new DrinkDataSetTableAdapters.ProductsTableAdapter();
            da.Fill(ds.Products);
            ds.OrderDetails.AddOrderDetailsRow(0, "請選擇", 1, "去冰", "少糖", 0);
            Session["ds"] = ds;
        }
        else
            ds = (DrinkDataSet)Session["ds"];
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DBInit();
        if (!this.IsPostBack)
        {
            OrderGridView.EditIndex = 0;
            OrderGridView.DataSource = ds.OrderDetails;
            OrderGridView.DataBind();
        }
    }
    protected void OrderGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ds.OrderDetails[e.RowIndex].ProductID = Convert.ToInt32(e.NewValues["ProductID"]);
        ds.OrderDetails[e.RowIndex].ProductName = 
          ds.Products.FindByProductID(ds.OrderDetails[e.RowIndex].ProductID).ProductName;
        ds.OrderDetails[e.RowIndex].Price =
            ds.Products.FindByProductID(ds.OrderDetails[e.RowIndex].ProductID).Price;

        ds.OrderDetails[e.RowIndex].Quantity = Convert.ToInt32(e.NewValues["Quantity"]);
        ds.OrderDetails[e.RowIndex].Ice = e.NewValues["Ice"].ToString();
        ds.OrderDetails[e.RowIndex].Sugar = e.NewValues["Sugar"].ToString();

        if (e.RowIndex == OrderGridView.Rows.Count - 1)
        {
            ds.OrderDetails.AddOrderDetailsRow(0, "請選擇", 1, "去冰", "少糖", 0);
        }
        OrderGridView.EditIndex = ds.OrderDetails.Rows.Count - 1;
        OrderGridView.DataSource = ds.OrderDetails;
        OrderGridView.DataBind();

    }
    protected void OrderGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        OrderGridView.EditIndex = -1;
        OrderGridView.DataSource = ds.OrderDetails;
        OrderGridView.DataBind();
    }
    protected void OrderGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // OrderGridView.Columns[4].Visible = false;
        OrderGridView.EditIndex = e.NewEditIndex;
        OrderGridView.DataSource = ds.OrderDetails;
        OrderGridView.DataBind();
    }
    protected void OrderButton_Click(object sender, EventArgs e)
    {
        string sOrderID = DateTime.Now.ToString("yyyyMMddhhmmss") +
                    CustomerNameTextBox.Text.Substring(0, 1);

        Session["orderid"] = sOrderID;
        OrdersSqlDataSource.Insert();

        foreach (DrinkDataSet.OrderDetailsRow dr in ds.OrderDetails)
        {
            if (dr.ProductName == "請選擇")
                continue;
            OrderDetailsSqlDataSource.InsertParameters["OrderID"].DefaultValue = sOrderID;
            OrderDetailsSqlDataSource.InsertParameters["ProductID"].DefaultValue = dr.ProductID.ToString();
            OrderDetailsSqlDataSource.InsertParameters["ProductName"].DefaultValue = dr.ProductName;
            OrderDetailsSqlDataSource.InsertParameters["Quantity"].DefaultValue = dr.Quantity.ToString();
            OrderDetailsSqlDataSource.InsertParameters["Price"].DefaultValue = dr.Price.ToString();
            OrderDetailsSqlDataSource.InsertParameters["Ice"].DefaultValue = dr.Ice;
            OrderDetailsSqlDataSource.InsertParameters["Sugar"].DefaultValue = dr.Sugar;
            OrderDetailsSqlDataSource.Insert();
        }

    }
    protected void OrderGridView_DataBound(object sender, EventArgs e)
    {
        decimal Total = 0;
        foreach (DrinkDataSet.OrderDetailsRow dr in ds.OrderDetails)
        {
            Total += (dr.Price * dr.Quantity);
        }
        TotalPriceLabel.Text = Total.ToString();
    }
}
