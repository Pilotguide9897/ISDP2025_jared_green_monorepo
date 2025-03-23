using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Services;
using Quartz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Cron
{
    public class OrderCreate : IJob
    {
        private readonly ITransaction _transactionService;
        private readonly ILocations _locationService;
        private readonly IInventory _inventoryService;

        public static readonly JobKey Key = new JobKey("OrderCreate");

        public OrderCreate(ITransaction transactionService, ILocations locationService, IInventory inventoryService)
        {
            _transactionService = transactionService;
            _locationService = locationService;
            _inventoryService = inventoryService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            // Write Cron for creating orders if one does not already exist for the store. 
            List<int> retailSites = await _locationService.GetRetailLocations();
            foreach (var site in retailSites)
            {
                await AddDefaultItemsToOrder(9998, site);
            }

            Console.WriteLine($"Job executed at: {DateTime.UtcNow}");

            await Task.CompletedTask;
        }

        public async Task<Txn> AddDefaultItemsToOrder(int employeeID, int site)
        {
            if (await _transactionService.CheckForOrder(site, 0) == null)
            {

                Txn orderTransaction = await _transactionService.CreateOrder(employeeID, site, 0);

                BindingList<Inventory> requiredInventory = await _inventoryService.GetInventoryInNeedOfResupply(site);
                List<Txnitem> defaultItems = new List<Txnitem>();
                foreach (Inventory inventory in requiredInventory)
                {
                    Txnitem txnItem = new Txnitem();

                    int quantityToSupply = -1;
                    int delta = inventory.OptimumThreshold - inventory.Quantity;
                    int casesToOrder = delta / inventory.Item.CaseSize;
                    int remainder = delta % inventory.Item.CaseSize;
                    if (remainder > 0)
                    {
                        casesToOrder++;
                    }
                    txnItem.TxnId = orderTransaction.TxnId;
                    txnItem.ItemId = inventory.ItemId;
                    txnItem.Quantity = (casesToOrder * inventory.Item.CaseSize);

                    defaultItems.Add(txnItem);
                }

                return await _transactionService.AddTransaction(orderTransaction);
            }
            return null;
        }
    }
}
