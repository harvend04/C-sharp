using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman_to_Int_Leetcode
{
    internal class Program
    {
        static int RomanToInt(string s)
        {
            int total = 0;


            //int NumRet = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int tempNum = 0;
                int uniqueNum = 0;
                switch (s[i])
                {
                    case 'I':
                        tempNum++;
                        break;
                    case 'V':
                        tempNum += 5;
                        break;
                    case 'X':
                        tempNum += 10;
                        break;
                    case 'L':
                        tempNum += 50;
                        break;
                    case 'C':
                        tempNum += 100;
                        break;
                    case 'D':
                        tempNum += 500;
                        break;
                    case 'M':
                        tempNum += 1000;
                        break;

                    default:
                        break;
                }
                if (i == s.Length - 1)
                {
                    total += tempNum;
                }
                else
                {
                    switch (s[i + 1])
                    {
                        case 'I':
                            uniqueNum++;
                            break;
                        case 'V':
                            uniqueNum = 5;
                            break;
                        case 'X':
                            uniqueNum = 10;
                            break;
                        case 'L':
                            uniqueNum = 50;
                            break;
                        case 'C':
                            uniqueNum = 100;
                            break;
                        case 'D':
                            uniqueNum = 500;
                            break;
                        case 'M':
                            uniqueNum = 1000;
                            break;

                        default:
                            break;
                    }
                    if (tempNum < uniqueNum)
                    {
                        tempNum = uniqueNum - tempNum;
                        i++;
                    }
                    total += tempNum;
                }

            }
            return total;
        }
        static void Main(string[] args)
        {
            int outp = RomanToInt("MCMXCIV");
            Console.WriteLine(outp);
        }
    }
}
