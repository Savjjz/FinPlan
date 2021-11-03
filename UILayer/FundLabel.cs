using System.Windows.Forms;

namespace Supervisor
{
    public class FundLabel : Label
    {
        public string FundCode;
        public FundLabel(string FundCode)
        {
            this.FundCode = FundCode;
        }
    }
}
