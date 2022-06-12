using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;


namespace TaskLedas
{
    class Vector3D : IComparable<Vector3D>
    {
        public static int Accuracy { get; set; } = 5;
        private double _x;
        private double _y;
        private double _z;
        /// <summary>
        /// returns X component of vector
        /// </summary>
        public double X
        {
            get => _x;
        }
        /// <summary>
        /// returns Y component of vector
        /// </summary>
        public double Y
        {
            get => _y;
        }
        /// <summary>
        /// returns Z component of vector
        /// </summary>
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

        /// <summary>
        /// returns vector3D with (0,0,0)
        /// </summary>
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
        /// <summary>
        /// finds normalized form of vector
        /// </summary>
        /// <param name="acc"></param>
        /// <returns>returns normalized vector</returns>
        public Vector3D Normalize(double acc = 0.0000001)
        {
            double mag = this.Magnitude();
            if (mag < acc)
            {
                return null;
            }

            return new Vector3D(_x / mag, _y / mag, _z / mag);
        }
        /// <summary>
        /// Find dot product of two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double Dot(Vector3D v1, Vector3D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
        /// <summary>
        /// finds magnitude of vector
        /// </summary>
        /// <returns></returns>
        public double Magnitude()
        {
            return Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns string of type $"x = {X}; y = {Y}; z = {Z}"</returns>
        public override string ToString()
        {
            return $"x = {_x}; y = {_y}; z = {_z}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// returns
        /// 2 if other is null;
        /// 1: if magnitude of other is lower;
        /// 0: if componets are equal;
        /// -1:if magnitude of other is higher
        /// </returns>
        public int CompareTo(Vector3D other)
        {
            if (other == null) return 2;
            if ((Math.Round(_x, Accuracy) == Math.Round(other.X, Accuracy)) &&
                (Math.Round(_y, Accuracy) == Math.Round(other.Y, Accuracy)) &&
                (Math.Round(_z, Accuracy) == Math.Round(other.Z, Accuracy)))
            {
                return 0;
            }
            else if(Math.Round(this.Magnitude(), Accuracy) > Math.Round(other.Magnitude(), Accuracy))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public static bool operator ==(Vector3D v1, Vector3D v2)
        {
            if (v1 is null)
            {
                if (v2 is null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (v1.CompareTo(v2) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool operator !=(Vector3D v1, Vector3D v2)
        {
            return !(v1 == v2);
        }

    }
}