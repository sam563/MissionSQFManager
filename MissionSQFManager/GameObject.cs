using System;
using System.Globalization;
using System.Linq.Expressions;

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

        public string GetDirectionAsString()
        {
            float direction = SQFMMForm.normalizeDirection ? (this.direction % 360 + 360) % 360 : this.direction;
            return (Math.Round(direction, SQFMMForm.decimalPlaces).ToString(CultureInfo.InvariantCulture));
        }

        public string GetPositionAsString()
        {
            return (Math.Round(position.x, SQFMMForm.decimalPlaces).ToString(CultureInfo.InvariantCulture) + ", " + Math.Round(position.y, SQFMMForm.decimalPlaces).ToString(CultureInfo.InvariantCulture) + ", " + Math.Round(position.z, SQFMMForm.decimalPlaces).ToString(CultureInfo.InvariantCulture));
        }

        public override string ToString()
        {
            string init = !string.IsNullOrEmpty(this.init) ? $", Init: \"{this.init}\"" : "";
            return $"Type: {type},  Classname: {className},  Position: [{position}], Direction: {direction}{init}";
        }
    }
}
