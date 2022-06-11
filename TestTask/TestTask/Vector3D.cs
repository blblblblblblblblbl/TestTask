using System;


namespace TestTask
{
    class Vector3D
    {
        private double _x;
        private double _y;
        private double _z;
        public double X
        {
            get => _x;
        }
        public double Y
        {
            get => _y;
        }
        public double Z
        {
            get => _z;
        }

        public Vector3D(double x = 0, double y = 0, double z = 0)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public static Vector3D Zero()
        {
            return new Vector3D(0, 0, 0);
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        public static Vector3D operator *(Vector3D v1, double a)
        {
            return new Vector3D(v1.X * a, v1.Y * a, v1.Z * a);
        }
        public static Vector3D operator *(double a, Vector3D v1)
        {
            return v1 * a;
        }

        public double Legth()
        {
            return Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }

        public override string ToString()
        {
            return $"x = {_x}; y = {_y}; z = {_z}";
        }
    }
}