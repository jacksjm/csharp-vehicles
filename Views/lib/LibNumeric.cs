using System;
using System.Drawing;
using System.Windows.Forms;

namespace Views {
    namespace Libs {
        class Numeric : NumericUpDown {
            public Numeric( 
                int x, 
                int y,
                int min,
                int max,
                int width = 100, 
                int height = 18,
                int value = 0,
                int increment = 5
            ) {
                this.Value = value;
                this.Size = new Size(width, height);
                this.Location = new Point(x, y);
                this.Minimum = min;
                this.Maximum = max;
                this.Increment = increment;
            }
        }
    }
}

