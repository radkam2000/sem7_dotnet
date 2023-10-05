using Xunit;

namespace z.Test;

public class UnitTest1
{
    [Fact]
    public void FormatUsdPrice_ProperFormat_ShouldReturnProperString()
    {
        var data = 0.05;

        var result = MyFormatter.FormatUsdPrice(data);

        Assert.StartsWith("$0", result);
        Assert.Contains(".", result);
        Assert.EndsWith("05", result);

    }
}