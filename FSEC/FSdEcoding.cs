using System.Text;
using System.Threading.Channels;

namespace FSEC;

public static class FSdEcoding
{

    public static int GuessLetter(out char letter, Bit[] mes, ref int curInd, int state, Dictionary<char, int> alphabet, int totalFreq, Dictionary<int, char> stateAlf)
    {
        letter = stateAlf[state];
        var letFreq = alphabet[letter];

        var crutch = 0;
        while (stateAlf.ContainsKey(state + crutch + 1) && stateAlf[state + crutch + 1] == letter)
            crutch++;

        var maxIntLength = 1;
        var maxDeg = 0;

        var norm = totalFreq % alphabet[letter] == 0 ? 2 : 1;
        
        while (maxIntLength <= totalFreq / alphabet[letter])
        {
            maxIntLength *= 2;
            maxDeg++;
        }

        maxIntLength /= norm;
        maxDeg -= norm / 2;

        //‼‼
        var minCount = (alphabet[letter] - (totalFreq / maxIntLength)) * 2;

        var newState = 0;
        var bin = 1;
        var normalizer = alphabet[letter] - crutch > minCount ? 0 : 1;
        maxDeg -= normalizer;
        
        //Console.WriteLine($"    (){maxDeg} - {maxIntLength}");
        
        for (int i = 0; i < maxDeg; i++)
        {
            //Console.WriteLine($"    i->{curInd}={curInd - i}->{mes[curInd - i].Value()}");
                newState += mes[curInd - i].Value() * bin;
            bin *= 2;
        }
        curInd -= maxDeg == 0 ? 1 : maxDeg;
        
        //Console.WriteLine($"    )({newState + maxIntLength / 2 * (crutch - totalFreq + minCount + 1)}");
        
        if (normalizer == 0)
            return newState + totalFreq - maxIntLength * (crutch + 1);
        return (newState + maxIntLength / 2 * ( (crutch) - alphabet[letter] + (crutch == alphabet[letter] - 1 ? 0 : minCount) + 1));
    }
    
    public static string Decode(Dictionary<char, int> alf, int state, Bit[] mes)
    {
        var res = new StringBuilder();

        var freq = FSEgeneral.GetTotalFrequency(alf);
        var stateAlf = FSEgeneral.GenStateAlpabet(alf, freq);
        
        var index = mes.Length - 1;

        while (index >= 0)
        {
            //Console.WriteLine($"s-{state}->{index}->");
            //Console.WriteLine($"{res}");
            state = GuessLetter(out var letter, mes, ref index, state, alf, freq, stateAlf);
            res.Append(letter);
            //Console.WriteLine($"{letter}");
        }
        //Console.WriteLine($"s-{state}");
        res.Append(stateAlf[state]);

        var s = new StringBuilder(res.Length);
        for (int i = res.Length - 1; i >= 0; i--)
            s.Append(res[i]);

        return s.ToString();
    }
    
}