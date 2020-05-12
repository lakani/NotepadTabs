using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NotepadTabs
{
    public partial class MainWindow : Form
    {
        //TextBox m_editor[];
        public MainWindow()
        {
            InitializeComponent();
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
        }
    }
}
