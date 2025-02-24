using ProductMicroservice.Data;
using ProductMicroservice.DTOs;
using ProductMicroservice.Entities;
using ProductMicroservice.ProductInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
        public class ProductStockRepository : IStock
        {
            private readonly DataContext _dataContextClass;

            public ProductStockRepository(DataContext dataContextClass)
            {
                _dataContextClass = dataContextClass;
            }

            public async Task<int> AddProductStockQuatity(int id, RequestIncreaseorDecreaseStockquantity requestIncreaseorDecreaseStockquantity)
            {
             //Currenlty we adding stock once the Product Details is added to Db, but i need to change the AddProduct API to addStock at the time of creating Product 
            try
            {

                StockDto stock = new StockDto();
                stock.ProductId = requestIncreaseorDecreaseStockquantity.Productid;
                stock.QuantityAvailable = requestIncreaseorDecreaseStockquantity.Quantity;
                stock.LastRestroed = DateTime.Now;
                stock.LastUpdated = DateTime.Now;

                if (stock != null)
                {
                    await _dataContextClass.Stock.AddAsync(stock);
                    var res = await _dataContextClass.SaveChangesAsync();

                    return res;

                }
                else
                {
                    return 0;

                }
            }
            catch (Exception ex)
            {
                //Need to add Logging mechanism
                return 0;

            }

        }

        public async Task<int> DecrementProductStockQuatity(int id, RequestIncreaseorDecreaseStockquantity requestIncreaseorDecreaseStockquantity)
        {
            try
            { 
            int res = 0;
            var product = await _dataContextClass.Stock.FindAsync(id);

            if (product != null)
            {

                StockDto stock = new StockDto();
                stock.ProductId = requestIncreaseorDecreaseStockquantity.Productid;
                stock.QuantityAvailable = requestIncreaseorDecreaseStockquantity.Quantity;
                stock.LastUpdated = DateTime.Now;
                if (stock != null)
                {

                    await _dataContextClass.Stock.AddAsync(stock);
                    res = await _dataContextClass.SaveChangesAsync();
                }
                return res;
            }
            else
            {
                return 0;

            }
            }
            catch(Exception ex)
            {
                //Need to add Logging mechanism
                return 0;
            }
            }
        }
}
