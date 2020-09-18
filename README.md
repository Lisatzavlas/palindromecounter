# palindromecounter

Allow user to enter a paragraph of text and an optional “lookup” letter using Console.WriteLine() and Console.ReadLine() logic.

Call a static function to populate  a Hashtable to get all of the unique words where the words are the keys and the counts are the values.  Use Regex Split function to parse out all of the words into a List by splitting on non-word characters.  Use a foreach loop to go through the List and populate the Hashtable to get the unique words and their counts.

Call a static function to populate  a List with the individual sentences by using the Regex Split function to parse out the sentences by looking for punctuation.  Also loop through and use Regex.Replace remove any characters that are not letters or digits.

Use a foreach to loop through the unique words and check for all palindrome words and add to a palindrome counter, add the unique word and count to information to report on, and (if entered) use Contains to add the word to the list for  the “lookup” letter.

Loop through sentence List and check each for palindrome to add to a counter.

Use Console.WriteLine to report a user-friendly display of: 
   Unique Palindrome word count
   Palindrome Sentence Count
   Unique Word counts:  followed by all words and their individual totals.  
   (if entered) Unique Words containing the “lookup” letter

Use Console.ReadKey() to keep console window open until the user closes it
