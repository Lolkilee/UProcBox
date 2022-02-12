using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lolkilee.UProcBox.Base
{
    /// <summary>
    /// Storage class for storing multiple triangles (usefull for things like hexagons)
    /// </summary>
    public class Polygon
    {
        public IntTriangle[] triangles;

        public Polygon(IntTriangle[] triangles)
        {
            this.triangles = triangles;
        }

        public Polygon(Triangle[] triangles, Vector3[] baseArray)
        {
            IntTriangle[] iTriangles = new IntTriangle[triangles.Length];
            for (int i = 0; i < iTriangles.Length; i++)
                iTriangles[i] = triangles[i].ConvertToIntegerFormat(baseArray);
        }
    }
}
