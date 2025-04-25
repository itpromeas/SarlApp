using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category {get;}
        IProductRepository Product {get;}
        ICompanyRepository Company { get; }
        void Save();
    }
}