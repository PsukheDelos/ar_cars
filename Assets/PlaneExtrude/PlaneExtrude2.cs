using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class PlaneExtrude2 : MonoBehaviour
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

        vertices[0] = Vector3.zero;
        vertices[1] = Vector3.forward;

        vertices[2] = Vector3.up + Vector3.forward;
        vertices[3] = Vector3.up;        

        tris[0] = 0;
        tris[1] = 1;
        tris[2] = 2;

        tris[3] = 2;
        tris[4] = 3;
        tris[5] = 0;

        m_Mesh.vertices = vertices;
        m_Mesh.triangles = tris;
        m_Mesh.RecalculateBounds();
        m_Mesh.RecalculateNormals();

        MeshFilter filter = GetComponent<MeshFilter>();
        filter.sharedMesh = m_Mesh;
	}

    void UpdateRectangle(Vector3 P1,Vector3 P2, Vector3 Dir, float length)
    {
        transform.position = P1;
        transform.localScale = new Vector3(0,length,(P2-P1).magnitude);
        transform.rotation = Quaternion.LookRotation(P2-P1,Dir);
    }
	
	void Update ()
	{
        UpdateRectangle(Point1.position, Point2.position, ExtrudeDir, ExtrudeLength);

	    Debug.DrawRay(Point1.position,ExtrudeDir,Color.yellow);
	}
}
