using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VSTO_Base
{
    public class ColorConverter
    {
        public ColorConverter(byte R, byte G, byte B)
        {
            Convert(R, G, B);
        }

        public ColorConverter()
        {

        }

        public int BGR { get; set; } = 0;
        public byte B { set; get; } = 0;
        public byte G { set; get; } = 0;
        public byte R { set; get; } = 0;

        public virtual (int, bool) SelectColor()
        {
            bool Apply_BlackBackground = false;
            using (System.Windows.Forms.ColorDialog Temp = new System.Windows.Forms.ColorDialog())
            {
                System.Windows.Forms.DialogResult _DialogResult = Temp.ShowDialog();
                if (_DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    var _Selected = Temp.Color;
                    Convert(_Selected.R, _Selected.G, _Selected.B);

                    if (_Selected.B > 200 || _Selected.G > 200 || _Selected.R > 200)
                        Apply_BlackBackground = true;
                }
            }
            return (BGR , Apply_BlackBackground);
        }

        public (int, bool) Convert(byte R, byte G, byte B)
        {
            bool Apply_BlackBackground = false;
            this.B = B;
            this.G = G;
            this.R = R;
            int B_BGR = (int)(BitConverter.ToUInt32(new byte[4] { B, 0, 0, 0 }, 0) << 16);
            int G_BGR = (int)(BitConverter.ToUInt32(new byte[4] { G, 0, 0, 0 }, 0) << 8);
            int R_BGR = (int)(BitConverter.ToUInt32(new byte[4] { R, 0, 0, 0 }, 0));

            if (B > 200 || G > 200 || R > 200)
                Apply_BlackBackground = true;

            BGR = (R_BGR | G_BGR) | B_BGR;
            return (BGR, Apply_BlackBackground);
        }
    }
}
