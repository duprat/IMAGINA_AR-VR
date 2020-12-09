using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    public GameObject collectible;
    public GameObject FX;
    private AudioSource audioSource;
    private GameObject UI;


    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("HUD");
        audioSource = GameObject.Find("CoinSound").GetComponent<AudioSource>();
        audioSource.transform.position = gameObject.transform.position;
        FX.transform.position = gameObject.transform.position;
        audioSource.clip.LoadAudioData();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 45,0 ) * 2 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        UI.SendMessage("shaveGoldBars");
        if (audioSource)
        {
            audioSource.Play();
            Destroy(FX);
            Destroy(gameObject);
        }
    }
}
