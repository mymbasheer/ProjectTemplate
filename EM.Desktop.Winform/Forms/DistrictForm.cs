using EM.Desktop.Winform.ViewModels;

namespace EM.Desktop.Winform
{
    public partial class DistrictForm : Form
    {
        private readonly DistrictViewModel _viewModel;

        // Constructor accepts the ViewModel via dependency injection
        public DistrictForm(DistrictViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            // Bind the ViewModel to the form
            BindViewModel();

            // Optionally, wire up the form events to ViewModel commands
            Load += DistrictForm_Load;
        }

        // Bind ViewModel to the form controls
        private void BindViewModel()
        {
            // Bind TextBox to DistrictName property in the ViewModel
            textBoxDistrictName.DataBindings.Add("Text", _viewModel, nameof(_viewModel.DistrictName), false, DataSourceUpdateMode.OnPropertyChanged);

            // You can bind other controls if needed

            // Bind button clicks to commands in the ViewModel
            btnAddDistrict.Click += async (sender, e) => await AddDistrictAsync();
        }

        // Loading the districts when the form is loaded
        private async void DistrictForm_Load(object? sender, EventArgs e)
        {
            await _viewModel.LoadDistrictsAsync();

            // Remove the row headers
            dataGridViewDistricts.RowHeadersVisible = false;

            // Prevent columns from being repeated by setting AutoGenerateColumns to false
            dataGridViewDistricts.AutoGenerateColumns = false;

            // Set SelectionMode to FullRowSelect to select entire rows
            dataGridViewDistricts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            // Bind the DataGridView to the districts collection
            dataGridViewDistricts.DataSource = _viewModel.Districts;

            SetupDataGridView();  // Set up columns manually
        }

        // Add a district using the ViewModel
        private async Task AddDistrictAsync()
        {
            try
            {
                await _viewModel.AddDistrictAsync();
                // Optionally, refresh the list or update any relevant UI
                await _viewModel.LoadDistrictsAsync();  // Refresh districts after adding
            }
            catch (Exception ex)
            {
                // Show an error message
                MessageBox.Show($"Error adding district: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Setup the DataGridView
        private void SetupDataGridView()
        {

            // Clear any existing columns first
            dataGridViewDistricts.Columns.Clear();

            // Create the ID column
            DataGridViewTextBoxColumn idColumn = new()
            {
                DataPropertyName = "ID", // Bind it to the ID property of the District class
                HeaderText = "District ID",
                Name = "idColumn",
                Width = 100
            };
            dataGridViewDistricts.Columns.Add(idColumn);

            // Create the Name column
            DataGridViewTextBoxColumn nameColumn = new()
            {
                DataPropertyName = "Name", // Bind it to the Name property of the District class
                HeaderText = "District Name",
                Name = "nameColumn",
                Width = 150

            };
            dataGridViewDistricts.Columns.Add(nameColumn);
        }

    }
}
