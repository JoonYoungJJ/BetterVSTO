
namespace BetterVSTO_PPT
{
    partial class Menu : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Menu()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.Fonts = this.Factory.CreateRibbonGroup();
            this.bFontColor = this.Factory.CreateRibbonButton();
            this.FontColorR = this.Factory.CreateRibbonEditBox();
            this.FontColorG = this.Factory.CreateRibbonEditBox();
            this.FontColorB = this.Factory.CreateRibbonEditBox();
            this.FontColorPick = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.FindChange_Main = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.Fonts.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Groups.Add(this.Fonts);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "Special";
            this.tab1.Name = "tab1";
            // 
            // Fonts
            // 
            this.Fonts.Items.Add(this.bFontColor);
            this.Fonts.Items.Add(this.FontColorR);
            this.Fonts.Items.Add(this.FontColorG);
            this.Fonts.Items.Add(this.FontColorB);
            this.Fonts.Items.Add(this.FontColorPick);
            this.Fonts.Label = "FontColor";
            this.Fonts.Name = "Fonts";
            // 
            // bFontColor
            // 
            this.bFontColor.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bFontColor.Image = global::BetterVSTO_PPT.Properties.Resources.ColorPalette_16x;
            this.bFontColor.Label = "Selection Color";
            this.bFontColor.Name = "bFontColor";
            this.bFontColor.ShowImage = true;
            this.bFontColor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bFontColor_Click);
            // 
            // FontColorR
            // 
            this.FontColorR.Label = "R";
            this.FontColorR.Name = "FontColorR";
            this.FontColorR.ScreenTip = "Font Color (Red)";
            this.FontColorR.SuperTip = "RGB Color (0~255)";
            this.FontColorR.Text = null;
            this.FontColorR.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.FontColorR_TextChanged);
            // 
            // FontColorG
            // 
            this.FontColorG.Label = "G";
            this.FontColorG.Name = "FontColorG";
            this.FontColorG.ScreenTip = "Font Color (Green)";
            this.FontColorG.SuperTip = "RGB Color (0~255)";
            this.FontColorG.Text = null;
            this.FontColorG.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.FontColorG_TextChanged);
            // 
            // FontColorB
            // 
            this.FontColorB.Label = "B";
            this.FontColorB.Name = "FontColorB";
            this.FontColorB.ScreenTip = "Font Color (Blue)";
            this.FontColorB.SuperTip = "RGB Color (0~255)";
            this.FontColorB.Text = null;
            this.FontColorB.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.FontColorB_TextChanged);
            // 
            // FontColorPick
            // 
            this.FontColorPick.Image = global::BetterVSTO_PPT.Properties.Resources.ColorDialog_16x;
            this.FontColorPick.Label = "Pick";
            this.FontColorPick.Name = "FontColorPick";
            this.FontColorPick.ScreenTip = "Choose RGB in Dialog";
            this.FontColorPick.ShowImage = true;
            this.FontColorPick.SuperTip = "Choose a foreground in color dialog";
            this.FontColorPick.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.FontColorPick_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.FindChange_Main);
            this.group1.Label = "Find && Change";
            this.group1.Name = "group1";
            // 
            // FindChange_Main
            // 
            this.FindChange_Main.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.FindChange_Main.Image = global::BetterVSTO_PPT.Properties.Resources.FindInFile_16x;
            this.FindChange_Main.Label = "Regex Search";
            this.FindChange_Main.Name = "FindChange_Main";
            this.FindChange_Main.ScreenTip = "Regular Expression Search";
            this.FindChange_Main.ShowImage = true;
            this.FindChange_Main.SuperTip = "Regular Expression Search";
            this.FindChange_Main.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.FindChange_Main_Click);
            // 
            // Menu
            // 
            this.Name = "Menu";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Menu_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.Fonts.ResumeLayout(false);
            this.Fonts.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Fonts;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bFontColor;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox FontColorR;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox FontColorG;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox FontColorB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton FontColorPick;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton FindChange_Main;
    }

    partial class ThisRibbonCollection
    {
        internal Menu Menu
        {
            get { return this.GetRibbon<Menu>(); }
        }
    }
}
