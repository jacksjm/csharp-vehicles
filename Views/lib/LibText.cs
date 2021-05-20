using System;
using System.Drawing;
using System.Windows.Forms;

namespace Views {
    namespace Libs {

        public class LibTextBox : TextBox {
            public LibTextBox(
                int x,
                int y,
                int width,
                int height
            ) {
                this.Location = new Point(x, y);
                this.Size = new Size(width, height);
            }

            public LibTextBox(
                int x,
                int y
            ) : this (x, y, 100, 18) { }
        }

        public class MaskText : MaskedTextBox {
            public MaskText(
                Point Location,
                Size Size,
                string Mask
            ) {
                this.Location = Location;
                this.Size = Size;
                this.Mask = Mask;
            }

            public MaskText(
                int x,
                int y,
                int width,
                int height,
                string Mask
            ) {
                this.Location = new Point(x, y);
                this.Size = new Size(width, height);
                this.Mask = Mask;
            }
        } 
    }
}
