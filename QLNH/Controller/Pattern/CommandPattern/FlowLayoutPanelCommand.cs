using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.CommandPattern
{
    internal class FlowLayoutPanelCommand : ICommands
    {
        private System.Windows.Forms.FlowLayoutPanel item;
        public FlowLayoutPanelCommand(System.Windows.Forms.FlowLayoutPanel item)
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
