namespace EM.Desktop.Winform.Services
{
    public class WindowService : IWindowService
    {
        public void ShowForm(Form form)
        {
            form.Show();  // Show the form
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);  // Show the message
        }
    }

}
