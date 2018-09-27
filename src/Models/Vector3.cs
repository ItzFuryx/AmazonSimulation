using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    public class Quaternion // Rotation
    {
        public double x = 0;
        public double y = 0;
        public double z = 0;
        public Quaternion ()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        public Quaternion (double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    public class Vector3 // Position
    {
        public float x = 0;
        public float y = 0;
        public float z = 0;

        public Vector3 ()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        public Vector3 (float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static float Distance (Vector3 a, Vector3 b)
        {
            Vector3 distVector = a - b;
            float distance = MathF.Sqrt ((distVector.x * distVector.x) + (distVector.y * distVector.y) + (distVector.z * distVector.z));
            return distance;
        }

        public static Vector3 MoveTowards (Vector3 a, Vector3 b, float step)
        {
            Vector3 toVector = b - a;
            float dist = toVector.magnitude ();

            if (dist <= step || dist < float.Epsilon)
                return b;
            return a + toVector / dist * step;
        }

        public float magnitude ()
        {
            return MathF.Sqrt ((x * x) + (y * y) + (z * z));
        }

        public static Vector3 operator + (Vector3 a, Vector3 b) { return new Vector3 (a.x + b.x, a.y + b.y, a.z + b.z); }
        public static Vector3 operator - (Vector3 a, Vector3 b) { return new Vector3 (a.x - b.x, a.y - b.y, a.z - b.z); }
        public static Vector3 operator / (Vector3 a, float d) { return new Vector3 (a.x / d, a.y / d, a.z / d); }
        public static Vector3 operator * (Vector3 a, float d) { return new Vector3 (a.x * d, a.y * d, a.z * d); }
        public static Vector3 operator * (float d, Vector3 a) { return new Vector3 (a.x * d, a.y * d, a.z * d); }
    }
}