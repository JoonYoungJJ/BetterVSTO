using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VSTO_Base;

namespace BetterVSTO_PPT.MenuItem.Find_And_Change
{
    /// <summary>
    /// FindAndSearch.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindAndChange : UserControl, INotifyPropertyChanged
    {
        public FindAndChange()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string TargetString { set; get; } = "";
        public string ReplaceString { set; get; } = "";
        public string ResultInfo { set; get; } = "";

        public bool Format_Font_Background_En { set; get; } = false;
        public SolidColorBrush Format_Font_Background { set; get; } = Brushes.White;
        public bool Format_Font_Foreground_En { set; get; } = false;
        public SolidColorBrush Format_Font_Foreground { set; get; } = Brushes.White;
        public bool Format_Font_Size_En { set; get; } = false;

        private void Select_Color(object sender, RoutedEventArgs e)
        {
            Label lbl = sender as Label;
            using (System.Windows.Forms.ColorDialog Temp = new System.Windows.Forms.ColorDialog())
            {
                System.Windows.Forms.DialogResult _DialogResult = Temp.ShowDialog();
                if (_DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(Temp.Color.A, Temp.Color.R, Temp.Color.G, Temp.Color.B);
                    if (lbl.Name == "b_Format_Font_Background")
                        Format_Font_Background = new SolidColorBrush(newColor);
                    else
                        Format_Font_Foreground = new SolidColorBrush(newColor);
                }
            }
        }

        private void b_FindText_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private bool Loaded = false;
        public void Init()
        {
            if (!Loaded)
            {
                b_FindText.DirectImage = BetterVSTO_PPT.Properties.Resources.FindInFile_16x;
                Loaded = true;
            }
        }
    }

    
}
