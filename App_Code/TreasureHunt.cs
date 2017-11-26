using System.Net;
using System.IO;
/// <summary>
/// Summary description for TreasureHunt
/// </summary>
public static class TreasureHunt
{

    private const string API_KEY = "AIzaSyD2qM3L-TBki-sMAliQr7IQbqoicGcYVlU";

    public static string[] huntForTreasure(string addr)
    {
        string[] splitted = addr.Split(' ');
        string combined = "";
        foreach(string str in splitted)
        {
            combined += str + "+";
        }
        combined = combined.Substring(0, combined.Length - 1);

        string url1 = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + combined + "&destination=Home+Depot" + "&key=" + API_KEY;
        WebRequest request1 = WebRequest.Create(url1);
        WebResponse response1 = request1.GetResponse();
        Stream data1 = response1.GetResponseStream();
        StreamReader reader1 = new StreamReader(data1);

        // json-formatted string from maps api
        string responseFromServer1 = reader1.ReadToEnd();

        response1.Close();

        string url2 = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + combined + "&destination=public+park" + "&key=" + API_KEY;
        WebRequest request2 = WebRequest.Create(url2);
        WebResponse response2 = request2.GetResponse();
        Stream data2 = response2.GetResponseStream();
        StreamReader reader2 = new StreamReader(data2);

        // json-formatted string from maps api
        string responseFromServer2 = reader2.ReadToEnd();

        response2.Close();

        return new string[] { responseFromServer1, responseFromServer2 };
    }
}