using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDataStructure {
    public class StringChecker {
        private const char DOT_CHAR = '.';
        private const char NEG_CHAR = '-';
           
        /*
         * Check whether a string is number
         * */
        public bool IsNum(String input) {
            int cntDot = 0;

            for (int i = 0; i < input.Length; i++) {
                char c = input[i];

                //'-' is only at the begin
                if (c == '-' && i != 0)
                    return false;
                //no 2 dots
                //before dot is num
                if (c == DOT_CHAR) {
                    cntDot++;
                    int tmpI = i - 1;
                    if (tmpI >= 0) {
                        if (!IsNumChar(input[tmpI]) || input[tmpI] == NEG_CHAR) {
                            return false;
                        }
                    }
                    //dot at the end
                    if (i == input.Length - 1)
                        return false;
                }
                    
                if (cntDot > 1)
                    return false;

                if (!IsNumChar(c))
                    return false;
            }

            return true;
        }

        private bool IsNumChar(char c) {
            return ((int)c <= 57 && (int)c >= 48) || c == DOT_CHAR || c== NEG_CHAR;
        }

        /*
         * Check whether a string is "palindrome"
         * dynamic programming
         * */
        public bool IsPalindrom(String input) {
            bool result = false;

            return result;
        }

        public void Test() {
            Console.WriteLine("adf : " + IsNum("adf"));
            Console.WriteLine("-.01 : " + IsNum("-.01"));
            Console.WriteLine("7743-111 : " + IsNum("7743-111"));
            Console.WriteLine("2312.123.123 : " + IsNum("2312.123.123"));
            Console.WriteLine("..123123 : " + IsNum("..123123"));
            Console.WriteLine("1231.1232 : " + IsNum("1231.1232"));
        }
    }
}
