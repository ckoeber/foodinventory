using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodInventory.Data;
using FoodInventory.Data.Models;
using FoodInventory.Data.Repositories;

namespace FoodInventory.Data.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<Product> ProductRepository { get; }

        void Save();
    }
}
