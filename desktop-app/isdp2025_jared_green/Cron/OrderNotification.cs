using idsp2025_jared_green.Interfaces.Services;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Cron
{
    internal class OrderNotification : IJob
    {
        private readonly ITransaction _transactionService;
        public static readonly JobKey Key = new JobKey("OrderNotification");

        // Run once every 5 minutes.
        public OrderNotification(ITransaction transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            // Write the code for checking if there are any new orders.


            await Task.CompletedTask;
        }
    }
}
