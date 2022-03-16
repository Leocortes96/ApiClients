using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClients.Models
{
    public class customers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public int id_document_type { get; set; }
        public string document_number { get; set; }
        public string business_name { get; set; }
        public int id_providers { get; set; }
        public decimal sales_last_year { get; set; }
    }
}
