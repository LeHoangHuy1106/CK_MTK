using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.CommandPattern
{
    class ButtonCommandBase
    {
        protected ICommands [] items;

        public ButtonCommandBase (ICommands [] items)
        {
            this.items = items;
        }

        public ButtonCommandBase()
        {
        }

        public void setItems(ICommands[] items)
        {
            this.items = items;
        }

        public void executeEnable()
        {
            foreach (var item in items)
            {
                item.executeEnable();
            }
        }

        public void executeDisable()
        {
            foreach (var item in items)
            {
                item.executeDisable();
            }
        }
    }

}
