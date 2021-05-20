using System;
using System.Windows.Forms;
using System.Drawing;

namespace Views {
    namespace Libs {

        public class LibColumn {
            public string Field { get; }
            public HorizontalAlignment Orientation { get; }

            public LibColumn (
                string Field, 
                HorizontalAlignment Orientation
            ) {
                this.Field = Field;
                this.Orientation = Orientation;
            }
        }

        public class LibListView : ListView {
            public LibListView(
                int x, 
                int y,
                int width, 
                int height,
                LibColumn[] columns
            ) {
                this.Size = new Size(width, height);
                this.Location = new Point(x, y);
                this.View = View.Details;
                this.FullRowSelect = true;
                this.GridLines = true;
                this.AllowColumnReorder = true;
                this.Sorting = SortOrder.Ascending;

                foreach (LibColumn item in columns)
                {
                    this.Columns.Add (item.Field, -2, item.Orientation);
                }
            }
        }
    }
}
