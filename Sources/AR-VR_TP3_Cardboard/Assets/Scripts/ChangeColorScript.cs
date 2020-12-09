using System.Collections;
using TMPro;
using UnityEngine;

public class ChangeColorScript : MonoBehaviour
{
	public Renderer ElRenderer;

    public void Red()
	{
		ElRenderer.material.color = Color.red;
	}

	public void Blue()
	{
		ElRenderer.material.color = Color.blue;
	}
	public void Magenta()
	{
		ElRenderer.material.color = Color.magenta;
	}
}
