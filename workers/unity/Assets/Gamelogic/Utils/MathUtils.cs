using Assets.Gamelogic.Core;
using Improbable;
using UnityEngine;

namespace Assets.Gamelogic.Utils
{
    public static class MathUtils {

        private const float Epsilon = 0.001f;
        private const float VeryAprox = 0.01f;

        public static Quaternion ToUnityQuaternion(Improbable.Core.Quaternion quaternion)
        {
            return new Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }

        public static Improbable.Core.Quaternion ToNativeQuaternion(Quaternion quaternion)
        {
            return new Improbable.Core.Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }

        public static bool ApproximatelyEqual(Vector3 a, Vector3 b)
        {
            return ApproximatelyEqual(a.x, b.x)
                && ApproximatelyEqual(a.y, b.y)
                && ApproximatelyEqual(a.z, b.z);
        }

        public static bool ApproximatelyEqual(Vector3d a, Vector3d b)
        {
            return ApproximatelyEqual(a.X, b.X)
                && ApproximatelyEqual(a.Y, b.Y)
                && ApproximatelyEqual(a.Z, b.Z);
        }

        public static bool ApproximatelyEqual(Vector3f a, Vector3f b)
        {
            return ApproximatelyEqual(a.X, b.X)
                && ApproximatelyEqual(a.Y, b.Y)
                && ApproximatelyEqual(a.Z, b.Z);
        }

        public static bool ApproximatelyEqual(Coordinates a, Coordinates b)
        {
            return ApproximatelyEqual(a.X, b.X)
                && ApproximatelyEqual(a.Y, b.Y)
                && ApproximatelyEqual(a.Z, b.Z);
        }

        public static bool ApproximatelyEqual(Quaternion a, Quaternion b)
        {
            return ApproximatelyEqual(a.eulerAngles, b.eulerAngles);
        }

        public static bool ApproximatelyEqual(float a, float b)
        {
            return Mathf.Abs(a - b) < Epsilon;
        }

        public static bool ApproximatelyEqual(double a, double b)
        {
            return ApproximatelyEqual((float)a, (float)b);
        }

        public static bool VeryApproximatelyEqual(Vector3 a, Vector3 b)
        {
            return ApproximatelyEqual(a.x, b.x)
                && ApproximatelyEqual(a.y, b.y)
                && ApproximatelyEqual(a.z, b.z);
        }

        public static bool VeryApproximatelyEqual(Quaternion a, Quaternion b)
        {
            return VeryApproximatelyEqual(a.eulerAngles, b.eulerAngles);
        }

        public static bool VeryApproximatelyEqual(float a, float b)
        {
            return Mathf.Abs(a - b) < VeryAprox;
        }

        public static Vector3 GetRandomVector3()
        {
            Vector3 randomPos = Vector3.zero;
            //TODO Make the world map
            //float maxMapX = (SimulationSettings.TerrainTileNumX * SimulationSettings.TerrainTileSizeX) / 2;
            //float maxMapY = (SimulationSettings.TerrainTileNumY * SimulationSettings.TerrainTileSizeY) / 2;
            //randomPos.x = Random.Range(-maxMapX, maxMapX);
            //randomPos.z = Random.Range(-maxMapY, maxMapY);

            return randomPos;
        }
    }

    public static class Vector3Extensions
    {
        public static Coordinates ToCoordinates(this Vector3 vector3)
        {
            return new Coordinates(vector3.x, vector3.y, vector3.z);
        }

        public static Vector3f ToVector3f(this Vector3 vector3)
        {
            return new Vector3f(vector3.x, vector3.y, vector3.z);
        }

        public static Vector3 ToVector3(this Vector3f vector3f)
        {
            return new Vector3(vector3f.X, vector3f.Y, vector3f.Z);
        }
    }

    public static class CoordinatesExtensions
    {
        public static Vector3 ToVector3(this Coordinates coordinates)
        {
            return new Vector3((float)coordinates.X, (float)coordinates.Y, (float)coordinates.Z);
        }
    }
}
