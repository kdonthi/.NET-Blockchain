using System;

namespace Blockchain
{
    HashAlgorithm sha = SHA256.Create();
    class Block
    {
        String      hash;
        String      prev_hash;
        int         index;
        DateTime    timestamp;
        String      data;

        public void init(String _hash, String _prev_hash, int _index, DateTime _timestamp, String _data)
        {
            prev_hash = _prev_hash;
            index = _index;
            data = _data;
            hash = sha. //we need to create this hash anew
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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
