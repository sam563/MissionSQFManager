using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MissionSQFManager
{
    public partial class ArrayObjectsForm : Form
    {
        private const string mapDataPath = "Map_Data";

        private GameObject m_referenceGameObject;
        public GameObject ReferenceGameObject
        {
            get => m_referenceGameObject;

            set
            {
                m_referenceGameObject = value;
                classnameText.Text = value.className;
            }
        }

        public ArrayObjectsForm(GameObject referenceObject)
        {
            InitializeComponent();

            InitMapDropDown();

            ReferenceGameObject = referenceObject;
        }

        private string[] GetMaps()
        {
            string mapsPath = Path.Combine(Directory.GetCurrentDirectory(), mapDataPath);

            if (!Directory.Exists(mapsPath)) return null;

            return Directory.GetFiles(mapsPath);
        }

        private void InitMapDropDown()
        {
            string[] maps = GetMaps();

            if (maps == null || maps.Length <= 0) return;

            for (int i = 0; i < maps.Length; i++)
            {
                maps[i] = Path.GetFileNameWithoutExtension(maps[i]);
            }

            mapDropDown.Items.AddRange(maps);
            mapDropDown.Text = maps[0];
        }

        private List<GameObject> GetNewGameObjectInstances()
        {
            string[] maps = GetMaps();

            if (maps == null || maps.Length <= 0) return null;

            string json = File.ReadAllText(maps[mapDropDown.SelectedIndex]);
            Dictionary<string, Transform[]> mapObjects = JsonConvert.DeserializeObject<Dictionary<string, Transform[]>>(json);

            if (!mapObjects.TryGetValue(m_referenceGameObject.className, out Transform[] transforms)) return null;

            List<GameObject> newGameObjects = new List<GameObject>();

            for (int i = 0; i < transforms.Length; i++)
            {
                newGameObjects.AddRange(AddObjectsRelativeToTransform(transforms[i]));
            }

            return newGameObjects;
        }

        private List<GameObject> AddObjectsRelativeToTransform(Transform transform)
        {
            if (!Vector3.TryParse(transform.position, out Vector3 refPosition)) return null;
            if (!float.TryParse(transform.direction, out float refDirection)) refDirection = 0; //maybe return

            List<GameObject> gameObjects = new List<GameObject>();

            for (int i = 0; i < SQFMMForm.GameObjects.Length; i++)
            {
                GameObject refGO = SQFMMForm.GameObjects[i];

                float rotationInRadians = (refDirection - refGO.direction) * ((float)Math.PI / 180f);

                //Rotate position of object around our refPosition
                float x = (float)(refPosition.x + (refGO.position.x - refPosition.x) * Math.Cos(rotationInRadians) - (refGO.position.y - refPosition.y) * Math.Sin(rotationInRadians));
                float y = (float)(refPosition.x + (refGO.position.x - refPosition.x) * Math.Sin(rotationInRadians) + (refGO.position.y - refPosition.y) * Math.Cos(rotationInRadians));

                Vector3 position = new Vector3(x, y, refGO.position.z);
                float direction = refDirection + refGO.direction;

                gameObjects.Add(new GameObject(refGO.type, refGO.className, position, direction, refGO.init));
            }

            return gameObjects;
        }

        public struct Transform
        {
            public string position;
            public string direction;
        }

        private void ArrayObjectsButton_Click(object sender, EventArgs e)
        {
            var objects = GetNewGameObjectInstances();

            if (objects != null && objects.Count > 0)
            {
                SQFMMForm.GameObjects = objects.ToArray();
            }

            Hide();
        }
    }
}
