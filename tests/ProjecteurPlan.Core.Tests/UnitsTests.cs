using ProjecteurPlan.Core.Units;

namespace ProjecteurPlan.Core.Tests;

public class UnitsTests
{
    [Fact]
    public void Millimeters_round_trip() =>
        Assert.Equal(1.5, Length.FromMillimeters(Length.ToMillimeters(1.5)), 12);

    [Fact]
    public void One_foot_is_0_3048_m() =>
        Assert.Equal(0.3048, Length.FromFeet(1), 12);

    [Fact]
    public void Feet_round_trip() =>
        Assert.Equal(10.0, Length.ToFeet(Length.FromFeet(10.0)), 12);

    [Fact]
    public void Degrees_to_radians() =>
        Assert.Equal(Math.PI / 2, Angle.FromDegrees(90), 12);

    [Fact]
    public void Radians_to_degrees() =>
        Assert.Equal(180.0, Angle.ToDegrees(Math.PI), 12);
}
