using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstantiationCoin : MonoBehaviour
{
	public GameObject prefab;
	public int nbObjects = 5;
	public float minX = 450f;
	public float maxX = 500f;
	public float minZ = 350f;
	public float maxZ = 370f;
	public float y = 1.5f;

	void Start()
	{
		GameObject.Find("World").SendMessage("setNbCoinMax", nbObjects);
		for (int i = 0; i < nbObjects; i++)
		{
			Vector3 randomPos = new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));
			Instantiate(prefab, randomPos, Quaternion.identity);
		}
	}
}