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
        public GameObject(string className)
        {
            this.className = className;
        }

        public GameObject(string className, string position, string direction, bool isVectorUp)
        {
            this.className = className;
            this.position = position;
            this.direction = direction;
            this.isVectorUp = isVectorUp;
        }

        public GameObject() => Expression.Empty();

        public string className;
        public string position;
        public string direction;
        public bool isVectorUp;
    }
}
