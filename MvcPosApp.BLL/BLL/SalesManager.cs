using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPosApp.Repository.Repository;
using MvcPosApp.Models.Models;

namespace MvcPosApp.BLL.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();
        public bool Save(SalesDetails salesModel)
        {
            return _salesRepository.Save(salesModel);
        }
        public bool SaveSalesProduct(Sale sale)
        {
            return _salesRepository.SaveSalesProduct(sale);

        }

        public bool Update(SalesDetails salesModel)
        {
            return _salesRepository.Update(salesModel);
        }

        public bool Delete(Sale sale)
        {
            return _salesRepository.Delete(sale);
        }
        public SalesDetails FindById(SalesDetails salesModel)
        {
            return _salesRepository.FindById(salesModel);
        }
        public List<Sale> FindAll()
        {
            return _salesRepository.FindAll();
        }

        public bool Save(List<SalesDetails> salesModel)
        {
            return _salesRepository.Save(salesModel);
        }
        public CustomerModel GetCustLoyaltyPoints(int CustId)
        {
            return _salesRepository.GetCustLoyaltyPoints(CustId);
        }
        //public List<SalesDetails> VoucherDetails(int voucherNo)
        //{
        //    return _salesRepository.VoucherDetails(voucherNo);
        //}
    }
}