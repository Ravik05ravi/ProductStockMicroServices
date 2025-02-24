using ProductMicroservice.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.ProductInterface
{
    public interface IStock
    {
      public   Task<int > AddProductStockQuatity(int id, RequestIncreaseorDecreaseStockquantity  requestIncreaseorDecreaseStockquantity);

      public  Task<int> DecrementProductStockQuatity(int id, RequestIncreaseorDecreaseStockquantity requestIncreaseorDecreaseStockquantity);
    }
}
