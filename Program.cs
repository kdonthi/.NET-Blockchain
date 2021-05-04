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
        public String       hash;
        public String       prev_hash;
        public int          index;
        public DateTime     timestamp;
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
        public List<Block> chaind = new List<Block>();
        static Block last_block;
        public void init_chain(String data)
        {
            Block head = new Block();
            head.init(null, 0, data);
            chaind.Add(head);
            last_block = head;
        }
        public void add_block(String _prev_hash, int _index, String _data)
        {
            last_block.nextBlock = new Block();
            last_block.nextBlock.prev_hash = _prev_hash;
            last_block.nextBlock.index = _index;
            last_block.nextBlock.data = _data;
            last_block = last_block.nextBlock;
            chaind.Add(last_block);
            Console.WriteLine("Index: {0}, Index in List: {1}", _index, chaind[_index].index);
            Console.WriteLine("Data: {0}, Data in List: {1}", _data, chaind[_index].data);
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Chain blockchain = new Chain();
            blockchain.init_chain("First transaction");
            blockchain.add_block(blockchain.chaind[0].hash, 1, "Second transaction");
            blockchain.add_block(blockchain.chaind[1].hash, 2, "Third transaction");
            for (int i = 0; i < blockchain.chaind.Count; i++)
            {
                Console.WriteLine(blockchain.chaind[i].index);
            }
        }
    }
}
