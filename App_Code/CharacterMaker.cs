using System;

/// <summary>
/// Summary description for CharacterMaker
/// </summary>
public static class CharacterMaker
{
    public static string makeCharacter(string name)
    {
        int str = 10, dex = 10, con = 10, inl = 10, wis = 10, cha = 10;
        char[] converted = name.ToCharArray();
        Random rand = new Random();


        for(int i = 0; i < converted.Length; ++i)
        {
            switch(rand.Next() % 6)
            {
                case 0: str = helper(str, converted[i]); break;
                case 1: dex = helper(dex, converted[i]); break;
                case 2: con = helper(con, converted[i]); break;
                case 3: inl = helper(inl, converted[i]); break;
                case 4: wis = helper(wis, converted[i]); break;
                case 5: cha = helper(cha, converted[i]); break;
            }
        }

        string constructedOutput = String.Format(@"
            Hello {0}!\n
            Your stats are:\n
            \tStrength: {1}\n
            \tDexterity: {2}\n
            \tConstitution: {3}\n
            \tIntelligence: {4}\n
            \tWisdom: {5}\n
            \tCharisma: {6}\n
            ", name, str, dex, con, inl, wis, cha);
        return constructedOutput;
    }

    private static int helper(int attr, int val)
    {
        switch(val % 4)
        {
            case 0: return attr + 1;
            case 1: return attr - 1;
            case 2: return (int)((float)attr * 1.1);
            case 3: return (int)((float)attr / 1.1);
        }
        return -1;
    }
}