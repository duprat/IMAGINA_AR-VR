using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    public GameObject player;
    public GameObject VillageMarker;
    private GameObject grave;
    private CapsuleCollider clyde;
    private Animator animator;
    private float elevation = 0f;
    private float deltaElevation = 0.05f;
    private int remainingTimeBeforeDeparture = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Image").GetComponent<Animator>();
        clyde = gameObject.GetComponent<CapsuleCollider>();
        grave = GameObject.Find("teleportGrave");
    }

    public void ActivateTeleportationZone()
    {
        StartCoroutine(elevateTeleportZone());
    }

    IEnumerator elevateTeleportZone()
    {
        while (elevation < 3f)
        {
            yield return new WaitForSeconds(0.03f);
            elevation += deltaElevation;
            grave.transform.position = new Vector3(grave.transform.position.x, grave.transform.position.y + deltaElevation, grave.transform.position.z);
        }
        clyde.enabled = true;
        clyde.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (animator)
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        animator.SetBool("Fade", true);
        yield return new WaitForSeconds(1);
        VillageTeleportation();
    }

    public void VillageTeleportation()
    {
         player.SetActive(false);
         GameObject newProp = Instantiate(player, VillageMarker.transform.position, Quaternion.identity);
         Destroy(player);
        newProp.SetActive(true);
        animator.SetBool("Fade", false);
        StartCoroutine(toDedalus());
    }

    IEnumerator toDedalus()
    {
        while (remainingTimeBeforeDeparture > 0)
        {
            yield return new WaitForSeconds(1);
            remainingTimeBeforeDeparture--;
        }
        SceneManager.LoadScene("Dedalus");
    }
}
