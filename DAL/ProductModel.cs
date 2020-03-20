using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class Message
    {
        public int code = 0;
        public string message = "";
    }
    public class ViewProductModel
    {
        //public int Product_id { get; set; }
        //public string Product_name { get; set; }
        //public string Product_content { get; set; }
        //public int Toltal { get; set; }
        public List<ProductModel> _products;
    }

    public class ProductModel : BaseModel
    {
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public string Product_content { get; set; }

        public int Product_quantity { get; set; }

        public string tblName = "Product";

        public List<ProductModel> getAll()
        {
            List<ProductModel> _product = new List<ProductModel>();
            try
            {
                string query = "Select * from " + tblName;
                using (var db = getInstance())
                {
                    SqlCommand command = new SqlCommand(query, db);
                    //command.Parameters.AddWithValue("@pricePoint", paramValue);

                    db.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int productId = getSpecificName<int>(reader, "Product_id");
                        string productName = getSpecificName<string>(reader, "Product_name");
                        //string productContent = getSpecificName<string>(reader, "Product_name");

                        //string item2 = reader.get;
                        ProductModel item = new ProductModel()
                        {
                            Product_id = productId,
                            Product_name = productName,
                            //Product_content = ,
                        };
                        _product.Add(item);
                        //Console.WriteLine("\t{0}\t{1}\t{2}",
                        //    reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                    db.Close();
                }
                //return
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //retr
            }
            return _product;
        }

        public int InsertOrUpdate()
        {
            try
            {
                string query = "Insert into Product(Product_name, Product_content, Product_quantity) " +
                                "Values (@Product_name, @Product_content, @Product_quantity)";
                using (var db = getInstance())
                {
                    db.Open();
                    SqlCommand command = new SqlCommand(query, db);

                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@Product_name", Product_name);
                    command.Parameters.AddWithValue("@Product_content", Product_content);
                    command.Parameters.AddWithValue("@Product_quantity", Product_quantity);
                    //var transaction = command.Connection.BeginTransaction();
                    int reader = 0;
                    try
                    {
                        reader = (int) command.ExecuteScalar();
                        //string rereader.ToString();
                        //command.ExecuteScalar
                        //transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        //transaction.Rollback();
                    }
                    return 1;
                }
            } catch (Exception ex)
            {
                return 0;            
            }
        }
    }


}