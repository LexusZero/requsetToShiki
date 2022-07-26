namespace RequestToShiki.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            var request = new Request();
            var view = new LookupWindow();
            var controller = new LookupController(view, request);
            view.LookupTriggered += async (sender, args) => await controller.LookupByName();
            Application.Run(view);
        }
    }
}
