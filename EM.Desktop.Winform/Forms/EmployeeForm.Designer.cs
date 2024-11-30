namespace EM.Desktop.Winform
{
    partial class EmployeeForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxEmployeeName = new TextBox();
            dateTimePickerDateOfBirth = new DateTimePicker();
            comboBoxDistrict = new ComboBox();
            buttonAddEmployee = new Button();
            dataGridViewEmployee = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployee).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Employee Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(364, 9);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 0;
            label2.Text = "Date of Birth:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(505, 9);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 0;
            label3.Text = "District:";
            // 
            // textBoxEmployeeName
            // 
            textBoxEmployeeName.Location = new Point(12, 27);
            textBoxEmployeeName.Name = "textBoxEmployeeName";
            textBoxEmployeeName.Size = new Size(293, 23);
            textBoxEmployeeName.TabIndex = 1;
            // 
            // dateTimePickerDateOfBirth
            // 
            dateTimePickerDateOfBirth.Format = DateTimePickerFormat.Short;
            dateTimePickerDateOfBirth.Location = new Point(364, 27);
            dateTimePickerDateOfBirth.Name = "dateTimePickerDateOfBirth";
            dateTimePickerDateOfBirth.Size = new Size(91, 23);
            dateTimePickerDateOfBirth.TabIndex = 2;
            // 
            // comboBoxDistrict
            // 
            comboBoxDistrict.FormattingEnabled = true;
            comboBoxDistrict.Location = new Point(505, 27);
            comboBoxDistrict.Name = "comboBoxDistrict";
            comboBoxDistrict.Size = new Size(173, 23);
            comboBoxDistrict.TabIndex = 3;
            // 
            // buttonAddEmployee
            // 
            buttonAddEmployee.Location = new Point(12, 71);
            buttonAddEmployee.Name = "buttonAddEmployee";
            buttonAddEmployee.Size = new Size(94, 23);
            buttonAddEmployee.TabIndex = 4;
            buttonAddEmployee.Text = "Add Employee";
            buttonAddEmployee.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEmployee
            // 
            dataGridViewEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployee.Location = new Point(12, 128);
            dataGridViewEmployee.Name = "dataGridViewEmployee";
            dataGridViewEmployee.Size = new Size(666, 310);
            dataGridViewEmployee.TabIndex = 5;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 450);
            Controls.Add(dataGridViewEmployee);
            Controls.Add(buttonAddEmployee);
            Controls.Add(comboBoxDistrict);
            Controls.Add(dateTimePickerDateOfBirth);
            Controls.Add(textBoxEmployeeName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EmployeeForm";
            Text = "Employee Information";
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxEmployeeName;
        private DateTimePicker dateTimePickerDateOfBirth;
        private ComboBox comboBoxDistrict;
        private Button buttonAddEmployee;
        private DataGridView dataGridViewEmployee;
    }
}