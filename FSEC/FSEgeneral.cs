namespace FSEC;

public static class FSEgeneral
{
    public static int GetTotalFrequency(Dictionary<char, int> alf)
    {
        var res = 0;
        foreach (var e in alf)
            res += e.Value;
        return res;
    }

    /// <summary>
    /// создает словарь по буквам алфавита, где значения это начальный индекс
    /// отрезка, выделенного на каждую букву (в зависимости от её чистоты).
    /// </summary>
    /// <param name="baseAlf"></param>
    /// <param name="totalFreq"></param>
    /// <returns></returns>
    public static Dictionary<char, int> GenRangedAlphabet(Dictionary<char, int> baseAlf, int totalFreq)
    {
        var res = new Dictionary<char, int>();

        var ind = 0;
        foreach (var l in baseAlf)
        {
            res.Add(l.Key, ind);
            ind += l.Value;
        }

        return res;
    }

    public static Dictionary<int, char> GenStateAlpabet(Dictionary<char, int> baseAlf, int totalFreq)
    {
        var res = new Dictionary<int, char>();

        var ind = 0;
        foreach (var l in baseAlf)
        {
            for (int i = ind; i < ind + l.Value; i++)
                res.Add(i, l.Key);
            ind += l.Value;
        }

        return res;
    }

    public static Bit[] GetEncoded(Dictionary<char, int > dictiooonary, string inpooot, out int state)
    {
        Console.WriteLine($"Finally!☺");
        var reseses = FSEncoding.Encode(dictiooonary, inpooot, out var staiaiait);
        Console.WriteLine($"Final State: {staiaiait}");

        Console.WriteLine($"Final Code: ");
        foreach (var res in reseses)
            Console.Write($"{res}");
        Console.WriteLine();
        
        state = staiaiait;
        return reseses;
    }
    
    public static string GetDecoded(Dictionary<char, int > dictiooonary, int state, Bit[] reseses)
    {
        Console.WriteLine("Let's decode the message!");
        
        var staaart = FSdEcoding.Decode(dictiooonary, state, reseses);
        Console.WriteLine("Here it is:");
        Console.WriteLine(staaart);

        return staaart;
    }
}