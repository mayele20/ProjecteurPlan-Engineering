namespace ProjecteurPlan.Core.Units;

/// <summary>Conversions aux frontières du système. En interne : radians.</summary>
public static class Angle
{
    public static double FromDegrees(double deg) => deg * Math.PI / 180.0;
    public static double ToDegrees(double rad) => rad * 180.0 / Math.PI;
}
