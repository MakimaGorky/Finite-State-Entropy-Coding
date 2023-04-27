

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

            var dictiooonary = InputHandle.GetAlpabet();
            var inpooot = InputHandle.GetMessage(dictiooonary);

            var reseses = FSEgeneral.GetEncoded(dictiooonary, inpooot, out var staiaiait);

            var staaart = FSEgeneral.GetDecoded(dictiooonary, staiaiait, reseses);

            Console.ReadKey();
        }
        
    }
    
}