using System;
using System.Windows.Forms;
using System.Drawing;

namespace Views {
    namespace Libs {
        public class LibButton : Button {
            public LibButton(
                string Text,
                int x, 
                int y,
                int width = 180, 
                int height = 30,
                EventHandler Click = null
            ) {
                this.Text = Text;
                this.Size = new Size(width, height);
                this.Location = new Point(x, y);
                if (Click.GetType() != null) {
                    this.Click += new EventHandler(Click);
                }
            }
        }
    }
}
