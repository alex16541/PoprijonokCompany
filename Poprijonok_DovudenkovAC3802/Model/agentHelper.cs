using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprijonok_DovudenkovAC3802
{
    public partial class Agent
    {
        public string LogoPath => string.IsNullOrEmpty(Logo) ? "../Resource/picture.png" : @"..\Resource" + Logo;
        public int SalesPerYear => dbContext.db.ProductSale.Where(sale => sale.AgentID == ID).Count();
        public double SalesProcent
        {
            get
            {
                double salesPerYear = SalesPerYear;
                double salesCount = dbContext.db.ProductSale.ToList().Count();
                return salesPerYear / salesCount * 100;
            }
        }

        public bool IsDeleted { get; set; } = false;
    }
}
