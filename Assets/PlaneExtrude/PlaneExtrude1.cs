using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class PlaneExtrude1 : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;
    public float ExtrudeLength = 5.0f;
    public Vector3 ExtrudeDir = Vector3.up;

    private Mesh m_Mesh = null;
	void Start ()
	{
        m_Mesh = new Mesh();
        Vector3[] vertices = new Vector3[4];
        int[] tris = new int[6];
        for (int i = 0;i<4;i++)
            vertices[i] = new Vector3();        
        
        tris[0] = 0;
        tris[1] = 1;
        tris[2] = 2;

        tris[3] = 2;
        tris[4] = 3;
        tris[5] = 0;


        m_Mesh.vertices = vertices;
        m_Mesh.triangles = tris;
        MeshFilter filter = GetComponent<MeshFilter>();
        filter.sharedMesh = m_Mesh;
	}

    void UpdateMesh(Vector3 P1,Vector3 P2, Vector3 Dir, float length)
    {
        Vector3[] vertices = m_Mesh.vertices;
        Vector3 P12 = P2-P1;
        Vector3 normal = Vector3.Cross(P12,Dir);
        Vector3 newDir = Vector3.Cross(normal,P12).normalized * length;

        vertices[0] = P1;
        vertices[1] = P2;

        vertices[2] = P2 + newDir;
        vertices[3] = P1 + newDir;

        m_Mesh.vertices = vertices;
        m_Mesh.RecalculateBounds();
        m_Mesh.RecalculateNormals();
    }
	
	void Update ()
	{
        UpdateMesh(Point1.position, Point2.position, ExtrudeDir, ExtrudeLength);
	
        Debug.DrawRay(Point1.position,ExtrudeDir,Color.yellow);
	}
}
