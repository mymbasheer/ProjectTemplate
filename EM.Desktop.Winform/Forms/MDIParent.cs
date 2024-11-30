using EM.Desktop.Winform.ViewModels;

namespace EM.Desktop.Winform
{
    public partial class MDIParent : Form
    {
        private readonly MDIParentViewModel _viewModel;

        public MDIParent(MDIParentViewModel viewModel)
        {
            _viewModel = viewModel;

            InitializeComponent();
        }



        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void employeeStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _viewModel.OpenEmployeeForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening EmployeeForm: {ex.Message}");
            }

        }

        private void districtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _viewModel.OpenDistrictForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening DepartmentForm: {ex.Message}");
            }
        }
    }
}
