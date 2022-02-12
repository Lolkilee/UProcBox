using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lolkilee.UProcBox.Base
{
    /// <summary>
    /// Base class for all procedurally generated objects
    /// </summary>
    public class ProceduralBase
    {
        public Vector3[] baseArray;
        public IntTriangle[] triangles;

        /// <summary>
        /// Generates the mesh from store base array and triangle data
        /// </summary>
        /// <param name="meshName">Custom name for the mesh, defaults to a Guid</param>
        /// <returns>The generated mesh object</returns>
        public virtual Mesh GenerateMesh(string meshName = "")
        {
            if (baseArray == null || triangles == null)
                throw new System.ArgumentException("base array or triangle array was null!");

            if (meshName == "") meshName = System.Guid.NewGuid().ToString();

            //Generate mesh
            Mesh m = new Mesh();
            m.vertices = baseArray;
            m.triangles = IntTriangle.ConvertTriArrayToIndexArray(triangles);

            return m;
        }

        /// <summary>
        /// Puts the base object data into a serializable struct (SBaseObject)
        /// </summary>
        /// <returns>The serializable struct</returns>
        public SBaseObject Serialize()
        {
            SBaseObject data = new SBaseObject();
            data.baseArray = baseArray;
            data.triangles = IntTriangle.SerializeArray(triangles);
            return data;
        }
    }

    /// <summary>
    /// Serialized base object struct
    /// </summary>
    [System.Serializable]
    public struct SBaseObject
    {
        public Vector3[] baseArray;
        public SIntTriangle[] triangles;
    }
}
