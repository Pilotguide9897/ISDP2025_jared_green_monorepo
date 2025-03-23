using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface ISupplierController
    {
        public Task<BindingList<Supplier>> GetSuppliers();

        public Task<Supplier> GetSupplier(int supplierId);

        public Task<Supplier> AddSupplier(Supplier supplier);

        public Task<Supplier> EditSupplier(Supplier supplier);
    }
}
