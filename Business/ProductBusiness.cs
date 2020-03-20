using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business
{

    public class ProductBusiness
    {
        ProductModel product = new ProductModel();
        public List<ProductModel> listProduct()
        {

            return product.getAll();
        }

        public int InsertOrUpdate(ProductModel model)
        {
            return model.InsertOrUpdate();
        }
    }
}