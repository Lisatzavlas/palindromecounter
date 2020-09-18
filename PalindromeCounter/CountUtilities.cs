using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
public static class CountUtilities
    {

        //Return the reverse of a string
        public static string GetReverse(string inString)
        {
            char[] temp = inString.ToCharArray();
            Array.Reverse(temp);
            return new string(temp);
        }

        //Return if string is a palindrome
        public static bool IsAPalindrome(string testString)
        {
            if (string.IsNullOrEmpty(testString) || testString.Length == 1) return true;
            return testString.ToLower() == GetReverse(testString).ToLower();
        }

        //Populate Hashtable with unique words as key and the count as value
        public static Hashtable GetUniqueWords(string testString)
        {
            Hashtable uniqueWords = new Hashtable();
            List<string> words = new List<string>();

            //Split on non-Word character
            Regex regexPattern = new Regex(@"[\s\W]", RegexOptions.IgnoreCase);
            words = regexPattern.Split(testString).ToList<string>();

            foreach (string word in words)
            {
                //Get rid of any non-word characters in each word/sentence
                if (word.Length == 0) continue;

                //Add and set value at 1 if new or increment if already exists
                if (!uniqueWords.ContainsKey(word.ToLower())) uniqueWords.Add(word.ToLower(), 1);
                else uniqueWords[word.ToLower()] = (int)uniqueWords[word.ToLower()] + 1;
            }

            return uniqueWords;
        }

        //Populate List with sentences split by punctuation
        public static List<string> GetSentences(string testString)
        {
            List<string> sentences = new List<string>();

            //Split on at least 1 punctuation
            Regex regexPattern = new Regex(@"[.!?]+", RegexOptions.IgnoreCase);

            sentences = regexPattern.Split(testString).ToList<string>();

            //Get rid of any non-word characters in each word/sentence
            for (int i=0;i<sentences.Count;i++)
            {
                sentences[i] = Regex.Replace(sentences[i], @"[^a-zA-Z0-9]", "").ToLower();
            }

            return sentences;
        }
    }