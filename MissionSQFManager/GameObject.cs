using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MissionSQFManager
{
    public class GameObject
    {
        public enum Type
        {
            Vehicle,
            Unit
        }

        public GameObject(string className)
        {
            this.className = className;
        }

        public GameObject(Type type, string className, Vector3 position, float direction, string init)
        {
            this.type = type;
            this.className = className;
            this.position = position;
            this.direction = direction;
            this.init = init;
        }

        public GameObject() => Expression.Empty();

        public Type type;
        public string className;
        public Vector3 position;
        public float direction;
        public string init;
    }

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

        public static bool TryParse(string s, out Vector3 result)
        {
            result = new Vector3();

            string[] axes = s.Split(',');

            if (axes.Length <= 1)
            {
                Utils.WriteError($"Failed to parse string {s} to Vector3: there is less than 2 axes in {string.Join(", ", axes)}");
                return false;
            }

            if (float.TryParse(axes[0], out float x))
            {
                result.x = x;
            }
            else
            {
                Utils.WriteError($"Failed to parse Vector3: x axis {axes[0]} is not a float!");
                return false;
            }

            if (float.TryParse(axes[1], out float y))
            {
                result.y = y;
            }
            else
            {
                Utils.WriteError($"Failed to parse Vector3: y axis {axes[1]} is not a float!");
                return false;
            }

            if ((axes.Length > 2) && float.TryParse(axes[2], out float z))
            {
                result.z = z;
            }
            else
            {
                return false;
            }

            //Console.WriteLine("Parsed Vector3: " + result);

            return true;

        }

        public override string ToString()
        {
            return ($"{x}, {y}, {z}");
        }
    }
}
