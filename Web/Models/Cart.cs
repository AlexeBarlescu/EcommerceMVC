﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = Lines.FirstOrDefault(l => l.Product.ProductId == product.ProductId);
            if(line == null)
            {
                Lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        
        public virtual void UpdateItem(Product product, int quantity)
        {
            CartLine line = Lines.FirstOrDefault(l => l.Product.ProductId == product.ProductId);

            if (line != null) line.Quantity = quantity;
        }

        public virtual void RemoveLine(Product product) => 
            Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue() =>
            Lines.Sum(l => l.Product.Price * l.Quantity);

        public virtual void Clear() => Lines.Clear();
    }
}
