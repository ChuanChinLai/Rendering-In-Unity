using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    public int m_xSize = 0;
    public int m_ySize = 0;

    private Mesh m_mesh;
    private Vector3[] m_vertices;

    private void Awake()
    {
        Generate();
    }


    private void Generate()
    {
        GetComponent<MeshFilter>().mesh = m_mesh = new Mesh();
        m_mesh.name = "Procedural Grid";

        m_vertices = new Vector3[(m_xSize + 1) * (m_ySize + 1)];
        Vector2[] uv = new Vector2[m_vertices.Length];

        Vector4[] tangents = new Vector4[m_vertices.Length];
        Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);

        for (int i = 0, y = 0; y <= m_ySize; y++)
        {
            for (int x = 0; x <= m_xSize; x++, i++)
            {
                m_vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / m_xSize, (float)y / m_ySize);
                tangents[i] = tangent;
            }
        }

        m_mesh.vertices = m_vertices;
        m_mesh.uv = uv;
        m_mesh.tangents = tangents;

        int[] triangles = new int[m_xSize * m_ySize * 6];

        for (int ti = 0, vi = 0, y = 0; y < m_ySize; y++, vi++)
        {
            for (int x = 0; x < m_xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + m_xSize + 1;
                triangles[ti + 5] = vi + m_xSize + 2;
            }
        }

        m_mesh.triangles = triangles;
        m_mesh.RecalculateNormals();
    }


    //private void OnDrawGizmos()
    //{
    //    if (m_vertices == null) return;

    //    Gizmos.color = Color.black;

    //    foreach(Vector3 vertex in m_vertices)
    //    {
    //        Gizmos.DrawSphere(vertex, 0.1f);
    //    }
    //}

}
