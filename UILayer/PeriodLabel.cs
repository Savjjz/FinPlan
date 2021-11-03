using System.Windows.Forms;

namespace Supervisor
{
    public class PeriodLabel : Label
    {
        public int PeriodNum;
        public PeriodLabel(int PeriodNum)
        {
            this.PeriodNum = PeriodNum;
        }
    }
}
