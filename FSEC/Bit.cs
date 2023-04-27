using System.Collections;

namespace FSEC;

public struct Bit
{
     private bool _value;

     public Bit(int value)
     {
          this._value = value % 2 == 1;
     }

     public int Value()
     {
          return _value ? 1 : 0;
     }
     
     public override string ToString()
     {
          return _value ? "1" : "0";
     }
}

public static class BitOperation
{
     public static List<Bit> ConvertToBitList(int number, int digCount)
     {
          if (digCount == 0)
          {
               return new List<Bit>(1) { new (0) };
          }
          var bitRepresentation = new List<Bit>(digCount);
          for (int i = 0; i < digCount; i++)
          {
               bitRepresentation.Add(new (number % 2));
               number /= 2;
          }

          bitRepresentation.Reverse();
          
          return bitRepresentation;
     }
}

