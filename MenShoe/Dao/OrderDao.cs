using MenShoe.Areas.Admin.Models;
using MenShoe.EF;
using MenShoe.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MenShoe.Dao
{
    public class OrderDao
    {
        public long getLastID()
        {
            string query = "SELECT TOP 1 * FROM dbo.[ORDER] ORDER BY OrderID DESC";
            var id = DataProvider.Instance.ConvertToList<Order>( DataProvider.Instance.ExcuteQuery(query))[0];
            return id.OrderID;
        }

        public List<Int64> lstIdPruductSelling()
        {
            List<Int64> lst = new List<Int64>();
            string query = "Select distinct ProductID From OrderDetail " +
                "where EXISTS (Select top 10 ProductID, Count(ProductID) as Quanlity " +
                "From OrderDetail Group By ProductID " +
                "Order by Quanlity Desc)";
            var id = DataProvider.Instance.ConvertToList<Int64>(DataProvider.Instance.ExcuteQuery(query));
            return id;
        }


        public List<double> lstAmount(List<Order> lstOd)
        {
            List<double> lst = new List<double>();
            
            for(int i = 0; i < lstOd.Count(); i++)
            {
                List<OrderDetails> lstOrderDetail = new List<OrderDetails>();
                string OrderID = lstOd[i].OrderID.ToString();
                lstOrderDetail = db.OrderDetails.Where(o => o.OrderID.ToString() == OrderID).ToList();
                double amount = 0;
                for (int j = 0; j < lstOrderDetail.Count(); j++)
                {
                    amount += (double)(lstOrderDetail[j].Quantity * lstOrderDetail[j].prices);
                    
                }
                lst.Add(amount);
            }
            return lst;
        }

        public List<CartView> getListCartOrder(string ID)
        {
            if(ID != null)
            {
                string query = "SELECT dbo.Product.ProductID, dbo.Product.Name, dbo.Sizes.Number, dbo.Colors.NameColor, dbo.[Product].Image, dbo.Product.Price, dbo.OrderDetail.Quanlity " +
              "FROM Product INNER JOIN OrderDetail ON Product.ProductID = OrderDetail.ProductID " +
              "INNER JOIN dbo.[Order] ON dbo.[Order].OrderID = OrderDetail.OrderID " +
              "INNER JOIN Colors ON Colors.ColorID = OrderDetail.ColorID " +
              "INNER JOIN Sizes ON Sizes.SizeID = OrderDetail.SizeID " +
              "WHERE OrderDetail.OrderID = @OrderID";
                var id = DataProvider.Instance.ConvertToList<CartView>(DataProvider.Instance.ExcuteQuery(query));
                return id;
            }
            return null;
        }
    }
}