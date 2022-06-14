using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace IntelliTect.CSharp.CodingGuidelines;

public record struct Coordinate
{
    public double Longitude { get; } = 42;
    public double Latitude { get; } = 77;
    public Coordinate()
    {
    }
}

record class Location (string Name)
{
    public Coordinate Coordinate { get; set; }
}

[TestClass]
public class CoordinateTests
{
    [TestMethod]
    public void CoordinateIsInitializedByConstructor()
    {
        Location location = new ("Timbuktu");
        Assert.AreEqual<double>(0, location.Coordinate.Longitude);
    }
}