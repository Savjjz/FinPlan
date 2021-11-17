using System.Windows.Forms;

namespace Supervisor
{
    public class ExpenseLabel : Label
    {
        public string Id;
        public ExpenseLabel(string Id)
        {
            this.Id = Id;
        }
    }
}
