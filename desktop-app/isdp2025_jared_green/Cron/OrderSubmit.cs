using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Controllers;
using Quartz;

namespace idsp2025_jared_green.Cron
{
    public class OrderSubmit : IJob
    {
        private readonly ITransactionController _transactionController;

        public OrderSubmit(ITransactionController transactionController) 
        { 
            _transactionController = transactionController;
        }

        public static readonly JobKey Key = new JobKey("OrderSubmit");

        public async Task Execute(IJobExecutionContext context)
        {
            // Write the code for submitting the order.

            //MessageBox.Show("Every 5 Seconds Cron job");

            //Console.WriteLine($"Job executed at: {DateTime.UtcNow}");

            //await Task.CompletedTask;
            try
            {
                BindingList<Txn> transactions = await _transactionController.GetAllTransactions();

                List<Txn> newOrders = (from txn in transactions where txn.TxnStatus == "NEW" && txn.TxnType == "Store Order" select txn).ToList();

                foreach (Txn newOrder in newOrders)
                {
                    await _transactionController.UpdateTransactionStatus(newOrder.TxnId, 9998, "SUBMITTED");
                }
            }
            catch (Exception ex)
            {
                // Log the error
            }
        }
    }
}
