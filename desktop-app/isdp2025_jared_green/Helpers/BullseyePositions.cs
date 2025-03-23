using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Helpers
{
    public enum BullseyePositions
    {
        [Description("Regional Manager")]
        RegionalManager,

        [Description("Financial Manager")]
        FinancialManager,

        [Description("Store Manager")]
        StoreManager,

        [Description("Warehouse Worker")]
        WarehouseWorker,

        [Description("Delivery")]
        Delivery,

        [Description("Administrator")]
        Administrator,

        [Description("Online Customer")]
        OnlineCustomer
    }
}
