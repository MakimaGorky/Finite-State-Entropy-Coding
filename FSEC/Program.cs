

using System.Reflection.Metadata;

namespace FSEC
{

    class Demo
    {

        static void Main()
        {
            // A:3 B:2 C:1 D:2
            // AABADCDB

            // A:5 B:5 C:3 D:3
            // BCDA
            
            // A:7 B:4 C:1 D:4
            // AABADCDB
            
            //A:5 B:1 C:1 D:1
            //AABACAAD
            
            //F:6 L:7 U:8 K:11
            //K:11 U:8 L:7 F:6
            //FULFUK
            
            var dictiooonary = InputHandle.GetAlpabet();
            var inpooot = InputHandle.GetMessage(dictiooonary);

            //var dictiooonary = new Dictionary<char, int>();
            //dictiooonary.Add('w', 131);
            //dictiooonary.Add('u', 125);
            //dictiooonary.Add('m', 256);
            
            //var inpooot = "uwuwuuuwwmwww";
            
            var reseses = FSEgeneral.GetEncoded(dictiooonary, inpooot, out var staiaiait);

            //var reseses = new Bit[]
            //    { new(1), new(0), new(0), new(0), new(0), new(0), new(1), new(0), new(1), new(0) };
            //var staiaiait = 6;
            
            var staaart = FSEgeneral.GetDecoded(dictiooonary, staiaiait, reseses);

            Console.ReadKey();
        }
        
    }
    
}