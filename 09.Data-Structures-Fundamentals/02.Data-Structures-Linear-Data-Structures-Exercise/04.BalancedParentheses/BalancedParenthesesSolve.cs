namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Dictionary<char, char> bracketsMap = new Dictionary<char, char>{
            {'{',  '}'},
            {'(',  ')'},
            {'[',  ']'},
              };
            Stack<char> openBrackets = new Stack<char>();

            foreach (char bracket in parentheses)
            {
                if (bracketsMap.ContainsKey(bracket))
                {
                    openBrackets.Push(bracket);
                }
                else
                {
                    if (openBrackets.Count == 0)
                    {
                        return false;
                    }
                    if (bracketsMap[openBrackets.Pop()] == bracket)
                    {
                        continue;
                    };
                    return false;
                }
            }
            return openBrackets.Count == 0;
        }
        }
    } 
