using ProjecteurPlan.Core.Geometry;
using ProjecteurPlan.Core.Units;

namespace ProjecteurPlan.Core.Tests;

public class RayPlaneTests
{
    // Mur dans le plan x = 6 m, normale vers -X (vers le projecteur).
    private static readonly Plane3D Wall = new(new Point3D(6, 0, 0), new Vector3D(-1, 0, 0));

    [Fact]
    public void Perpendicular_ray_hits_wall_at_6_m_with_zero_incidence()
    {
        var ray = new Ray3D(new Point3D(0, 1, 2.5), Vector3D.UnitX);

        Assert.True(ray.TryIntersect(Wall, out double d, out Point3D p));
        Assert.Equal(6.0, d, 12);
        Assert.Equal(new Point3D(6, 1, 2.5), p);
        Assert.Equal(0.0, ray.IncidenceAngle(Wall), 12);
    }

    [Fact]
    public void Oblique_ray_at_60_degrees_incidence()
    {
        var dir = new Vector3D(Math.Cos(Angle.FromDegrees(60)), Math.Sin(Angle.FromDegrees(60)), 0);
        var ray = new Ray3D(Point3D.Origin, dir);

        Assert.True(ray.TryIntersect(Wall, out double d, out _));
        Assert.Equal(6.0 / 0.5, d, 9); // 6 / cos(60°) = 12 m
        Assert.Equal(60.0, Angle.ToDegrees(ray.IncidenceAngle(Wall)), 9);
    }

    [Fact]
    public void Ray_parallel_to_wall_does_not_intersect()
    {
        var ray = new Ray3D(Point3D.Origin, Vector3D.UnitY);
        Assert.False(ray.TryIntersect(Wall, out _, out _));
    }

    [Fact]
    public void Ray_pointing_away_does_not_intersect()
    {
        var ray = new Ray3D(Point3D.Origin, -Vector3D.UnitX);
        Assert.False(ray.TryIntersect(Wall, out _, out _));
    }

    [Fact]
    public void Plane_from_three_points_has_expected_normal()
    {
        var plane = Plane3D.FromPoints(new Point3D(0, 0, 0), new Point3D(1, 0, 0), new Point3D(0, 1, 0));
        Assert.Equal(Vector3D.UnitZ, plane.Normal);
    }

    [Fact]
    public void Signed_distance_is_positive_on_normal_side()
    {
        Assert.Equal(2.0, Wall.SignedDistanceTo(new Point3D(4, 0, 0)), 12);
        Assert.Equal(-1.0, Wall.SignedDistanceTo(new Point3D(7, 0, 0)), 12);
    }
}
