using EM.Desktop.Winform.ViewModels;

namespace EM.Desktop.Winform
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeViewModel _viewModel;

        // Constructor accepts the ViewModel via dependency injection
        public EmployeeForm(EmployeeViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            // Bind the ViewModel to the form
            BindViewModel();

            // Optionally, wire up the form events to ViewModel commands
            Load += EmployeeForm_LoadAsync;
            buttonAddEmployee.Click += async (sender, e) => await _viewModel.AddEmployeeAsync();
        }

        // Bind ViewModel to the form controls
        private void BindViewModel()
        {
            // Bind TextBox to EmployeeName property in the ViewModel
            textBoxEmployeeName.DataBindings.Add("Text", _viewModel, nameof(_viewModel.EmployeeName), false, DataSourceUpdateMode.OnPropertyChanged);

            // Bind DateTimePicker to DateOfBirth property in the ViewModel
            dateTimePickerDateOfBirth.DataBindings.Add("Value", _viewModel, nameof(_viewModel.DateOfBirth), false, DataSourceUpdateMode.OnPropertyChanged);


        }

        // Load the districts asynchronously when the form is loaded
        private async void EmployeeForm_LoadAsync(object? sender, EventArgs e)
        {
            await _viewModel.LoadDistrictsAsync();
            await _viewModel.LoadEmployeesAsync();

            // Bind ComboBox to Districts and SelectedDistrictId properties in the ViewModel
            comboBoxDistrict.DataSource = _viewModel.Districts;
            comboBoxDistrict.DisplayMember = "Name";  // Display the district name
            comboBoxDistrict.ValueMember = "ID";     // Use the district ID as the value
            comboBoxDistrict.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedDistrictId), false, DataSourceUpdateMode.OnPropertyChanged);

            // Remove the row headers
            dataGridViewEmployee.RowHeadersVisible = false;

            // Prevent columns from being repeated by setting AutoGenerateColumns to false
            dataGridViewEmployee.AutoGenerateColumns = false;

            // Set SelectionMode to FullRowSelect to select entire rows
            dataGridViewEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Bind the DataGridView to the districts collection
            dataGridViewEmployee.DataSource = _viewModel.Employees;

            SetupDataGridView();  // Set up columns manually
        }

        // Setup the DataGridView
        private void SetupDataGridView()
        {

            // Clear any existing columns first
            dataGridViewEmployee.Columns.Clear();

            // Create the ID column
            DataGridViewTextBoxColumn idColumn = new()
            {
                DataPropertyName = "ID", // Bind it to the ID property of the District class
                HeaderText = "Employee ID",
                Name = "idColumn",
                Width = 100
            };
            dataGridViewEmployee.Columns.Add(idColumn);

            // Create the Name column
            DataGridViewTextBoxColumn nameColumn = new()
            {
                DataPropertyName = "Name", // Bind it to the Name property of the District class
                HeaderText = "Employee Name",
                Name = "nameColumn",
                Width = 150

            };
            dataGridViewEmployee.Columns.Add(nameColumn);

            // Create the Date of Birth column (bind to the 'Dob' property of Employee class)
            DataGridViewTextBoxColumn dobColumn = new()
            {
                DataPropertyName = "Dob",  // Bind it to the Dob property of the Employee class
                HeaderText = "Date of Birth",  // Header for the Dob column
                Name = "dobColumn",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } // Format for displaying date in a short format (e.g., MM/dd/yyyy)
            };
            dataGridViewEmployee.Columns.Add(dobColumn);

            // Create the District Name column
            DataGridViewTextBoxColumn districtIdColumn = new()
            {
                DataPropertyName = "DistrictId",  // Bind it to the DistrictName property
                HeaderText = "District Id",
                Name = "districtIdColumn",
                Width = 150
            };
            dataGridViewEmployee.Columns.Add(districtIdColumn);
        }



    }
}
