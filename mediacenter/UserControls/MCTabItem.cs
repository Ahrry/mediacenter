using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using mediacenter.Views;

namespace mediacenter.UserControls
{
    class MCTabItem : TabItem
    {
        public MCTabItem(Layout layout)
        {
            this.Content = new Frame() { Content = layout };
        }
    }
}
