using MvcPosApp.Models.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace MvcPosApp.Models
{
    public class BatchSalesAdd
    {
        [Display(Name ="Customer")]
        [Required(ErrorMessage ="Please Select Customer!")]
        public int CustomerModelsId { get; set; }
        [Required(ErrorMessage = "Please Enter Date!")]
        public string Date { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        public List<Sale> SalesList { get; set; }
        public List<SalesDetails> SalesDetailsList { get; set; }
        public List<SalesSaveViewModel> SalesHistory { get; set; }
    }
}