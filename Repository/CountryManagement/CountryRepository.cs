using Contracts.Repository.CountryManagement;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CountryManagement
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext context) : base(context)
        {
        }
    }
}

