using System;
using System.Text;

namespace Klinkby.Checksum;

/// <summary>
///     Computes a CRC32 checksum.
/// </summary>
/// <remarks>Based on <see href="http://sanity-free.org/12/crc32_implementation_in_csharp.html" /></remarks>
public static class Crc32
{
    private static readonly uint[] Table = CreateTable();

    static Crc32()
    {
    }

    /// <summary>
    ///     Compute the checksum of a UTF8 text.
    /// </summary>
    /// <param name="text">Text to calculate</param>
    /// <returns>Checksum</returns>
    public static int ComputeChecksum(string text)
    {
        return ComputeChecksum(text, Encoding.UTF8);
    }

    /// <summary>
    ///     Compute the checksum of a text using a specific encoding.
    /// </summary>
    /// <param name="text">Text to calculate</param>
    /// <param name="encoding">Text encoding</param>
    /// <returns>Checksum</returns>
    public static int ComputeChecksum(string? text, Encoding encoding)
    {
        if (string.IsNullOrEmpty(text)) return 0;
        var bytes = encoding.GetBytes(text);
        return ComputeChecksum(bytes);
    }

    /// <summary>
    ///     Compute the checksum of a binary buffer.
    /// </summary>
    /// <param name="bytes">Buffer to calculate</param>
    /// <returns></returns>
    public static int ComputeChecksum(ReadOnlySpan<byte> bytes)
    {
        var crc = 0xffffffff;
        var length = bytes.Length;
        for (var i = 0; i < length; ++i)
        {
            var index = (byte)((crc & 0xff) ^ bytes[i]);
            crc = (crc >> 8) ^ Table[index];
        }

        return unchecked((int)~crc);
    }

    private static uint[] CreateTable()
    {
        const uint poly = 0xedb88320;
        var table = new uint[256];
        for (uint i = 0; i < table.Length; ++i)
        {
            var temp = i;
            for (var j = 8; j > 0; --j)
                if ((temp & 1) == 1)
                    temp = (temp >> 1) ^ poly;
                else
                    temp >>= 1;
            table[i] = temp;
        }

        return table;
    }
}