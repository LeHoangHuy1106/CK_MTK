using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.CommandPattern
{
    class ToolStripMenuItemCommand : ICommands
    {
        private System.Windows.Forms.ToolStripMenuItem item;
        public ToolStripMenuItemCommand(System.Windows.Forms.ToolStripMenuItem item )
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
