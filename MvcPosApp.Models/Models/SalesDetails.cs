using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPosApp.Models.Models
{
    public class SalesDetails
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public Sale Sales { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float SubTotal { get; set; }
    }
}