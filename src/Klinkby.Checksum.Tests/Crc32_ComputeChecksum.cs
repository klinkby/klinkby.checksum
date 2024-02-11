namespace Klinkby.Checksum.Tests;

[Trait("Category", "Unit")]
public class Crc32_ComputeChecksum
{
    [Fact]
    public void Phrase_Should_Return_Value()
    {
        // arrange
        var text = "Lorem ipsum dolar emit"; 
        var expected = -126186493;
        
        // act
        var actual = Crc32.ComputeChecksum(text);
        
        // assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Empty_Should_Return_Zero()
    {
        // arrange
        var text = string.Empty; 
        var expected = 0;
        
        // act
        var actual = Crc32.ComputeChecksum(text);
        
        // assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Bytes_Should_Return_Value()
    {
        // arrange
        var buffer = "Lorem ipsum dolar emit"u8.ToArray(); 
        var expected = -126186493;
        
        // act
        var actual = Crc32.ComputeChecksum(buffer);
        
        // assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Bytes_Should_Return_Zero()
    {
        var buffer = Array.Empty<byte>(); 
        var expected = 0;
        
        // act
        var actual = Crc32.ComputeChecksum(buffer);
        
        // assert
        Assert.Equal(expected, actual);
    }
}