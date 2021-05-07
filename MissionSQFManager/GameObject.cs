using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MissionSQFManager
{
    public class GameObject
    {
        public enum Type
        {
            Object,
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

        public static GameObject Copy(GameObject gameObject)
        {
            return new GameObject(
                gameObject.type,
                gameObject.className,
                gameObject.position,
                gameObject.direction,
                gameObject.init
            );
        }

        public override string ToString()
        {
            string init = !string.IsNullOrEmpty(this.init) ? $", Init: \"{this.init}\"" : "";
            return $"Type: {type},  Classname: {className},  Position: [{position}], Direction: {direction}{init}";
        }
    }
}
