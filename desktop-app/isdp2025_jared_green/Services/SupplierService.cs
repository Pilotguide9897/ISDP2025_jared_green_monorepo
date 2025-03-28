using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Error;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Services
{
    internal class SupplierService : ISupplier
    {

        private static readonly NLog.Logger _supplierLogger = NLog.LogManager.GetCurrentClassLogger();
        private readonly BullseyeContext _bullseyeContext;

        public SupplierService(BullseyeContext bullseyeContext) 
        {
            _bullseyeContext = bullseyeContext;
        }

        public async Task<object> AddSupplier(Supplier supplier)
        {
            try
            {
                await _bullseyeContext.AddAsync(supplier);
                await _bullseyeContext.SaveChangesAsync();
                return supplier;
            }
            catch (ArgumentException argEx)
            {
                _supplierLogger.Error(argEx, "Invalid argument provided when adding a supplier.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _supplierLogger.Error(msqlEx, "Database error occurred when adding a supplier.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _supplierLogger.Error(toEx, "Operation timed out when adding a supplier.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _supplierLogger.Error(ex, "An unexpected error occurred when adding a supplier.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }


        public async Task<object> GetSupplier(int supplierID)
        {
            try
            {
                Supplier? supplier = await (from sup in _bullseyeContext.Suppliers where sup.SupplierId == supplierID select sup).FirstOrDefaultAsync();
                if (supplier == null)
                {
                    _supplierLogger.Error($"No suppliers with an id matching {supplierID} exist in our records");
                    return new ErrorResult("NO_MATCHES", "No match for supplier id found in the database.");
                }
                return supplier!;

            }
            catch (ArgumentException argEx)
            {
                _supplierLogger.Error(argEx, "Invalid argument provided when requesting a supplier.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _supplierLogger.Error(msqlEx, "Database error occurred when requesting a supplier.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _supplierLogger.Error(toEx, "Operation timed out when requesting a supplier.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _supplierLogger.Error(ex, "An unexpected error occurred when requesting a supplier.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }


        public async Task<object> GetSupplier(int supplierID, string supplierName)
        {
            try
            {
                Supplier? supplier = await (from sup in _bullseyeContext.Suppliers where sup.SupplierId == supplierID || sup.Name == supplierName select sup).FirstOrDefaultAsync();
                if (supplier == null)
                {
                    _supplierLogger.Error($"No suppliers with an id matching {supplierID} exist in our records");
                    return new ErrorResult("NO_MATCHES", "No match for supplier id found in the database.");
                }
                return supplier!;

            }
            catch (ArgumentException argEx)
            {
                _supplierLogger.Error(argEx, "Invalid argument provided when requesting a supplier.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _supplierLogger.Error(msqlEx, "Database error occurred when requesting a supplier.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _supplierLogger.Error(toEx, "Operation timed out when requesting a supplier.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _supplierLogger.Error(ex, "An unexpected error occurred when requesting a supplier.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }

        public async Task<object> GetSuppliers()
        {
            try
            {
                List<Supplier> suppliers = await (from sup in _bullseyeContext.Suppliers select sup).ToListAsync();

                if (suppliers.Count > 0)
                {
                    var bindingList = new BindingList<Supplier>(suppliers);

                    return bindingList;
                }

                return new ErrorResult("NO_DATA", "The database contains no supplier data to return");

            }
            catch (MySqlException msqlEx)
            {
                _supplierLogger.Error(msqlEx, "Database error occurred when requesting a supplier.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _supplierLogger.Error(toEx, "Operation timed out when requesting a supplier.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _supplierLogger.Error(ex, "An unexpected error occurred when requesting a supplier.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }

        public async Task<object> UpdateSupplier(Supplier supplier)
        {
            try
            {
                var tracked = _bullseyeContext.Suppliers.Local.FirstOrDefault(e => e.SupplierId == supplier.SupplierId);
                if (tracked != null)
                {
                    _bullseyeContext.Entry(tracked).State = EntityState.Detached;
                }
                _bullseyeContext.Update(supplier);
                await _bullseyeContext.SaveChangesAsync();
                return supplier;
            }
            catch (ArgumentException argEx)
            {
                _supplierLogger.Error(argEx, "Invalid argument provided when attempting to update a supplier.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _supplierLogger.Error(msqlEx, "Database error occurred when when attempting to update a supplier.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _supplierLogger.Error(toEx, "Operation timed out when when attempting to update a supplier.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _supplierLogger.Error(ex, "An unexpected error occurred when when attempting to update a supplier.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }
    }
}
