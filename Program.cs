/*
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
        public String hash;
        public String nonce;
        //public String               intermediateNonce;
        public String hash_input;
        public int hash_len;
        public String prev_hash;
        public int index;
        public DateTime timestamp;
        public String data;
        public Block nextBlock;
        static public String stringOfZeros;
        HashAlgorithm sha = SHA256.Create();

        public void init(String _prev_hash, int _index, String _data, int difficulty)
        {
            stringOfZeros = "";
            for (int i = 0; i < difficulty; i++)
                stringOfZeros += "0";
            Console.WriteLine("String of Zeros: {0}", stringOfZeros);
            prev_hash = _prev_hash;
            index = _index;
            data = _data;
            //Console.WriteLine("Index: {0}, Hash: {1}", _index, hash);
            //Console.WriteLine("Previous Hash: {0}, Current Hash: {1}", _prev_hash, hash);
            timestamp = DateTime.Now;
            nextBlock = null;
            hash_input = $"Block at {index} index. Prev_hash: {prev_hash ?? ""} Data: {data}";
            hash = byte_array_to_string(sha.ComputeHash(Encoding.ASCII.GetBytes(hash_input)));
            hash_len = hash.Length;
            nonce = "";
            //Console.WriteLine("Original Hash: {0}", hash);
            if (ft_strcmp(hash.Substring(hash_len - difficulty), stringOfZeros) == 1)
            {
                for (int i = 0; i < 30; i++)
                {
                    //Console.WriteLine("Here!");
                    for (int j = -1; j < 128; j++)
                    {
                        if (j == -1)
                        {
                            nonce = "" + (char)i;

                        }
                        else
                        {
                            nonce = "" + (char)i + (char)j;
                        }
                        hash = byte_array_to_string(sha.ComputeHash(Encoding.ASCII.GetBytes(hash_input + nonce)));
                        //Console.WriteLine("Hash: {0}, Nonce: {1}, i: {2}, j: {3}", hash, nonce, i, j);

                        hash_len = hash.Length;
                        //Console.WriteLine()
                        if (ft_strcmp(hash.Substring(hash_len - difficulty), stringOfZeros) == 0)
                        {
                            Console.WriteLine("Here 2");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("Here 3");
        }

        public static int ft_strcmp(String s1, String s2)
        {
            int s1len = s1.Length;
            int s2len = s2.Length;
            if (s1len != s2len)
                return (1);
            int s1ptr = 0;
            int s2ptr = 0;
            while (s2len - s2ptr != 0 && s1len - s1ptr != 0)
            {
                if (s1[s1ptr++] != s2[s2ptr++])
                    return (1);
            }
            if (s2len - s2ptr == 0 && s1len - s1ptr == 0)
                return (0);
            else
                return (1);

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
        public static int difficulty;
        public List<Block> chaind = new List<Block>();
        static Block last_block;
        public void init_chain(String data, int _difficulty)
        {
            difficulty = _difficulty;
            Block head = new Block();
            head.init(null, 0, data, difficulty);
            chaind.Add(head);
            last_block = head;
        }
        public void add_block(String _prev_hash, int _index, String _data)
        {
            last_block.nextBlock = new Block();
            last_block = last_block.nextBlock;
            last_block.init(_prev_hash, _index, _data, difficulty);
            chaind.Add(last_block);
            //Console.WriteLine("Index: {0}, Index in List: {1}", _index, chaind[_index].index);
            //Console.WriteLine("Previous Hash: {0}, Current Hash: {1}", _prev_hash, last_block.hash);
            //Console.WriteLine("Data: {0}, Data in List: {1}", _data, chaind[_index].data);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int difficulty = 1; //how many zeros we want at end of hash
            Chain blockchain = new Chain();
            blockchain.init_chain("First transaction!", difficulty);
            blockchain.add_block(blockchain.chaind[0].hash, 1, "Second transaction");
            blockchain.add_block(blockchain.chaind[1].hash, 2, "Third transaction");
            for (int i = 0; i < blockchain.chaind.Count; i++)
            {
                Console.WriteLine("Index: {0}, Prev_Hash: {1}, Hash: {2}", blockchain.chaind[i].index, blockchain.chaind[i].prev_hash, blockchain.chaind[i].hash);
            }
            Console.WriteLine("{0},{1},{2}", Block.ft_strcmp("00", "abcd00".Substring(3)), Block.ft_strcmp("ab", "a"), Block.ft_strcmp("ababa", "ababab"));
            Console.WriteLine("Yolololo");
        }
    }
}
*/