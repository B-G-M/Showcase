using System;
using UnityEngine;
public class TerraCreator : MonoBehaviour
{
	private static int count = 20;
	private static int iWorld = 0;
	private static int jWorld = 0;
	private static int x, z;
	private int n = 15;
	private int quality = 128;
	private float mWidth;
	private Vector3 step;

	private DiamondSquare diamondSquare;
	static private DiamondSquare[,] world = new DiamondSquare[100, 100];

	private void ConstructQuadForMesh(MeshCreator meshCreator, Vector3 position,
		bool buildTriangles, int vertsPerRow)
	{
		meshCreator.Vertices.Add(position);

		if (!buildTriangles)
			return;

		int basePos = meshCreator.Vertices.Count - 1;

		int pos0 = basePos;
		int pos1 = basePos - 1;
		int pos2 = basePos - vertsPerRow;
		int pos3 = basePos - vertsPerRow - 1;

		meshCreator.AddTriangle(pos0, pos2, pos1);
		meshCreator.AddTriangle(pos2, pos3, pos1);

	}

	public void Start()
	{
		MeshCreator meshCreator = new MeshCreator();

		mWidth = (float)Math.Pow(2, n) + 1;
		float scale = mWidth / quality;//размер сегментов

		int mapRang = (int)Mathf.Sqrt((quality + 1) * (quality + 1));
		int lenght = 0;
		for (int i = 0; lenght < mapRang; i++)
		{
			lenght = (int)Mathf.Pow(2, i) + 1;
		}

		diamondSquare = new DiamondSquare();
		diamondSquare.heightMap = new float[lenght, lenght];

		if (jWorld != 0)
		{

			for (int i = 0; i < lenght; i++)
			{
				diamondSquare.heightMap[i, 0] = world[iWorld, jWorld - 1].heightMap[i, world[iWorld, jWorld - 1].mapRang - 1];
				diamondSquare.heightMap[i, 1] = world[iWorld, jWorld - 1].heightMap[i, world[iWorld, jWorld - 1].mapRang - 2];
				//diamondSquare.heightMap[i, 2] = world[iWorld, jWorld - 1].heightMap[i, world[iWorld, jWorld - 1].mapRang - 3];
			}
		}
		if (iWorld != 0)
		{
			for (int i = 0; i < lenght; i++)
			{
				diamondSquare.heightMap[0, i] = world[iWorld - 1, jWorld].heightMap[world[iWorld - 1, jWorld].mapRang - 1, i];
				diamondSquare.heightMap[1, i] = world[iWorld - 1, jWorld].heightMap[world[iWorld - 1, jWorld].mapRang - 2, i];
				//diamondSquare.heightMap[2, i] = world[iWorld - 1, jWorld].heightMap[world[iWorld - 1, jWorld].mapRang - 3, i];
			}
		}

		diamondSquare.Nachalo(lenght, scale);
		for (int i = 0; i <= lenght - 1; i++)
		{
			float z = scale * i;
			float y;
			for (int j = 0; j <= lenght - 1; j++)
			{
				float x = scale * j;

				y = diamondSquare.GetY(i, j);
				if (y < 0.0f)
					y = -0.1f;

				meshCreator.colors.Add(diamondSquare.GetColor(y));

				Vector3 offset = new Vector3(x, y, z);

				bool buildTriangles = i > 0 && j > 0;

				ConstructQuadForMesh(meshCreator, offset, buildTriangles, lenght);
			}
		}

		Mesh mesh = meshCreator.GetMesh();

		gameObject.transform.position = new Vector3(x, 0, z);

		world[iWorld, jWorld] = diamondSquare;
		if (step != null)
			step = meshCreator.Vertices[meshCreator.Vertices.Count - 1];

		x += (int)step.x;
		jWorld++;
		if (jWorld == count)
		{
			jWorld = 0;
			iWorld++;
			x = 0;
			z += (int)step.x;
		}
		MeshFilter filter = GetComponent<MeshFilter>();

		if (filter != null)
			filter.sharedMesh = mesh;
	}
}
