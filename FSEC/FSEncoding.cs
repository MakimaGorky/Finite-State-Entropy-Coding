using System.Collections;
using System.Text;
using System.Threading.Channels;

namespace FSEC;

public static class FSEncoding
{
    //нехватает priority dictionary - сделаю потом
    //работать будет за NlogN ~*3
    static int NextState (out List<Bit> letterCode, int state, char nextLetter, Dictionary<char, int> alphabet, int totalFreq, Dictionary<char, int> rangeAlf)
    {
        var maxIntLength = 1;
        var maxDeg = 0;

        var norm = totalFreq % alphabet[nextLetter] == 0 ? 2 : 1;
        
        while (maxIntLength <= totalFreq / alphabet[nextLetter])
        {
            maxIntLength *= 2;
            maxDeg++;
        }

        maxIntLength /= norm;
        maxDeg -= norm / 2;

        var minCount = (alphabet[nextLetter] - totalFreq / maxIntLength) * 2;
        
        var crutch = 0; //remove crutch. <=> numState 

        if (totalFreq + state >= alphabet[nextLetter] * maxIntLength)
        {
            crutch = (state - maxIntLength / 2 * minCount) / maxIntLength + minCount; //(alphabet[nextLetter] - state / maxIntLength + (minCount == 0 ? 1 : 0)); // + (minCount == 0 ? minCount + 1 : minCount) - 1;
            letterCode = BitOperation.ConvertToBitList((state - maxIntLength / 2 * minCount) % maxIntLength, maxDeg);
        }
        else
        {
            var minIntLength = maxIntLength / 2 == 0 ? 1 : maxIntLength / 2;
            crutch = state / minIntLength;
            letterCode = BitOperation.ConvertToBitList(state % minIntLength, maxDeg - 1);
        }

        return rangeAlf[nextLetter] + crutch;
    }

    
    public static Bit[] Encode(Dictionary<char, int> alf, string mes, out int fState)
    {
        var res = new List<Bit>();

        fState = 0;
        
        var tf = FSEgeneral.GetTotalFrequency(alf);
        var rAlf = FSEgeneral.GenRangedAlphabet(alf, tf);
        //var temp = new List<Bit>();
        fState = NextState(out var temp, fState, mes[0], alf, tf, rAlf);

        for (int i = 1; i < mes.Length; i++)
        {
            fState = NextState(out temp, fState, mes[i], alf, tf, rAlf);
            /*
            Console.WriteLine($"{mes[i]}-{fState}-{temp}");
            foreach (var bit in temp)
                Console.Write($"{bit}");
            Console.WriteLine();
            */
            foreach (var b in temp)
                res.Add(b);
        }

        return res.ToArray();
    }

}