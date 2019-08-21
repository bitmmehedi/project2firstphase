using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPosApp.BLL.BLL;
using MvcPosApp.Models.Models;
using MvcPosApp.Models;
using AutoMapper;

namespace MvcPosApp.Controllers
{
    public class SalesController : Controller
    {
        SalesManager _salesManager = new SalesManager();
        private SalesDetails _salesDetails = new SalesDetails();
        private Sale sale = new Sale();
        CustomerManager _customerManager = new CustomerManager();
        // GET: Sales
        [HttpGet]
        public ActionResult Save()
        {
            SalesSaveViewModel salesModelVm = new SalesSaveViewModel();
            salesModelVm.CustomerList = _customerManager.FindAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(), Text = c.CustName
            });
            return View(salesModelVm);
        }
        [HttpPost]
        public ActionResult Save(SalesSaveViewModel salesModelVm)
        {
            if (ModelState.IsValid)
            {
                SalesDetails salesModel = new SalesDetails();
                salesModel = Mapper.Map<SalesDetails>(salesModelVm);
                if (_salesManager.Save(salesModel))
                {
                    ViewBag.SuccessMsg = "Data Saved SuccessFully!";
                }
                else
                {
                    ViewBag.FailMsg = "Data Saved Fail!";
                }
            } else
            {
                ViewBag.FailMsg = "Data Validtion Fail!";
            }
            salesModelVm.CustomerList = _customerManager.FindAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustName
            });
            return View(salesModelVm);
        }
        public ActionResult Delete(Sale sale)
        {
            sale.Id = sale.Id;

            if (_salesManager.Delete(sale))
            {
                ViewBag.SuccessMsg = "Data Delete SuccessFully!";
                //Response.Redirect("FindAll");
            }
            else
            {
                ViewBag.FailMsg = "Data Delete Fail!";
                //Response.Redirect("FindAll");
            }

            return View();
        }
        public ActionResult FindAll()
        {
            SalesSaveViewModel salesSaveVM = new SalesSaveViewModel();

            salesSaveVM.SalesList = _salesManager.FindAll();
            salesSaveVM.CustomerList = _customerManager.FindAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.CustName
                });
            return View(salesSaveVM);
        }

        public ActionResult BatchSalesAdd()
        {
            var customers = _customerManager.FindAll();
            ViewBag.Customers = new SelectList(customers, "Id", "CustName");

            return View();
        }

        [HttpPost]
        public ActionResult BatchSalesAdd(SalesSaveViewModel Model)
        {
            sale.CustomerModelsId = Model.CustomerModelsId;
            int loyaltyPoint = (Convert.ToInt32(Model.CustomerPayment) / 1000);
            CustomerModel customer = new CustomerModel();
            customer.Id = sale.CustomerModelsId;
            var aCustomer = _customerManager.FindById(customer);
            if(Model.Discount > 0)
            {
                aCustomer.CustLoyaltyPoints = aCustomer.CustLoyaltyPoints - (Convert.ToInt32(Model.Discount * 10));
            } else
            {
                aCustomer.CustLoyaltyPoints = aCustomer.CustLoyaltyPoints + loyaltyPoint;
            }
            

            sale.Date = Model.Date;
            sale.Comments = Model.Comments;
            sale.CustomerPayment = Model.CustomerPayment;
            sale.SalesDetailsList = Model.SalesDetailsList;
            if (_salesManager.SaveSalesProduct(sale))
            {
                if (_customerManager.Update(aCustomer))
                {
                    var customersList = _customerManager.FindAll();
                    ViewBag.Customers = new SelectList(customersList, "Id", "CustName");
                    ViewBag.SuccessMsg = "Data Saved SuccessFully!";
                    return View();
                }
                
            }
            else
            {
                ViewBag.FailMsg = "Data Saved Fail!";
            }
            

            //var salesModel = new List<SalesDetails>();

            //if (ModelState.IsValid)
            //{
            //   // Model.CustomerModelsId = 1;

            //    int CustId = Model.CustomerModelsId;
            //    foreach (var value in Model.SalesDetailsList)

            //    {
            //        salesModel.Add(value);
            //    }
            //    if (_salesManager.Save(salesModel))
            //    {
            //        ViewBag.SuccessMsg = "Data Saved SuccessFully!";
            //    }
            //    else
            //    {
            //        ViewBag.FailMsg = "Data Saved Fail!";
            //    }
            //}



            //Model.CustomerList = _customerManager.FindAll()
            //    .Select(c => new SelectListItem()
            //    {
            //        Value = c.Id.ToString(),
            //        Text = c.CustName
            //    }).ToList();
            var customers = _customerManager.FindAll();
            ViewBag.Customers = new SelectList(customers, "Id", "CustName");

            return View(Model);
        }
        public JsonResult GetCustLoyaltyPoints(int CustId)
        {
            var customer = _salesManager.GetCustLoyaltyPoints(CustId);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult VoucherDetails(int voucherNo)
        //{
        //    var vouchweDetails = _salesManager.VoucherDetails(voucherNo);

        //    return PartialView("VoucherDetails", vouchweDetails);
        //}

    }
}