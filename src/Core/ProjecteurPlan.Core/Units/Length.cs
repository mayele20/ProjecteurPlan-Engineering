namespace ProjecteurPlan.Core.Units;

/// <summary>Conversions aux frontières du système. En interne : mètres.</summary>
public static class Length
{
    public const double MetersPerFoot = 0.3048; // pied international (unité interne de Revit)

    public static double FromMillimeters(double mm) => mm / 1000.0;
    public static double ToMillimeters(double m) => m * 1000.0;
    public static double FromFeet(double feet) => feet * MetersPerFoot;
    public static double ToFeet(double m) => m / MetersPerFoot;
}
