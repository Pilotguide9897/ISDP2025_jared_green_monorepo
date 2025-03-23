using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    public interface ISupplier
    {
        public Task<object> GetSuppliers();

        public Task<object> GetSupplier(int supplierID);

        public Task<object> AddSupplier(Supplier supplier);

        public Task<object> UpdateSupplier(Supplier supplier);
    }
}
