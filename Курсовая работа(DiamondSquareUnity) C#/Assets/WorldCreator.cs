using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour
{
	public GameObject terra;
	private static int count = 20;

	private void Start()
	{
		TheWorld();
	}

	private void TheWorld()
	{
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < count; j++)
			{
				if (i == count - 1 && j == count - 1)
					break;
				GameObject a = Instantiate(terra) as GameObject;
			}
		}
		
	}
}
