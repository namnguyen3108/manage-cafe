using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace learning_asp.Areas.Product.Controllers
{
    public class ProductController : Controller
    {

        ProductBusiness ProductBusiness = new ProductBusiness();

        [HttpGet]
        // GET: Product/Product
        public ActionResult Index()
        {
            List<ProductModel> products = ProductBusiness.listProduct(); // 2
            ViewProductModel model = new ViewProductModel();
            model._products = products;
            return View(model);
        }


        [HttpPost]
        //[ValidateInput(true)]
        public RedirectResult Add(ProductModel model)
        {


            int status = ProductBusiness.InsertOrUpdate(model);
            return new RedirectResult("Index");
        }
    }
}