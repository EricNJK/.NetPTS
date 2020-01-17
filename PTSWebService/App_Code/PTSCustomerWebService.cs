using PTSLibrary;
using System.Web.Services;

/// <summary>
/// Summary description for PTSCustomerWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PTSCustomerWebService : System.Web.Services.WebService
{
    private PTSCustomerFacade facade;

    public PTSCustomerWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        facade = new PTSCustomerFacade();
    }

    [WebMethod]
    public int Authenticate(string name, string password)
    {
        return facade.Authenticate(name, password);
    }

    [WebMethod]
    public Project[] GetListOfProjects(int customerId)
    {
        return facade.GetListOfProjects(customerId);
    }

}
