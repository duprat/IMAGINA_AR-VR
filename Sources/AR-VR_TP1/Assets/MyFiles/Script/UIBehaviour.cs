using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIBehaviour : MonoBehaviour
{
	Text coinText;
	Text timerText;
	int nbCoins = 0;
	int nbCoinsMax = 0;
	GameObject canvasObj;
	public int currentTime;
	public CoinBehaviour cb;

	void Start()
	{
		Transform child;
		canvasObj = GameObject.Find("Canvas");
		child = canvasObj.transform.Find("lblCoins"); 
		coinText = child.GetComponent<Text>();
		coinText.text = "Coins:	0";

		child = canvasObj.transform.Find("lblTime");
		timerText = child.GetComponent<Text>();
		timerText.text = currentTime + "sec left";

		StartCoroutine(TimerTick());
	}

    public void AddCoin()
	{
		nbCoins++;
		coinText.text = "Coins:	" + nbCoins;
		if(nbCoins == nbCoinsMax +1)
        {
			cb.shouldSpawn();
		}
	}

	IEnumerator TimerTick()
	{
		while (currentTime > 0)
		{
			yield return new WaitForSeconds(1);
			currentTime--;
			timerText.text = currentTime.ToString() + "sec left";
		}
		SceneManager.LoadScene("Origen");
	}

	public void setNbCoinMax(int nb)
    {
		nbCoinsMax = nb;
    }

}