using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace IS
{
    static class InterfaceSettings
    {
        public static void Drawing(TabControl tbc, DrawItemEventArgs e)
        {

            Graphics g = e.Graphics;
            Brush _TextBrush;

            //Get the item from the collection.
            TabPage _TabPage = tbc.TabPages[e.Index];

            //Get the real bound for the tab rectangle.
            Rectangle _TabBound = tbc.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                //Drow a different background color, and don't paint a focus rectangle.
                _TextBrush = new SolidBrush(Color.White);
                g.FillRectangle(Brushes.Gray, e.Bounds);

            }
            else
            {

                _TextBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            //Use own font
            Font _TabFont = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);

            //Draw string. Center the text.
            StringFormat _StringFlags = new StringFormat();
            _StringFlags.Alignment = StringAlignment.Center;
            _StringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_TabPage.Text, _TabFont, _TextBrush, _TabBound, new StringFormat(_StringFlags));
        }

    }
}
