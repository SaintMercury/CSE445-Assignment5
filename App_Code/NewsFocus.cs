using System.Collections.Generic;
using System.Net;
using System.Data;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for NewsFocus
/// </summary>
public static class NewsFocus
{
    public static string[] getNewsFocus(string[] searchTerms)
    {
        List<string> theGoods = new List<string>();

        // Make an hhtp request so google kindly gives me the info
        string searchPhrase = "";
        for (int i = 0; i < searchTerms.Length; ++i)
        {
            searchPhrase += searchTerms[i] + "+";
        }
        searchPhrase = searchPhrase.Substring(0, searchPhrase.Length - 2);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://news.google.com/news?q=" + searchPhrase + "&output=rss");
        request.Method = "GET";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        if(response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            if (response.CharacterSet == "")
                readStream = new StreamReader(receiveStream);
            else
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

            //Get news data in json string

            string data = readStream.ReadToEnd();

            //Declare DataSet for putting data in it.
            DataSet ds = new DataSet();
            StringReader reader = new StringReader(data);
            ds.ReadXml(reader);
            DataTable dtGetNews = new DataTable();

            if (ds.Tables.Count > 3)
            {
                dtGetNews = ds.Tables["item"];

                foreach (DataRow dtRow in dtGetNews.Rows)
                {
                    theGoods.Add(dtRow["link"].ToString());
                }
            }
        }

        return theGoods.ToArray();
    }
}