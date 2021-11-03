using System.Windows.Forms;

namespace Supervisor
{
    public class FundPanel : Panel
    {
        public string FundCode;
        public FundPanel(string FundCode)
        {
            this.FundCode = FundCode;
        }
    }
}
