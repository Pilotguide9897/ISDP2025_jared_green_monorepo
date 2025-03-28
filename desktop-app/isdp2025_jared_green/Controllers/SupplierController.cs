using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Error;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Controllers
{
    public class SupplierController : ISupplierController
    {

        private readonly ISupplier _supplierService;
        private static readonly NLog.Logger _supplierControllerLogger = NLog.LogManager.GetCurrentClassLogger();

        public SupplierController(ISupplier supplier)
        {
            _supplierService = supplier;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            try
            {
                if (supplier != null && (await _supplierService.GetSupplier(supplier.SupplierId, supplier.Name) as ErrorResult) != null)
                {
                    return await _supplierService.AddSupplier(supplier) as Supplier;
                } 

                MessageBox.Show("Unable to add supplier because they already exist", "Supplier already exists");
                _supplierControllerLogger.Info("The supplier that there was an attempt to add already exists");
                return null;
            }
            catch (ArgumentException ex)
            {
                _supplierControllerLogger.Error(ex, "Argument exception occurred while adding supplier.");

                MessageBox.Show("There was a problem with the supplier details", "Incorrect supplier details provided");

                return null;
            }
            catch (Exception ex)
            {

                _supplierControllerLogger.Error(ex, "An unexpected error occurred while adding supplier.");

                MessageBox.Show("There was a problem adding the supplier", "Failed to add supplier");

                return null;

            }
        }

        public async Task<Supplier> EditSupplier(Supplier supplier)
        {
     
            Supplier supplierToUpdate = await _supplierService.GetSupplier(supplier.SupplierId) as Supplier;
            var updateResult = await _supplierService.UpdateSupplier(supplier);
            if (updateResult is ErrorResult er)
            {
                MessageBox.Show(er.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Supplier();
            } else
            {
                return updateResult as Supplier;
            }


        }

        public async Task<Supplier> GetSupplier(int supplierId)
        {
            var supplier = await _supplierService.GetSupplier(supplierId);
            if (supplier is ErrorResult er)
            {
                MessageBox.Show(er.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Supplier();
            }
            else
            {
                return supplier as Supplier;
            }

        }

        public async Task<Supplier> GetSupplier(int supplierId, string supplierName)
        {
            var supplier = await _supplierService.GetSupplier(supplierId, supplierName);
            if (supplier is ErrorResult er)
            {
                MessageBox.Show(er.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Supplier();
            }
            else
            {
                return supplier as Supplier;
            }

        }

        public async Task<BindingList<Supplier>> GetSuppliers()
        {
            var suppliers =  await _supplierService.GetSuppliers();
            if (suppliers is ErrorResult er)
            {
                MessageBox.Show(er.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new BindingList<Supplier>();
            } else
            {
                return suppliers as BindingList<Supplier>;
            }  
        }
    }
}
