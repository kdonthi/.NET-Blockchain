using System;
using System.Security.Cryptography;
using static System.Security.Cryptography.SHA256; //what does "using static" mean?
using System.Text;
using static System.Text.Encoding;
using System.Collections.Generic;

namespace Blockchain
{
    public class Block
    {
        String              hash;
        public String       prev_hash;
        public int          index;
        DateTime            timestamp;
        public String       data;
        public Block        nextBlock;
        HashAlgorithm sha = SHA256.Create();

        public void init(String _prev_hash, int _index, String _data)
        {
            prev_hash = _prev_hash;
            index = _index;
            data = _data;
            hash = byte_array_to_string(sha.ComputeHash(Encoding.ASCII.GetBytes($"Block at {index} index. Hash: {hash ?? ""} Data: {data}")));
            timestamp = DateTime.Now;
            nextBlock = null;
        }

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
                    new_char = (char)((mod16 - 10) + 'A');
                }
                else
                {
                    new_char = (char)(mod16 + '0');
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
    }

    class Chain
    {
        static List<Block> chain = new List<Block>();
        static Block last_block;
        public void init_chain()
        {
            Block head = new Block();
            head.init(null, 0, "First block.");
            chain.Add(head);
            last_block = head;
        }
        public void add_block(String _prev_hash, int _index, String _data)
        {
            last_block.nextBlock = new Block();
            last_block.nextBlock.prev_hash = _prev_hash;
            last_block.nextBlock.index = _index;
            last_block.nextBlock.data = _data;
            last_block = last_block.nextBlock;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashAlgorithm hash = SHA256.Create();
            String input = "Hello";
            byte[] hash_bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(input));
            Console.WriteLine("Input: {0}, SHA-256 Representation: {1}", input, Block.byte_array_to_string(hash_bytes));
        }
    }
}
