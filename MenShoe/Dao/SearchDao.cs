﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MenShoe.EF;
using System.Data.SqlClient;

namespace MenShoe.Dao
{
    public class SearchDao
    {
        public List<Product> searchAll(string searchString)
        {
            searchString = "%" + searchString + "%";
            string query = "SELECT * FROM PRODUCT INNER JOIN Category ON Product.CategoryID = Category.CategoryID " +
                "INNER JOIN ProductCategory ON Product.ProductCategoryID = ProductCategory.ProductCategoryID"+
                "WHERE Product.Name like "+ searchString + " OR Category.Name LIKE " + searchString + " or ProductCategory.Name like @searchString";
            var id = DataProvider.Instance.ConvertToList<Product>(DataProvider.Instance.ExcuteQuery(query));
            return id;
        }

        public List<Product> searchProduct(string searchString)
        {
            List<Product> lstProduct = db.Products.Where(p => p.Name.Contains(searchString.ToString())).ToList();
            return lstProduct;
        }

        public List<Product> searchCategory(string searchString)
        {
            searchString = "%" + searchString + "%";
            string query = "SELECT * FROM PRODUCT INNER JOIN Category ON Product.CategoryID = Category.CategoryID " +
                "INNER JOIN ProductCategory ON Product.ProductCategoryID = ProductCategory.ProductCategoryID" +
                " WHERE Category.Name LIKE " + searchString + " or ProductCategory.Name like " + searchString + "";
            var id = DataProvider.Instance.ConvertToList<Product>(DataProvider.Instance.ExcuteQuery(query));
            return id;
        }
    }
}