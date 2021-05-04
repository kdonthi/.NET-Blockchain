# .NET-Blockchain

## Introduction
I have created a blockchain using the .NET infrastructure, with my choice of lanaguage being C#. In addition to setting up classes for the Blockchain and Blocks, I have created methods to add blocks, create SHA-256 hashes, and do computational work to find a nonce such that there is one zero at the end of the hash (proof-of-work).

You can set up your own chain by:
  1. Creating a blockchain object with ```Chain blockchain = new Chain();```
  2. Initializing the head node using ```blockchain.init_chain(messaage, difficulty);```. The difficulty is the amount of zeros you want at the end of each hash, and you can set this in the main function.
  3. And last but not least, adding some blocks using ```blockchain.add_block(prev_hash, index, message);```

