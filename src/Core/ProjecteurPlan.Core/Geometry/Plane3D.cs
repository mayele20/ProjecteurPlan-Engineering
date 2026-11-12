namespace ProjecteurPlan.Core.Geometry;

/// <summary>Plan défini par un point et une normale unitaire.</summary>
public readonly record struct Plane3D
{
    public Point3D Origin { get; }
    public Vector3D Normal { get; }

    public Plane3D(Point3D origin, Vector3D normal)
    {
        Origin = origin;
        Normal = normal.Normalized();
    }

    /// <summary>Plan passant par trois points non alignés (normale = (b-a) × (c-a)).</summary>
    public static Plane3D FromPoints(Point3D a, Point3D b, Point3D c) =>
        new(a, Vector3D.Cross(b - a, c - a));

    /// <summary>Distance signée (positive du côté de la normale).</summary>
    public double SignedDistanceTo(Point3D p) => Vector3D.Dot(p - Origin, Normal);
}
