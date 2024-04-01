using Kurmann.Videoschnitt.EntityLib.Entities;

namespace Kurmann.Videoschnitt.EntityLib.Tests.Entities;

[TestClass]
public class SampleEntityTest
{
    [TestMethod]
    public void Create_WithEmptySampleParameter_ReturnsFailure()
    {
        // Arrange
        var sampleParameter = string.Empty;

        // Act
        var result = SampleEntity.Create(sampleParameter);

        // Assert
        Assert.IsTrue(result.IsFailure);
        Assert.AreEqual("Sample parameter cannot be empty", result.Error);
    }
}