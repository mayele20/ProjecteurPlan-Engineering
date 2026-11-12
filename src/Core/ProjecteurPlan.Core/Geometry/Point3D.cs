namespace ProjecteurPlan.Core.Geometry;

/// <summary>Point 3D en mètres.</summary>
public readonly record struct Point3D(double X, double Y, double Z)
{
    public static Point3D Origin => new(0, 0, 0);

    public double DistanceTo(Point3D other) => (other - this).Length;

    public static Vector3D operator -(Point3D a, Point3D b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    public static Point3D operator +(Point3D p, Vector3D v) => new(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    public static Point3D operator -(Point3D p, Vector3D v) => new(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
}
