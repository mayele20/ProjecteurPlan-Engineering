namespace ProjecteurPlan.Core.Geometry;

/// <summary>Rayon : origine + direction unitaire.</summary>
public readonly record struct Ray3D
{
    public Point3D Origin { get; }
    public Vector3D Direction { get; }

    public Ray3D(Point3D origin, Vector3D direction)
    {
        Origin = origin;
        Direction = direction.Normalized();
    }

    public Point3D PointAt(double t) => Origin + Direction * t;

    /// <summary>
    /// Intersection avec un plan. Retourne false si le rayon est parallèle au plan
    /// ou si l'intersection est derrière l'origine (t &lt; 0).
    /// </summary>
    public bool TryIntersect(Plane3D plane, out double distance, out Point3D point)
    {
        distance = 0;
        point = default;

        double denom = Vector3D.Dot(Direction, plane.Normal);
        if (Math.Abs(denom) < Tolerance.Epsilon)
            return false; // parallèle

        double t = Vector3D.Dot(plane.Origin - Origin, plane.Normal) / denom;
        if (t < 0)
            return false; // derrière l'origine

        distance = t;
        point = PointAt(t);
        return true;
    }

    /// <summary>Angle d'incidence par rapport à la normale du plan, dans [0, π/2] : θ = arccos(|d·n|).</summary>
    public double IncidenceAngle(Plane3D plane) =>
        Math.Acos(Math.Min(1.0, Math.Abs(Vector3D.Dot(Direction, plane.Normal))));
}
