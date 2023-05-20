using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPCCTradePointWeb.Models.DataBase
{
    public class FPCCTradePoint
    {
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public string TradeType { get; set; }
        public double TradePoint { get; set; }
        public string MemberType { get; set; }
        public string MemberNo { get; set; }
        public string TradeDate { get; set; }
        public string WriteOffNo { get; set; }
        public string iCashDate { get; set; }
        public string PointStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}