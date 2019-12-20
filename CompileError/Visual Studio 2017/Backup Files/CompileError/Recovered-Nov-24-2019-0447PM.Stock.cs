using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileError.Model.Model
{
    public class Stock
    {
        public int Id { set; get; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string ReorderLevel { get; set; }
        public string ExpiredDate { get; set; }
        public string ExpiredQuantity { get; set; }
        public string OpeningBalance { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string IN { get; set; }
        public string Out { get; set; }
        public string ClosingBalance { get; set; }
    }
}
