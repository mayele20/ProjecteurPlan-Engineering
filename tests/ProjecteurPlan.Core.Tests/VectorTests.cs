using ProjecteurPlan.Core.Geometry;

namespace ProjecteurPlan.Core.Tests;

public class VectorTests
{
    [Fact]
    public void Length_of_3_4_0_is_5() =>
        Assert.Equal(5.0, new Vector3D(3, 4, 0).Length, 12);

    [Fact]
    public void Normalized_has_unit_length() =>
        Assert.Equal(1.0, new Vector3D(2, -3, 6).Normalized().Length, 12);

    [Fact]
    public void Normalizing_zero_vector_throws() =>
        Assert.Throws<InvalidOperationException>(() => Vector3D.Zero.Normalized());

    [Fact]
    public void Cross_of_X_and_Y_is_Z() =>
        Assert.Equal(Vector3D.UnitZ, Vector3D.Cross(Vector3D.UnitX, Vector3D.UnitY));

    [Fact]
    public void Dot_of_orthogonal_vectors_is_zero() =>
        Assert.Equal(0.0, Vector3D.Dot(Vector3D.UnitX, Vector3D.UnitY), 12);

    [Fact]
    public void Angle_between_X_and_Y_is_90_degrees() =>
        Assert.Equal(Math.PI / 2, Vector3D.AngleBetween(Vector3D.UnitX, Vector3D.UnitY), 12);

    [Fact]
    public void Angle_between_opposite_vectors_is_pi() =>
        Assert.Equal(Math.PI, Vector3D.AngleBetween(Vector3D.UnitX, -Vector3D.UnitX), 12);

    [Fact]
    public void Distance_between_points_is_3_4_5() =>
        Assert.Equal(5.0, new Point3D(0, 0, 0).DistanceTo(new Point3D(3, 4, 0)), 12);
}
