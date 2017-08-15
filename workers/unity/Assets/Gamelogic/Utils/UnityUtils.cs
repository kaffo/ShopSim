using UnityEngine;

namespace Assets.Gamelogic.Utils
{
    public static class UnityUtils
    {
        public static GameObject SearchForGameObject(GameObject[] gameobjectList, string nameToFind)
        {
            GameObject found = null;

            foreach (GameObject go in gameobjectList)
            {
                if (go.name == nameToFind)
                {
                    found = go;
                    break;
                }
            }
            return found;
        }

        public static Vector3 WithX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        public static Vector3 WithY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        public static Vector3 WithZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }
    }
}