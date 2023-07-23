using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : MonoBehaviour
{
	public int vertexCount = 3;
	// Start is called before the first frame update
	void Start()
	{
		// Add a mesh
		Mesh mesh = new();
		Vector3[] vertices = GetRegularPolygonVertices();
        // Vector3[] vertices = new Vector3[3]{new Vector3(-1, -0.866025403784439f, 0), new Vector3(0, 0.866025403784439f, 0), new Vector3(1, -0.866025403784439f, 0)};
		Vector2[] uv = new Vector2[vertexCount];
		int[] triangles = GetTriangles();
		mesh.vertices = vertices;
		mesh.uv = uv;
        mesh.triangles = triangles;

        // Display the vertices in Debug
        Debug.Log("Vertices:");
        for (int i = 0; i < vertexCount; i++) {
            Debug.Log(vertices[i]);
        }
        // Display the triangles in Debug
        Debug.Log("Triangles:");
        for (int i = 0; i < triangles.Length; i+=3) {
            Debug.Log(triangles[i] + " " + triangles[i+1] + " " + triangles[i+2]);
        }

		GetComponent<MeshFilter>().mesh = mesh;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private Vector3[] GetRegularPolygonVertices()
	{
		Vector3[] v = new Vector3[vertexCount];
        // get radius of screen -- minimum of width and height
        // float radius = Mathf.Min(Screen.width, Screen.height) / 2;
        float radius = 3f;
        // get angle between vertices
        float angle = 360f / vertexCount;
        float offset = -(90f - angle / 2f);
        // get vertices in clockwise order (bottom left to top left to top right to bottom right)
        Debug.Log("GETTING VERTICES");
        int index = 0;
        for (int i = vertexCount - 1; i >= 0; i--) {
            v[index++] = new Vector3(radius * Mathf.Cos(Mathf.Deg2Rad * (angle * i + offset)), radius * Mathf.Sin(Mathf.Deg2Rad * (angle * i + offset)), 0);
            Debug.Log(v[index-1] + " " + (angle * i + offset));
        }
        
		return v;
	}

    private int[] GetTriangles() {
        int[] t = new int[(vertexCount-2) * 3];
        // simply use the first vertex for each of the triangles
        for (int i = 0; i < vertexCount - 2; i++) {
            t[i*3] = 0;
            t[i*3+1] = i+1;
            t[i*3+2] = i+2;
        }
        return t;
    }
}
