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
        Vector2[] uv = new Vector2[vertexCount];
		int[] triangles = GetTriangles();
		mesh.vertices = vertices;
		mesh.uv = uv;
        mesh.triangles = triangles;

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
        int index = 0;
        for (int i = vertexCount - 1; i >= 0; i--) {
            v[index++] = new Vector3(radius * Mathf.Cos(Mathf.Deg2Rad * (angle * i + offset)), radius * Mathf.Sin(Mathf.Deg2Rad * (angle * i + offset)), 0);
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
