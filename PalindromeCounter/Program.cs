using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PalindromeCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get user input 
            Console.WriteLine("Enter a paragraph of text and hit Enter to analyze it for palindromes.");
            string inParagraph = Console.ReadLine();

            //Continue if user entered anything
            if (inParagraph.Length > 0)
            {
                //Ask user if they optionally want to find instances of a letter
                Console.WriteLine();
                Console.WriteLine("(Optional) Enter a letter to receive a list of unique words containing that letter then hit Enter.");
                string lookupLetter = Console.ReadLine();

                //Get Hashtable of unique words - Key = word, Value = count
                Hashtable uniqueWords = CountUtilities.GetUniqueWords(inParagraph);
                //Get list of sentences 
                List<string> allSentences = CountUtilities.GetSentences(inParagraph);

                int palindromeWordCount = 0; 
                int palindromeSentenceCount = 0;
                string uniqueWordReport = "UNIQUE WORD COUNTS\r\n";
                string lookupLetterReport = null;
                
                if (lookupLetter.Length > 0) lookupLetterReport = $"UNIQUE WORDS CONTAINING \"{lookupLetter}\"\r\n";

                //Loop through unique words and check for palindrome to add to counter
                //Add unique word and count to info to report
                //If user entered optional letter and the word contains that letter, add info to report
                foreach (DictionaryEntry word in uniqueWords)
                {
                    if (CountUtilities.IsAPalindrome(word.Key.ToString())) palindromeWordCount++;
                    uniqueWordReport += $"{word.Key} ({word.Value})\r\n";
                    if (lookupLetter.Length > 0)
                    {
                        if (word.Key.ToString().ToLower().Contains(lookupLetter.ToLower())) lookupLetterReport += $"{word.Key}\r\n";
                    }
                }

                //Check each sentence to see if it is a palindrome to add to counter
                foreach (string sentence in allSentences)
                {
                    if (string.IsNullOrEmpty(sentence)) continue;
                    if (CountUtilities.IsAPalindrome(sentence)) palindromeSentenceCount++;
                }

                //Return prettified results
                Console.WriteLine();
                Console.WriteLine($"UNIQUE PALINDROME WORD COUNT: {palindromeWordCount}");
                Console.WriteLine($"PALINDROME SENTENCE COUNT: {palindromeSentenceCount}");
                Console.WriteLine();
                Console.WriteLine(uniqueWordReport);
                Console.WriteLine();
                if (!string.IsNullOrEmpty(lookupLetter)) Console.WriteLine(lookupLetterReport);

                //Wait for user to press a key so that console window doesn't close before they can read it
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

            }
        }
    }
}
