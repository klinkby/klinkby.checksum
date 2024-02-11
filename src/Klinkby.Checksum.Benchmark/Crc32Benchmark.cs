using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace Klinkby.Checksum.Benchmark;

public class Crc32Benchmark
{
    [Benchmark] 
    [ArgumentsSource(nameof(GetBuffers))]
    public int Klinkby_Checksum(byte[] buffer)
    {
        return Crc32.ComputeChecksum(buffer);
    }
    
    [Benchmark(Baseline = true)] 
    [ArgumentsSource(nameof(GetBuffers))]
    public int System_IO_Hashing_Crc32(byte[] buffer)
    {
        return unchecked((int)System.IO.Hashing.Crc32.HashToUInt32(buffer));
    }
    
    public IEnumerable<byte[]> GetBuffers()
    {
        yield return RandomNumberGenerator.GetBytes(32);          // 32 bytes
        yield return RandomNumberGenerator.GetBytes(1024 * 1024); // 1 MB
    }
}