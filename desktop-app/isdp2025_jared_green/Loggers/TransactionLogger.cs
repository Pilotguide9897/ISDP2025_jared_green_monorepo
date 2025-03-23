using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Loggers
{
    internal class TransactionLogger
    {
        // Declare the static logger.
        private static readonly NLog.Logger TransactionLog = NLog.LogManager.GetCurrentClassLogger();

        public static void LogTransaction(Txn txn)
        {
            var logEventInfo = new LogEventInfo(LogLevel.Info, "TransactionLogger", "")
            {
                // Can have more complex logic to determine what is placed in the notes section.
                Properties =
                {
                    ["TxnID"] = txn.TxnId,
                    ["EmployeeID"] = txn.EmployeeId,
                    ["TxnType"] = txn.TxnType,
                    ["Status"] = txn.TxnStatus,
                    ["TxnDate"] = DateTime.Today,
                    ["SiteID"] = txn.SiteIdfrom,
                    ["DeliveryID"] = txn.DeliveryId ?? (object)DBNull.Value,
                    ["Notes"] = txn.Notes,
                    ["CreatedDate"] = DateTime.UtcNow,
                }
            };
            TransactionLog.Log(logEventInfo);
        }

        public static void LogTransactionUpdate(Txn txnBefore, Txn txnAfter)
        {
            if (txnBefore == null || txnAfter== null)
                throw new ArgumentNullException("Transaction objects cannot be null");
                    // Check the differences for all of the fields:
                    string logNotes = "";
            List<String> changes = ObjectPropertyChangeDetector.GetPropertyChanges(txnBefore, txnAfter);

            // Add logic for more dynamic note messages:
            foreach (String change in changes) {
                switch (change)
                {
                    case "Status":
                        logNotes += $"Transaction status updated from {txnBefore.TxnStatus} to {txnAfter.TxnStatus}";
                        break;
                    case "EmployeeID":
                        logNotes += $" by employee {txnAfter.Employee.Username}";
                        break;
                    case "TxnDate":
                        logNotes += $" on {txnAfter.CreatedDate}.";
                        break;
                    case "SiteID":
                        logNotes += $" Site updated from {txnBefore.SiteIdto} to {txnAfter.SiteIdto}.";
                        break;
                    default:
                        Console.WriteLine($"Unknown property change: {change}");
                        break;
                }

            }
            LogTransaction(txnAfter);
        }
    }
}
