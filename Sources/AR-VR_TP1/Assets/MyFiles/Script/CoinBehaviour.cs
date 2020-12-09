using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
	public GameObject fx;
	AudioSource aud;
	GameObject audiObject;
	public GameObject worldObject;
	public SpawnBehaviour sp;
	bool should_spawn;

	void Start()
	{
		should_spawn = false;
		worldObject = GameObject.Find("World");
		audiObject = GameObject.Find("CoinSound");
		audiObject.transform.position = gameObject.transform.position;
		aud = audiObject.GetComponent<AudioSource>();
		aud.clip.LoadAudioData();
	}

    private void Update()
    {
		transform.Rotate(new Vector3(0, 0, 45) * 2 * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
	{
		worldObject.SendMessage("AddCoin");
		if (aud)
		{
            if (should_spawn)
            {
				sp.spawn();
            }
			aud.Play();
			Destroy(fx);
			Destroy(gameObject);
		}
	}

	public void shouldSpawn()
    {
		should_spawn = true;
    }
}

