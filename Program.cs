using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();


        }


        /*
        
        Question 1:
        
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.
                int firstel = 0;
                int lastel = nums.Length - 1;
                int midel = 0;
                while (firstel <= lastel)
                {
                    midel = (firstel + lastel) / 2;
                    if (target == nums[midel])
                    {
                        return midel;
                    }
                    else if (target < nums[midel])
                    {
                        lastel = midel - 1;
                        firstel++;
                    }
                    else
                        firstel = midel + 1;
                    firstel++;
                }
                return midel + 1;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                //write your code here.
                paragraph = paragraph.ToLower();
                paragraph = paragraph.Replace(',', ' ');
                paragraph = paragraph.Replace('.', ' ');
                paragraph = paragraph.Trim();
                Console.WriteLine("paragraph");
                string[] split = paragraph.Split(' ');
                Dictionary<string, int> map = new Dictionary<string, int>();
                for (int i = 0; i < split.Length; i++)
                {
                    if (map.ContainsKey(split[i]))
                    {
                        map[split[i]]++;
                    }
                    else
                    {
                        map.Add(split[i], 1);
                    }
                    for (int j = 0; j < banned.Length; j++)
                    {
                        if (split[i] == banned[j])
                        {
                            map.Remove(split[i]);
                        }
                    }
                }
                int maxfre = 0;
                string ans = "";
                foreach (KeyValuePair<string, int> kvp in map)
                {
                    if (maxfre < kvp.Value)
                    {
                        maxfre = kvp.Value;
                        ans = kvp.Key;
                    }
                }
                return ans;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.
                Dictionary<int, int> luckynum = new Dictionary<int, int>();   //creating dictonary
                for (int i = 0; i < arr.Length; i++)
                {
                    if (luckynum.ContainsKey(arr[i]))
                    {
                        luckynum[arr[i]]++;
                    }
                    else
                        luckynum.Add(arr[i], 1);
                }
                var val = luckynum.Keys.ToList();
                int ans = -1;
                foreach (var key in val)
                {
                    if (luckynum[key] == key)
                    {
                        ans = (Math.Max(ans, key));
                    }
                }


                return ans;

            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //write your code here.
                int a = 0;
                int b = 0;
                bool[] value = new bool[secret.Length];
                Dictionary<char, int> map = new Dictionary<char, int>();
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i])
                    {
                        a++;
                        value[i] = true;
                    }
                    else
                    {
                        value[i] = false;
                    }
                    if (map.ContainsKey(secret[i]))
                    {
                        map[secret[i]] = map[secret[i]] + 1;
                    }
                    else
                    {
                        map[secret[i]] = 1;
                    }
                }
                for (int j = 0; j < guess.Length; j++)
                {
                    if (value[j]) continue;
                    if (map.ContainsKey(guess[j]) && map[guess[j]] > 0)
                    {
                        b++;
                        map[guess[j]] = map[guess[j]] - 1;
                    }
                }

                string op = a + "A" + b + "B";

                return op;

            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //write your code here.
                int len = s.Length;
                List<int> result = new List<int>();
                int[] map = new int[26];
                for (int i = len - 1; i >= 0; i--)
                {
                    if (map[s[i] - 97] == 0)
                    {
                        map[s[i] - 97] = i;
                    }
                }
                int index = 0;
                while (index < len)
                {
                    int low = index;
                    int hi = map[s[index] - 97];
                    int diff = hi - low + 1;
                    for (int j = low; j <= hi; j++)
                    {
                        if (map[s[j] - 97] > hi)
                        {
                            hi = map[s[j] - 97];
                            diff = hi - low + 1;
                        }

                    }
                    result.Add(diff);
                    index = hi + 1;
                }
                return result;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
       
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //write your code here.
                int line = 1;
                int curr_pixel = 0;
                for (int i = 0; i < s.Length; i++)
                {        // looping over all the character
                    int x = s[i] - 97;                   //finding the ascii code and Substring so that we get the index for the same in th width
                                                         // if (s[i]=='k' || s[i]=='v'){
                                                         //     Console.Write(s[i]);
                                                         // }
                    if (curr_pixel + widths[x] <= 100)
                    {             //check if current line overflow
                        curr_pixel = curr_pixel + widths[x];   //if  not then fill current line pixel
                    }
                    else
                    {
                        curr_pixel = 0;                         //setting curr to 0
                        curr_pixel = curr_pixel + widths[x];    //adding to width
                        line++;                                 //incrementing line
                    }
                }
                List<int> ans = new List<int>();                //creating list for matching the ans format
                ans.Add(line);
                ans.Add(curr_pixel);
                return ans;


            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
       
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //write your code here.
                int s = bulls_string10.Length;
                Stack<char> stk = new Stack<char>();
                for (int i = 0; i < s; i++)
                {
                    if (bulls_string10[i] == '(' || bulls_string10[i] == '{' || bulls_string10[i] == '[')
                    {
                        stk.Push(bulls_string10[i]);
                    }
                    if (bulls_string10[i] == ')' || bulls_string10[i] == '}' || bulls_string10[i] == ']')
                    {
                        if (stk.Count <= 0)
                        {
                            return false;
                        }
                    }
                    if (bulls_string10[i] == ')')
                    {
                        if (stk.Peek() == '(')
                        {
                            stk.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (bulls_string10[i] == '}')
                    {
                        if (stk.Peek() == '{')
                        {
                            stk.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (bulls_string10[i] == ']')
                    {
                        if (stk.Peek() == '[')
                        {
                            stk.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;


            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.
                string[] uniquemorse = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                HashSet<string> set = new HashSet<string>();
                int l = words.Length;
                for (int i = 0; i < l; i++)
                {
                    var sbuilder = new StringBuilder();
                    foreach (var ch in words[i])
                    {
                        sbuilder.Append(uniquemorse[ch - 'a']);
                    }
                    set.Add(sbuilder.ToString());
                }
                return set.Count();


            }
            catch (Exception)
            {
                throw;
            }

        }




    }
}