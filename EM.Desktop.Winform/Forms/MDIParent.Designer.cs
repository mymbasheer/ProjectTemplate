namespace EM.Desktop.Winform
{
    partial class MDIParent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            employeeStripMenuItem = new ToolStripMenuItem();
            districtToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(737, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { employeeStripMenuItem, districtToolStripMenuItem, toolStripSeparator5, exitToolStripMenuItem });
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(55, 20);
            fileMenu.Text = "&Master";
            // 
            // employeeStripMenuItem
            // 
            employeeStripMenuItem.Name = "employeeStripMenuItem";
            employeeStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            employeeStripMenuItem.Size = new Size(180, 22);
            employeeStripMenuItem.Text = "&Employee";
            employeeStripMenuItem.Click += employeeStripMenuItem_Click;
            // 
            // districtToolStripMenuItem
            // 
            districtToolStripMenuItem.ImageTransparentColor = Color.Black;
            districtToolStripMenuItem.Name = "districtToolStripMenuItem";
            districtToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            districtToolStripMenuItem.Size = new Size(180, 22);
            districtToolStripMenuItem.Text = "&District";
            districtToolStripMenuItem.Click += districtToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += ExitToolsStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 501);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(737, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(39, 17);
            toolStripStatusLabel.Text = "Status";
            // 
            // MDIParent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 523);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MDIParent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Management Information";
            WindowState = FormWindowState.Maximized;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem districtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem employeeStripMenuItem;
    }
}



