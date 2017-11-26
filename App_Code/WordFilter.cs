using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Summary description for WordFilter
/// </summary>
public static class WordFilter
{
    public static string[] Stop_Words = null;

    public static string[] filterWords(string phraseToFilter)
    {
        if (WordFilter.Stop_Words == null)
            WordFilter.loadStopWords();

        List<string> list = WordFilter.convertToList(phraseToFilter.ToLower());

        WordFilter.removeStopWords(list);

        return list.ToArray();
    }

    private static void loadStopWords()
    {
        try
        {
            WordFilter.Stop_Words = File.ReadAllLines(
                System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/StopWords.txt") // What a trip to find out how to do this
            );

            for(int i = 0; i < WordFilter.Stop_Words.Length; ++i)
            {
                WordFilter.Stop_Words[i] = WordFilter.Stop_Words[i].ToLower();
                WordFilter.Stop_Words[i] = WordFilter.Stop_Words[i].Trim();
            }
        }
        catch(Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
    }

    private static List<string> convertToList(string phrase)
    {/*
        List<string> filteredList = new List<string>();
        int previous = 0;
        for (int i = 0; i < phrase.Length; ++i)
        {
            if (phrase[i] == ' ' && previous < i)
            {
                string cutWord = phrase.Substring(previous, i - previous).Trim();
                previous = i;
                filteredList.Add(cutWord);
            }
        }
        int lastIndex = phrase.Length;
        if (previous < lastIndex)
        {
            string lastWord = phrase.Substring(previous, lastIndex - previous).Trim();
            filteredList.Add(lastWord);
        }

        return filteredList; */
        return new List<string>(phrase.Split(' '));
    }

    private static void removeStopWords(List<string> list)
    {
        List<string> listToRemove = new List<string>();

        foreach (string word in list)
            foreach (string stopWord in WordFilter.Stop_Words)
                if (word.CompareTo(stopWord) == 0)
                    listToRemove.Add(word);

        foreach (string str in listToRemove)
            list.Remove(str);
    }
}