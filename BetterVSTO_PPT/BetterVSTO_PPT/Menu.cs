using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using VSTO_Base;

namespace BetterVSTO_PPT
{
    public partial class Menu
    {
        private void Menu_Load(object sender, RibbonUIEventArgs e)
        {
            FontColorR.Text = FontColor_R.ToString();
            FontColorG.Text = FontColor_G.ToString();
            FontColorB.Text = FontColor_B.ToString();
        }

        private int Style_Index = 1;

        private void Presentaion_BackgroundStyle_Test()
        {
            if (Style_Index < 12)
            {
                Globals.ThisAddIn.Application.ActivePresentation.Slides[1].BackgroundStyle = (Microsoft.Office.Core.MsoBackgroundStyleIndex)Style_Index;
                Style_Index++;
            }
            else
            {
                Style_Index = 1;
                Globals.ThisAddIn.Application.ActivePresentation.Slides[1].BackgroundStyle = (Microsoft.Office.Core.MsoBackgroundStyleIndex)Style_Index;
            }
        }

        // -----------------------------------------------------------------------------------------------
        // ● Apply FontColor

        private byte FontColor_R = 250;
        private byte FontColor_G = 225;
        private byte FontColor_B = 0;
        private VSTO_Base.ColorConverter _Color = new VSTO_Base.ColorConverter(250, 225, 0);

        private void Apply_FontColor()
        {
            Shape shape = Globals.ThisAddIn.Application.ActiveWindow.Selection as Shape;
            if (shape != null)
            {
                if (Globals.ThisAddIn.Application.ActiveWindow.Selection.GetType() == typeof(Shape))
                    Globals.ThisAddIn.Application.ActiveWindow.Selection.TextRange.Font.Color.RGB = _Color.BGR;
            }
        }

        private void bFontColor_Click(object sender, RibbonControlEventArgs e)
        {
            Apply_FontColor();
        }

        private void FontColorR_TextChanged(object sender, RibbonControlEventArgs e)
        {
            int Value = 0;
            RibbonEditBox box = sender as RibbonEditBox;
            if (box != null)
            {
                int.TryParse(box.Text, out Value);
            }
            FontColor_R = (byte)Value;
            _Color.Convert(FontColor_R, FontColor_G, FontColor_B);
        }

        private void FontColorG_TextChanged(object sender, RibbonControlEventArgs e)
        {
            int Value = 0;
            RibbonEditBox box = sender as RibbonEditBox;
            if (box != null)
            {
                int.TryParse(box.Text, out Value);
            }
            FontColor_G = (byte)Value;
            _Color.Convert(FontColor_R, FontColor_G, FontColor_B);
        }

        private void FontColorB_TextChanged(object sender, RibbonControlEventArgs e)
        {
            int Value = 0;
            RibbonEditBox box = sender as RibbonEditBox;
            if (box != null)
            {
                int.TryParse(box.Text, out Value);
            }
            FontColor_B = (byte)Value;
            _Color.Convert(FontColor_R, FontColor_G, FontColor_B);
        }

        private void FontColorPick_Click(object sender, RibbonControlEventArgs e)
        {
            _Color.SelectColor();
            FontColor_R = _Color.R;
            FontColor_G = _Color.G;
            FontColor_B = _Color.B;
            Update_FontColor_RGB();
        }

        private void Update_FontColor_RGB()
        {
            FontColorR.Text = FontColor_R.ToString();
            FontColorG.Text = FontColor_G.ToString();
            FontColorB.Text = FontColor_B.ToString();
        }

        // -----------------------------------------------------------------------------------------------
        // ● Find & Change
        private void FindChange_Main_Click(object sender, RibbonControlEventArgs e)
        {
            (Globals.ThisAddIn.RegexFinder_host.elementHost1.Child as MenuItem.Find_And_Change.FindAndChange).Init();
            Globals.ThisAddIn.CustomTaskPanes[0].DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
            Globals.ThisAddIn.CustomTaskPanes[0].Visible = true;
        }
    }
}
