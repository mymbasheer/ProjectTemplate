namespace EM.Desktop.Winform
{
    partial class DistrictForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxDistrictName = new TextBox();
            btnAddDistrict = new Button();
            dataGridViewDistricts = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDistricts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "District :";
            // 
            // textBoxDistrictName
            // 
            textBoxDistrictName.Location = new Point(12, 27);
            textBoxDistrictName.Name = "textBoxDistrictName";
            textBoxDistrictName.Size = new Size(146, 23);
            textBoxDistrictName.TabIndex = 1;
            // 
            // btnAddDistrict
            // 
            btnAddDistrict.Location = new Point(176, 27);
            btnAddDistrict.Name = "btnAddDistrict";
            btnAddDistrict.Size = new Size(90, 23);
            btnAddDistrict.TabIndex = 2;
            btnAddDistrict.Text = "Add District";
            btnAddDistrict.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDistricts
            // 
            dataGridViewDistricts.AllowUserToAddRows = false;
            dataGridViewDistricts.AllowUserToDeleteRows = false;
            dataGridViewDistricts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDistricts.Location = new Point(12, 56);
            dataGridViewDistricts.Name = "dataGridViewDistricts";
            dataGridViewDistricts.ReadOnly = true;
            dataGridViewDistricts.Size = new Size(254, 196);
            dataGridViewDistricts.TabIndex = 3;
            // 
            // DistrictForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 264);
            Controls.Add(dataGridViewDistricts);
            Controls.Add(btnAddDistrict);
            Controls.Add(textBoxDistrictName);
            Controls.Add(label1);
            Name = "DistrictForm";
            Text = "District Form";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDistricts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxDistrictName;
        private Button btnAddDistrict;
        private DataGridView dataGridViewDistricts;
    }
}
