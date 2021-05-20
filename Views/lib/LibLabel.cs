using System;
using System.Drawing;
using System.Windows.Forms;

namespace Views {
    namespace Libs {
        class LibLabel : Label {
            public LibLabel(
                string Text, 
                int x, 
                int y,
                int width = 180, 
                int height = 30
            ) {
                this.Text = Text;
                this.Size = new Size(width, height);
                this.Location = new Point(x, y);
            }
        }

        class TitleLabel : Label {
            public TitleLabel(
                string Text, 
                int x, 
                int y,
                int width = 180, 
                int height = 30
            ) {
                this.Text = Text;
                this.Size = new Size(width, height);
                this.Location = new Point(x, y);
                this.ForeColor = Color.Blue;
                //this.Font =  new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);
            }
        }
    }
}

