using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lolkilee.UProcBox.Base
{
    /// <summary>
    /// Vector3 based storage class for storing triangle points
    /// </summary>
    public class Triangle
    {
        public Vector3 v1, v2, v3;

        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public Triangle(Vector3[] verts)
        {
            if (verts.Length != 3)
                throw new System.ArgumentOutOfRangeException();

            this.v1 = verts[0];
            this.v2 = verts[1];
            this.v3 = verts[2];
        }

        /// <summary>
        /// Converts the Triangle to the IntTriangle format
        /// </summary>
        /// <param name="baseArray">Base array to take vertex indices from</param>
        /// <returns>The converted IntTriangle</returns>
        public IntTriangle ConvertToIntegerFormat(Vector3[] baseArray)
        {
            return new IntTriangle(v1, v2, v3, baseArray);
        }
    }
}
