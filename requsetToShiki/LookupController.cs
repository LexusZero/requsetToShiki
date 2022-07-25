namespace RequestToShiki;
using System.Threading.Tasks;

public class LookupController
{
    private IView view;
    private IRequest request;
    LookupController(IView view, IRequest request)
    {
        this.view = view;
        this.request = request;
    }
    public async Task LookupByName()
    {

    }
}
