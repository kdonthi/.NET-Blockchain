# .NET-Blockchain

## Introduction
I have created a blockchain (code found in ```Program.cs```) using the .NET infrastructure and C#. In addition to setting up classes for the blockchain and blocks, I have created methods to add blocks, find SHA-256 hashes, and carry out computational work to find a nonce such that there is one zero at the end of the hash (proof-of-work).

You can set up your own chain by:
  1. Creating a blockchain object with ```Chain blockchain = new Chain();```
  2. Initializing the head node by using ```blockchain.init_chain(messaage, difficulty);```. The difficulty is the amount of zeros you want at the end of each hash which can be set this in the main function of the ```Program``` class.
  3. And last but not least, adding some blocks using ```blockchain.add_block(prev_hash, index, message);```



