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
    }
}
