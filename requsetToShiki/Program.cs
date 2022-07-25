namespace RequestToShiki
{
    class Program
    {
        static async Task Main()
        {
            Request request = new Request();
            View view = new View();
            var controller = new LookupController(view, request);
            await controller.LookupByName();
        }
    }
}



