using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lolkilee.UProcBox.Base
{
    /// <summary>
    /// Integer based storage class for storing triangle points
    /// </summary>
    public class IntTriangle
    {
        public uint v1, v2, v3;

        public IntTriangle(uint v1, uint v2, uint v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;

            if (this.v1 < 0 || this.v2 < 0 || this.v3 < 0)
                throw new System.IndexOutOfRangeException();
        }

        public IntTriangle(Vector3 v1, Vector3 v2, Vector3 v3, Vector3[] lookUpArr)
        {
            this.v1 = (uint)System.Array.IndexOf(lookUpArr, v1);
            this.v2 = (uint)System.Array.IndexOf(lookUpArr, v2);
            this.v3 = (uint)System.Array.IndexOf(lookUpArr, v3);

            if (this.v1 < 0 || this.v2 < 0 || this.v3 < 0)
                throw new System.IndexOutOfRangeException();
        }

        public IntTriangle(SIntTriangle data)
        {
            this.v1 = data.v1;
            this.v2 = data.v2;
            this.v3 = data.v3;

            if (this.v1 < 0 || this.v2 < 0 || this.v3 < 0)
                throw new System.IndexOutOfRangeException();
        }

        /// <summary>
        /// Converts the IntTriangle to the Triangle format
        /// </summary>
        /// <param name="baseArray">lookup array for vertices</param>
        /// <returns>The converted Triangle</returns>
        public Triangle ConvertToVectorFormat(Vector3[] baseArray)
        {
            if (v1 >= baseArray.Length || v2 >= baseArray.Length || v3 >= baseArray.Length)
                throw new System.IndexOutOfRangeException();

            return new Triangle(baseArray[v1], baseArray[v2], baseArray[3]);
        }

        /// <summary>
        /// Serializes the IntTriangle to a serializable struct (SIntTriangle)
        /// </summary>
        /// <returns>The serializable object</returns>
        public SIntTriangle Serialize()
        {
            SIntTriangle data = new SIntTriangle();
            data.v1 = this.v1;
            data.v2 = this.v2;
            data.v3 = this.v3;
            return data;
        }

        /// <summary>
        /// Converts a IntTriangle array to the unity specified int array format
        /// </summary>
        /// <param name="triangles">Triangle array to convert</param>
        /// <returns>the converted integer array</returns>
        public static int[] ConvertTriArrayToIndexArray(IntTriangle[] triangles)
        {
            int[] arr = new int[triangles.Length * 3];
            for (int tri = 0; tri < triangles.Length; tri++)
            {
                IntTriangle data = triangles[tri];
                arr[tri * 3] = (int)data.v1;
                arr[tri * 3 + 1] = (int)data.v2;
                arr[tri * 3 + 2] = (int)data.v3;
            }

            return arr;
        }

        /// <summary>
        /// Easy of use function to serialize an array of IntTriangles
        /// </summary>
        /// <param name="triangles">The Triangle array to serialize</param>
        /// <returns>The serializable array</returns>
        public static SIntTriangle[] SerializeArray(IntTriangle[] triangles)
        {
            SIntTriangle[] dataArr = new SIntTriangle[triangles.Length];
            for (int i = 0; i < triangles.Length; i++)
                dataArr[i] = triangles[i].Serialize();

            return dataArr;
        }
    }

    /// <summary>
    /// Serialized integer triangle struct
    /// </summary>
    [System.Serializable]
    public struct SIntTriangle
    {
        public uint v1, v2, v3;
    }
}
