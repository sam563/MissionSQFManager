using System;
using System.Diagnostics;
using System.Globalization;

namespace MissionSQFManager
{
    public struct Vector3
    {
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float x;
        public float y;
        public float z;

        public static readonly Vector3 zero = new Vector3(0, 0, 0);
        public static readonly Vector3 one = new Vector3(1, 1, 1);

        public static Vector3 operator+ (Vector3 a, Vector3 b)
        {
            var result = new Vector3
            {
                x = a.x + b.x,
                y = a.y + b.y,
                z = a.z + b.z
            };
            return result;
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            var result = new Vector3
            {
                x = a.x - b.x,
                y = a.y - b.y,
                z = a.z - b.z
            };
            return result;
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            var result = new Vector3
            {
                x = a.x * b.x,
                y = a.y * b.y,
                z = a.z * b.z
            };
            return result;
        }

        public static Vector3 operator *(Vector3 a, float b)
        {
            var result = new Vector3
            {
                x = a.x * b,
                y = a.y * b,
                z = a.z * b
            };
            return result;
        }

        public static Vector3 operator *(Vector3 a, int b)
        {
            var result = new Vector3
            {
                x = a.x * b,
                y = a.y * b,
                z = a.z * b
            };
            return result;
        }

        public static Vector3 operator /(Vector3 a, float b)
        {
            var result = new Vector3
            {
                x = a.x / b,
                y = a.y / b,
                z = a.z / b
            };
            return result;
        }

        public static Vector3 operator /(Vector3 a, int b)
        {
            var result = new Vector3
            {
                x = a.x / b,
                y = a.y / b,
                z = a.z / b
            };
            return result;
        }

        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            var result = new Vector3
            {
                x = a.x / b.x,
                y = a.y / b.y,
                z = a.z / b.z
            };
            return result;
        }

        public static bool TryParse(string s, out Vector3 result)
        {
            //System.Diagnostics.Trace.TraceInformation($"Trying to parse string {s} to Vector3!");

            result = new Vector3();

            string[] axes = s.Split(',');

            //System.Diagnostics.Trace.TraceInformation($"String split into {string.Join(", ", axes)}");

            if (axes.Length < 2 || axes.Length > 3)
            {
                Trace.TraceInformation($"Failed to parse string {s} to Vector3, incorrect number of axes ({axes.Length})");
                return false;
            }

            if (float.TryParse(axes[0], out float x))
            {
                result.x = x;
            }
            else
            {
                Trace.TraceInformation($"Failed to parse Vector3: x axis {axes[0]} is not a float!");
                return false;
            }

            if (float.TryParse(axes[1], out float y))
            {
                result.y = y;
            }
            else
            {
                Trace.TraceInformation($"Failed to parse Vector3: y axis {axes[1]} is not a float!");
                return false;
            }

            if (axes.Length < 3) return true;

            if (float.TryParse(axes[2], out float z))
            {
                result.z = z;
            }
            else
            {
                Trace.TraceInformation($"Failed to parse Vector3: z axis {axes[2]} is not a float!");
                return false;
            }

            //System.Diagnostics.Trace.TraceInformation($"Parsed Vector3 to {result}");

            return true;
        }

        public override string ToString()
        {
            return $"{x}, {y}, {z}";
        }
    }
}
