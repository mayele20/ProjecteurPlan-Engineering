namespace ProjecteurPlan.Core.Geometry;

/// <summary>Vecteur 3D en double précision (System.Numerics.Vector3 est en float : insuffisant ici).</summary>
public readonly record struct Vector3D(double X, double Y, double Z)
{
    public static Vector3D Zero => new(0, 0, 0);
    public static Vector3D UnitX => new(1, 0, 0);
    public static Vector3D UnitY => new(0, 1, 0);
    public static Vector3D UnitZ => new(0, 0, 1);

    public double Length => Math.Sqrt(Dot(this, this));

    public Vector3D Normalized()
    {
        double len = Length;
        if (len < Tolerance.Epsilon)
            throw new InvalidOperationException("Impossible de normaliser un vecteur nul.");
        return this / len;
    }

    public static double Dot(Vector3D a, Vector3D b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

    public static Vector3D Cross(Vector3D a, Vector3D b) =>
        new(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);

    /// <summary>Angle non orienté entre deux vecteurs, dans [0, π] (radians).</summary>
    public static double AngleBetween(Vector3D a, Vector3D b)
    {
        double denom = a.Length * b.Length;
        if (denom < Tolerance.Epsilon)
            throw new InvalidOperationException("Angle indéfini avec un vecteur nul.");
        double c = Math.Clamp(Dot(a, b) / denom, -1.0, 1.0);
        return Math.Acos(c);
    }

    public static Vector3D operator +(Vector3D a, Vector3D b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Vector3D operator -(Vector3D a, Vector3D b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    public static Vector3D operator -(Vector3D a) => new(-a.X, -a.Y, -a.Z);
    public static Vector3D operator *(Vector3D a, double s) => new(a.X * s, a.Y * s, a.Z * s);
    public static Vector3D operator *(double s, Vector3D a) => a * s;
    public static Vector3D operator /(Vector3D a, double s) => new(a.X / s, a.Y / s, a.Z / s);
}
