using System.Collections.Generic;
using UnityEngine;
//using System;

//Here, code praying to the GOD for protecting our open file from all bugs and other things.
//This is really crucial step! Be adviced to not remove it, even if don't believer.
//Rahman ve Rehim olan Allan'in in adiyla

public class IJ
{
	public IJ(int I, int J)
	{
		i = I;
		j = J;
	}

	public int i { get; set; }
	public int j { get; set; }
}


public class DiamondSquare : MonoBehaviour
{
	static private float upperRange = 10.0f;
	static private float lowerRange = 1f;
	static private float roughness = 0.25f;
	private float outOfBoundsH;
	private int fourPow = 0;
	public int mapRang = 0;

	static private int wet;
	private float maxY = 0;
	private float minY = 0;

	private float unit;
	private int step;
	private int aslant;

	public float[,] heightMap;

	private List<IJ> diamond = new List<IJ>();

	private Color32[,] colorsArr;

	public float GetY(int i, int j)
	{
		return heightMap[i, j];
	}

	public Color32 GetColor(float Y)
	{
		int stepColor = (int)maxY / 4;
		float y = Y;
		if (Y < 0)
			return new Color32(4, 99, 255, 50);
		//if (Y >= 0)
			//return new Color32(196, 212, 170, 255);

		int index = (int)(y / stepColor);

		if (index >= 4)
		{
			return colorsArr[3, wet];
		}
		try
		{
			return colorsArr[index, wet];
		}
		catch (System.Exception)
		{
			return colorsArr[0, 0];
		}
	}

	public void TerraForm()
	{
		if (true)
		{
			colorsArr = new Color32[4, 6];
			colorsArr[0, 0] = new Color32(233, 221, 199, 255);
			colorsArr[0, 1] = new Color32(196, 212, 170, 255);
			colorsArr[0, 2] = new Color32(169, 204, 164, 255);
			colorsArr[0, 3] = new Color32(169, 204, 164, 255);
			colorsArr[0, 4] = new Color32(156, 187, 169, 255);
			colorsArr[0, 5] = new Color32(156, 187, 169, 255);
			colorsArr[1, 0] = new Color32(228, 232, 202, 255);
			colorsArr[1, 1] = new Color32(196, 212, 170, 255);
			colorsArr[1, 2] = new Color32(196, 212, 170, 255);
			colorsArr[1, 3] = new Color32(180, 201, 169, 255);
			colorsArr[1, 4] = new Color32(180, 201, 169, 255);
			colorsArr[1, 5] = new Color32(164, 196, 168, 255);
			colorsArr[2, 0] = new Color32(228, 232, 202, 255);
			colorsArr[2, 1] = new Color32(228, 232, 202, 255);
			colorsArr[2, 2] = new Color32(196, 204, 187, 255);
			colorsArr[2, 3] = new Color32(196, 204, 187, 255);
			colorsArr[2, 4] = new Color32(204, 212, 187, 255);
			colorsArr[2, 5] = new Color32(204, 212, 187, 255);
			colorsArr[3, 0] = new Color32(228, 229, 220, 255);
			colorsArr[3, 1] = new Color32(238, 240, 225, 255);
			colorsArr[3, 2] = new Color32(221, 221, 187, 255);
			colorsArr[3, 3] = new Color32(248, 248, 248, 255);
			colorsArr[3, 4] = new Color32(252, 252, 252, 255);
			colorsArr[3, 5] = new Color32(255, 255, 255, 255);

		}

		wet = UnityEngine.Random.Range(wet - 1, wet + 2);
		if (wet > 5)
			wet = 5;
		if (wet < 0)
			wet = 0;

		if (wet == 0)
			roughness = 0.1f;
		if (wet == 1)
			roughness = 0.15f;
		if (wet == 2)
			roughness = 0.2f;
		if (wet == 3)
			roughness = 0.25f;
		if (wet == 4)
			roughness = 0.3f;

		outOfBoundsH = upperRange * roughness;

		IJ start = new IJ(0, 0);
		IJ finish = new IJ(mapRang - 1, mapRang - 1);

		IJ[] square = new IJ[4];
		square[0] = start;
		square[1] = new IJ(start.i, finish.j);
		square[2] = new IJ(finish.i, start.j);
		square[3] = finish;

		step = (int)Mathf.Sqrt(heightMap.Length);

		aslant = step;


		//Задаем случайниые высоты углам
		if (heightMap[start.i, start.j] == 0)
			heightMap[start.i, start.j] = UnityEngine.Random.Range(lowerRange, upperRange);
		if (heightMap[start.i, finish.j] == 0)
			heightMap[start.i, finish.j] = UnityEngine.Random.Range(lowerRange, upperRange);
		if (heightMap[finish.i, finish.j] == 0)
			heightMap[finish.i, finish.j] = UnityEngine.Random.Range(lowerRange, upperRange);
		if (heightMap[finish.i, start.j] == 0)
			heightMap[finish.i, start.j] = UnityEngine.Random.Range(lowerRange, upperRange);
		

		Diamond(square, true);

		for (int i = 0; i < mapRang; i++)
		{
			heightMap[i, mapRang - 1] = heightMap[i, mapRang - 3];
			heightMap[i, mapRang - 2] = heightMap[i, mapRang - 3];
		}
		for (int i = 0; i < mapRang; i++)
		{
			heightMap[mapRang - 1, i] = heightMap[mapRang - 3, i];
			heightMap[mapRang - 2, i] = heightMap[mapRang - 3, i];
			
		}
	}

	private void Diamond(IJ[] square, bool down)
	{

		diamond.Add(new IJ(square[0].i + aslant / 2, square[0].j + aslant / 2));//добавляем элемент место где ждут
		if (heightMap[square[0].i + aslant / 2, square[0].j + aslant / 2] == 0)
			heightMap[square[0].i + aslant / 2, square[0].j + aslant / 2] = GiveHeightSquare(square);//присваиваем значение

		if (down)
		{
			aslant = step / 2;
			step = aslant;
			Square(diamond, true);
		}
	}

	private void DiamondRhombus(IJ[] rhombus)
	{
		if (heightMap[rhombus[0].i, rhombus[0].j + aslant] == 0)
			heightMap[rhombus[0].i, rhombus[0].j + aslant] = GiveHeightDiamond(rhombus);//присваиваем значение
	}

	public void Square(List<IJ> diamond, bool down)
	{
		int stepCount = (int)Mathf.Pow(4, fourPow);
		fourPow++;

		for (int i = 0; i < diamond.Count; i++)
		{
			IJ[] rhombuses = new IJ[4];//создаем массив ромбов для каждой точки
			rhombuses[0] = new IJ(diamond[i].i, diamond[i].j - aslant);
			rhombuses[1] = new IJ(diamond[i].i, diamond[i].j + aslant);
			rhombuses[2] = new IJ(diamond[i].i + aslant, diamond[i].j);
			rhombuses[3] = new IJ(diamond[i].i - aslant, diamond[i].j);

			for (int j = 0; j < 4; j++)
			{
				IJ[] rhomb = new IJ[4];//определяем вершины ромбов
				rhomb[0] = new IJ(rhombuses[j].i, rhombuses[j].j - aslant);
				rhomb[1] = new IJ(rhombuses[j].i + aslant, rhombuses[j].j);
				rhomb[2] = new IJ(rhombuses[j].i, rhombuses[j].j + aslant);
				rhomb[3] = new IJ(rhombuses[j].i - aslant, rhombuses[j].j);
				DiamondRhombus(rhomb);//Задаем высоту вершины
			}
		}

		IJ[] square = new IJ[4];
		List<IJ> amir = new List<IJ>(diamond);
		diamond.Clear();

		if (step == 1)
			return;


		//Создаем квадраты под следующие вызовы Diamond
		for (int i = 0; i < amir.Count; i++)
		{
			square[0] = new IJ(amir[i].i, amir[i].j - aslant);
			square[1] = new IJ(amir[i].i, amir[i].j);
			square[2] = new IJ(amir[i].i + aslant, amir[i].j - aslant);
			square[3] = new IJ(amir[i].i + aslant, amir[i].j);
			Diamond(square, false);

			square[0] = new IJ(amir[i].i, amir[i].j);
			square[1] = new IJ(amir[i].i, amir[i].j + aslant);
			square[2] = new IJ(amir[i].i + aslant, amir[i].j);
			square[3] = new IJ(amir[i].i + aslant, amir[i].j + aslant);
			Diamond(square, false);

			square[0] = new IJ(amir[i].i - aslant, amir[i].j);
			square[1] = new IJ(amir[i].i - aslant, amir[i].j + aslant);
			square[2] = new IJ(amir[i].i, amir[i].j);
			square[3] = new IJ(amir[i].i, amir[i].j + aslant);
			Diamond(square, false);

			square[0] = new IJ(amir[i].i - aslant, amir[i].j - aslant);
			square[1] = new IJ(amir[i].i - aslant, amir[i].j);
			square[2] = new IJ(amir[i].i, amir[i].j - aslant);
			square[3] = new IJ(amir[i].i, amir[i].j);
			if (i + 1 == amir.Count)
				Diamond(square, true);
			else
				Diamond(square, false);
		}

	}

	private float GiveHeightDiamond(IJ[] diamond)//подсчет высоты для центра ромба
	{
		float diagonal;
		float average = 0;
		try
		{
			diagonal = SegmentLength(diamond[0], diamond[2]);
		}
		catch (System.Exception)
		{
			diagonal = SegmentLength(diamond[1], diamond[3]);
		}


		for (int i = 0; i < 4; i++)
		{
			try
			{
				average += heightMap[diamond[i].i, diamond[i].j];
			}
			catch (System.Exception)
			{
				average += outOfBoundsH;
			}
		}
		average /= 4;
		average += UnityEngine.Random.Range(-(roughness * diagonal), roughness * diagonal);

		if (maxY < average)
			maxY = average;
		if(minY > average)
			minY = average;

		return average;
	}

	private float GiveHeightSquare(IJ[] square)//подсчет высоты для цента квадрата
	{
		float diagonal = SegmentLength(square[0], square[3]);
		float average = 0;
		for (int i = 0; i < 4; i++)
		{
			try
			{
				average += heightMap[square[i].i, square[i].j];
			}
			catch (System.Exception)
			{
				average += outOfBoundsH;
			}
		}
		average /= 4;
		average += UnityEngine.Random.Range(-(roughness * diagonal), roughness * diagonal);

		if (maxY < average)
			maxY = average;
		if (minY > average)
			minY = average;

		return average;
	}

	private float SegmentLength(IJ start, IJ finish)//вычисление растояния между точками
	{
		double segmentLength = Mathf.Pow((start.i * unit - finish.i * unit), 2) + Mathf.Pow((start.j * unit - finish.j * unit), 2);
		return Mathf.Sqrt((float)segmentLength);
	}

	public void Nachalo(int N, float unit)//начало
	{
		this.unit = unit;
		mapRang = N;

		if (heightMap == null)
		{
			heightMap = new float[N, N];
		}

		TerraForm();
	}

}