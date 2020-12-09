using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    GameObject player;
    public GameObject Spawn;
    public Animator anim;
    public GameObject prefab;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void spawn()
    {
        if (player)
        {
            StartCoroutine(Fading());
            /*player.transform.position = new Vector3(
                Spawn.transform.position.x, 
                Spawn.transform.position.y + 3, 
                Spawn.transform.position.z);
            player.transform.rotation = Spawn.transform.rotation;*/
        }
        
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(1);
        player.transform.position = Spawn.transform.position;
        player.transform.rotation = Spawn.transform.rotation;
        Vector3 randomPos = new Vector3(445, 0, 350);
        GameObject statue = Instantiate(prefab, randomPos, Quaternion.identity);
        anim.SetBool("Fade", false);
    }
}

