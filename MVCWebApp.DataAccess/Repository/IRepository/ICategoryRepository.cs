using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCWebApp.Models;

namespace MVCWebApp.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        void Update(CategoryModel item);
        void Save();
    }
}