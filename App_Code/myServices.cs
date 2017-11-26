using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class myServices : System.Web.Services.WebService
{

    [WebMethod]
    public string[] wordFilter(string phraseToFilter) {
        return WordFilter.filterWords(phraseToFilter);
    }

    [WebMethod]
    public string[] newsFocus(string[] args)
    {
        return NewsFocus.getNewsFocus(args);
    }

    [WebMethod]
    public string getChar(string name)
    {
        return CharacterMaker.makeCharacter(name);
    }

    [WebMethod]
    public string[] huntTreasure(string address)
    {
        return TreasureHunt.huntForTreasure(address);
    }

}