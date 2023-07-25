using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator
{
	private List<Vector3> mVertices = new List<Vector3>();
	private List<Vector3> mNormals = new List<Vector3>();
	private List<Vector2> mUVs = new List<Vector2>();
	private List<int> mTriangles = new List<int>();
	public List<Color32> colors = new List<Color32>();

	public List<Vector3> Vertices { get { return mVertices; } }
	public List<Vector3> Normals { get { return new List<Vector3>(); } }
	public List<Vector2> UVs { get { return new List<Vector2>(); } }
	//public List <Color32> Colors { get { return new List<Color32>(); } }

	public int countTriangles = 0;

	public void AddTriangle(int pos1,int pos2,int pos3)
	{
		countTriangles++;
		mTriangles.Add(pos1);
		mTriangles.Add(pos2);
		mTriangles.Add(pos3);
	}

	public Mesh GetMesh()
	{
		Mesh mesh = new Mesh();

		mesh.vertices = mVertices.ToArray();
		mesh.triangles = mTriangles.ToArray();
		mesh.colors32 = colors.ToArray();

		if (mNormals.Count == mVertices.Count)
			mesh.normals = mNormals.ToArray();
		
		if(mUVs.Count == mVertices.Count)
			mesh.uv = mUVs.ToArray();

		mesh.RecalculateBounds();
		mesh.RecalculateNormals();

		return mesh;
	}
}
