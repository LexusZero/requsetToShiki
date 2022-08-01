namespace RequestToShiki;

internal class Program
{
    private static async Task Main()
    {
        var request = new ShikimoriRequest();
        var view = new View();
        var controller = new LookupController(view, request);
        await controller.LookupByName();
    }
}



