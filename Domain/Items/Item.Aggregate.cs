using Domain.Base;  
using System;
using System.Linq;

namespace Domain.Items
{
    public partial class Item : IAggregateRoot
    {
        public Item(string ItemNme, string ItemDesc, string Brnd, double Price, int? Rvew, int? Stock,int? categoryId)
        {
            this.ItemNme = ItemNme;

            this.Update(
                ItemNme,ItemDesc,Brnd, Price, Rvew, Stock,categoryId
            );
        }

        //public Add(string ItemNme, string ItemDesc, string Brnd, decimal Price, int Rvew, int Stock, int categoryId)
        //{

        //}

        public void Update(string itemNme, string itemDesc, string brnd, double price, int? rvew, int? stock, int?  categoryId)
        {
            this.ItemNme = itemNme;
            this.ItemDesc = itemDesc;
            this.Brnd = brnd;
            this.Price = price;
            this.Stock = stock;
            this.CategoryId = categoryId;

            
        }

        public void AddCategory(int categoryId)
        {
            CategoryId = categoryId;
        }

        public void reduceQuantity(int quantity) {
            Stock = Stock - quantity;
        }    
       
    }
}