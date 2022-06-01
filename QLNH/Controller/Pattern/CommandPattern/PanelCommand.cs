using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.CommandPattern
{
    class PanelCommand : ICommands
    {
        private System.Windows.Forms.Panel item;
        public PanelCommand(System.Windows.Forms.Panel item)
        {
            this.item = item;
        }
        public void executeDisable()
        {
            item.Enabled = false;
        }

        public void executeEnable()
        {
            item.Enabled = true;
        }
    }
}
