using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DedalusDoorBehaviour : MonoBehaviour
{
    public GameObject endScreen;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("FPSController");
    }

    void OnTriggerEnter(Collider other)
    {
        endScreen.SetActive(true);
        Time.timeScale = 0;
        player.GetComponent<FirstPersonController>().unlockCursor();
    }
}
