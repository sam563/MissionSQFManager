using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            result = new Vector3();

            string[] axes = s.Split(',');

            if (axes.Length < 2 || axes.Length > 3)
            {
                Trace.TraceError($"Failed to parse string {s} to Vector3, inocorrect number of axes ({axes.Length})");
                return false;
            }

            if (float.TryParse(axes[0], out float x))
            {
                result.x = x;
            }
            else
            {
                Trace.TraceError($"Failed to parse Vector3: x axis {axes[0]} is not a float!");
                return false;
            }

            if (float.TryParse(axes[1], out float y))
            {
                result.y = y;
            }
            else
            {
                Trace.TraceError($"Failed to parse Vector3: y axis {axes[1]} is not a float!");
                return false;
            }

            if (axes.Length < 3) return true;

            if (float.TryParse(axes[2], out float z))
            {
                result.z = z;
            }
            else
            {
                Trace.WriteLine(s);
                Trace.TraceError($"Failed to parse Vector3: z axis {axes[2]} is not a float!");
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return ($"{x}, {y}, {z}");
        }
    }
}
