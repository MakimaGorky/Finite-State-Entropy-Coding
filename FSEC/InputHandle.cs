namespace FSEC;

public class InputHandle
{
    public static Dictionary<char, int> GetAlpabet()
    {
        Console.WriteLine("Enter number of symbols >>");
        
        var n = -1;
        while (n < 0)
            try
            {
                int.TryParse(Console.ReadLine(), out n);
            }
            catch (Exception e)
            {
                Console.WriteLine("enter correct number pls!");
            }
        
        Console.Write("Now enter the characters along with their frequencies ");
        Console.WriteLine("in current format: \"A:3 B:2 ...\" >>");

        var res = new Dictionary<char, int>();
        
        while (true)
            try
            {
                var s = Console.ReadLine();
                var sp = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (sp.Length != n)
                    throw new ArgumentException("incorrect 1");
                foreach (var e in sp)
                {
                    var ep = e.Split(':');
                    if (ep.Length != 2)
                        throw new ArgumentException("incorrect 2");
                    if (!int.TryParse(ep[1], out var val))
                        throw new ArgumentException("incorrect 3");
                    if (!res.TryAdd(ep[0].ToCharArray()[0], val)) // Alpha:3 Bravo:2 Charlie:1 Delta:2
                        throw new ArgumentException("incorrect 4");
                    
                    //foreach (var el in res)
                    //   Console.Write($"{el.Value} ");
                    //Console.WriteLine();
                }

                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        return res;
    }

    public static string GetMessage(Dictionary<char, int> alf)
    {
        Console.WriteLine("And finally enter a message to encode >>");

        var res = "";
        while (true)
            try
            {
                res = Console.ReadLine();
                foreach (var c in res)
                {
                    if (!alf.ContainsKey(c))
                        throw new ArgumentException("incorrect symbol");
                }
                //boring validation
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        return res;
    }
}