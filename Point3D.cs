﻿
public class Point3D
{
    private int[] coordinates = new int[3]; // X, Y, Z
    private double mass;

    public int X
    {
        get { return coordinates[0]; }
        set { coordinates[0] = value; }
    }

    public int Y
    {
        get { return coordinates[1]; }
        set { coordinates[1] = value; }
    }

    public int Z
    {
        get { return coordinates[2]; }
        set { coordinates[2] = value; }
    }

    public double Mass
    {
        get { return mass; }
        set { mass = value < 0 ? 0 : value; }
    }

    public Point3D(int x, int y, int z, double mass)
    {
        X = x;
        Y = y;
        Z = z;
        Mass = mass;
    }

    public bool IsZero()
    {
        return X == 0 && Y == 0 && Z == 0;
    }

    public double DistanceTo(Point3D other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other), "The other point cannot be null.");

        int dx = X - other.X;
        int dy = Y - other.Y;
        int dz = Z - other.Z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
}