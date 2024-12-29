using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UgeElectronics.Core.Entity.Order_Aggregation
{
    public enum OrderStatus
    {
        [EnumMember(Value = "pending")]
        pending,
        [EnumMember(Value = " payment Recived")]
        paymentRecived,
        [EnumMember(Value = " payment Faild")]
        PaymentFaild
    }
}

