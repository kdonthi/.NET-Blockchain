using System;
using System.Security.Cryptography;
using static System.Security.Cryptography.SHA256; //what does "using static" mean?
using System.Text;
using static System.Text.Encoding;

namespace Blockchain
{
       
    class Block
    {
        String      hash;
        String      prev_hash;
        int         index;
        DateTime    timestamp;
        String      data;
        HashAlgorithm sha = SHA256.Create();
        public void init(String _hash, String _prev_hash, int _index, DateTime _timestamp, String _data)
        {
            prev_hash = _prev_hash;
            index = _index;
            data = _data;
            hash = Program.byte_array_to_string(sha.ComputeHash(Encoding.ASCII.GetBytes(data)));
            timestamp = DateTime.Now;
        }
    }
    class Chain
    {
        Block head;
        Block last_block;
        public void add_block()
        {

        }
    }
    class Program
    {
        public static String base_10_to_16(byte base10)
        {
            String base_16 = "";
            char new_char;
            int mod16;
            while (base10 != 0)
            {
                mod16 = base10 % 16;
                if (mod16 >= 10)
                {
                    new_char = (char) ((mod16 - 10) + 'A');
                }
                else
                {
                    new_char = (char) (mod16 + '0');
                }
                base_16 = new_char + base_16;
                base10 /= 16;
            }
            return (base_16);
        }
        public static String byte_array_to_string(byte[] hash)
        {
            String newString = "";
            foreach (byte b in hash)
            {
                newString = newString + base_10_to_16(b);
            }
            return (newString);
        }
        static void Main(string[] args)
        {
            HashAlgorithm hash = SHA256.Create();
            int counter = 0;
            String input = "Hello";
            byte[] hash_bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(input));
            Console.WriteLine("Input: {0}, SHA-256 Representation: {1}", input, byte_array_to_string(hash_bytes));
        }
    }
}
