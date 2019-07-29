using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPosApp.Models.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public int CustCode { get; set; }
        [Required(ErrorMessage = "Please enter Name!")]
        [StringLength(50, MinimumLength = 3)]
        public string CustName { get; set; }
        //[Required(ErrorMessage = "Please enter E-mail!")]
        public string CustEmail { get; set; }

        //[Required(ErrorMessage = "Please enter Address!")]
        public string CustAddress { get; set; }

        //[Required(ErrorMessage = "Please enter Contact Number!")]
        //[StringLength(14, MinimumLength = 6)]
        public int CustContact { get; set; }
        public int CustLoyaltyPoints { get; set; }
        [NotMapped]
        public List<CustomerModel> Customers { get; set; }
    }
}