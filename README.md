Klinkby.Checksum
---

Simply calculates a CRC32 checksum based on a UTF-8 string or ReadOnlySpan<byte> (byte array).

For most practical use cases you will probably want to use System.IO.Hashing.Crc32 instead as the 
library is 10-29 times faster on a 2024 x64 processor. See the Benchmark project for reference.
