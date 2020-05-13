using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace NotepadTabs
{
    public partial class MainWindow : Form
    {
        //TextBox m_editor[];
        Font m_CurrentFnt;
        Color m_CurrentClr;

        public MainWindow()
        {
            InitializeComponent();

            ReadConfiguration();

        }

        public void ReadConfiguration()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            string  FontName;    //string
            float   FontSize = 0;   //FontSize      // single
            int     FontStyle;  //FontStyle     //int

            if (string.IsNullOrEmpty(config.AppSettings.Settings["FontName"].Value))
                FontName = "Consolas";
            else
                FontName = config.AppSettings.Settings["FontName"].Value;

            if (string.IsNullOrEmpty(config.AppSettings.Settings["FontSize"].Value))
                FontSize = 10.8F;
            else
                float.TryParse(config.AppSettings.Settings["FontSize"].Value, out FontSize);

            if (string.IsNullOrEmpty(config.AppSettings.Settings["FontStyle"].Value))
                FontSize = System.Drawing.FontStyle.Regular;
            else
                float.TryParse(config.AppSettings.Settings["FontSize"].Value, out FontSize);



            config.Save(ConfigurationSaveMode.Minimal);
        }

        TextBox CreateNewTabTextBox()
        {
            System.Windows.Forms.TextBox txtBox= new TextBox();

            txtBox.AcceptsReturn = true;
            txtBox.AcceptsTab = true;
            txtBox.AllowDrop = true;
            txtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            txtBox.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBox.Location = new System.Drawing.Point(3, 3);
            txtBox.Multiline = true;
            txtBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtBox.Size = new System.Drawing.Size(786, 415);
            txtBox.TabIndex = 0;
            txtBox.TabStop = false;

            return txtBox;
        }

        TabPage CreateNewTabPage()
        {
            System.Windows.Forms.TabPage tabPage = new TabPage();

            tabPage.Controls.Add(CreateNewTabTextBox());
            tabPage.Location = new System.Drawing.Point(4, 25);
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(792, 421);
            tabPage.TabIndex = 0;
            tabPage.Text = "tabPage1";
            tabPage.UseVisualStyleBackColor = true;
            tabPage.KeyDown += new System.Windows.Forms.KeyEventHandler(MainWindow_KeyDown);

            return tabPage;
        }

        public void AddNewTab()
        {
            tabCtrl.Controls.Add(CreateNewTabPage());
            tabCtrl.SelectedIndex = tabCtrl.Controls.Count - 1;

            TabPage tab = (TabPage)tabCtrl.Controls[tabCtrl.Controls.Count - 1];
            TextBox txt = (TextBox)tab.Controls[0];
            txt.Focus();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.T)
            {
                AddNewTab();
            }
            else if(e.Control && e.KeyCode == Keys.F)
            {
                // get the selected tab font
                TabPage selectedTabPage = tabCtrl.SelectedTab;
                if(selectedTabPage != null)
                {
                    TextBox selectedTxtBox = (TextBox )selectedTabPage.Controls[0];
                    if(selectedTxtBox != null)
                    {
                        FontDialog fntDlg = new FontDialog();

                        fntDlg.Font = selectedTxtBox.Font;
                        fntDlg.Color = selectedTxtBox.ForeColor;

                        if(fntDlg.ShowDialog() == DialogResult.OK)
                        {
                            selectedTxtBox.Font = fntDlg.Font;
                            selectedTxtBox.ForeColor = fntDlg.Color;
                        }
                    }
                }
            }

        }
    }
}
