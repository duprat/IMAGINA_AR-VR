using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiBehaviour : MonoBehaviour
{
    public Text GoldBarsLeft;
    public Text SecondsLeft;
    public Image image;

    void Start()
    {
        if (GoldBarsLeft)
        {
            GoldBarsLeft.text = "Remaining GoldBars: " + GameVariables.nbProps;
            
        }
        StartCoroutine(TimerTick());
    }

    IEnumerator TimerTick()
    {
        while (GameVariables.secondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            GameVariables.secondsLeft--;
            SecondsLeft.text = GameVariables.secondsLeft.ToString() + " Seconds Left";
           /* if (GameVariables.nbProps == 0)
            {
                yield break;
            }*/
        }
        if(GameVariables.nbProps != 0)
        {
            SceneManager.LoadScene("Westernos");
        }
    }

    public void shaveGoldBars()
    {
        if (GoldBarsLeft)
        {
            GameVariables.nbProps--;
            GoldBarsLeft.text = "Remaining GoldBars: " + GameVariables.nbProps;
            if (GameVariables.nbProps == 0)
            {
                GameObject.Find("Teleporter").SendMessage("ActivateTeleportationZone");
            }
        }
        
    }
}
