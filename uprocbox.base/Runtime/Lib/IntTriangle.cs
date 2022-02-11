using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lolkilee.UProcBox.Base.Lib
{
    /// <summary>
    /// Integer based storage class for storing triangle points
    /// </summary>
    public class IntTriangle
    {
        public int v1, v2, v3;

        public IntTriangle(int v1, int v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;

            if (v1 < 0 || v2 < 0 || v3 < 0)
                throw new System.IndexOutOfRangeException();
        }

        public IntTriangle(Vector3 v1, Vector3 v2, Vector3 v3, Vector3[] lookUpArr)
        {
            v1 = System.Array.IndexOf(lookUpArr, v1);
            v2 = System.Array.IndexOf(lookUpArr, v2);
            v3 = System.Array.IndexOf(lookUpArr, v3);

            if (v1 < 0 || v2 < 0 || v3 < 0)
                throw new System.IndexOutOfRangeException();
        }
    }
}
