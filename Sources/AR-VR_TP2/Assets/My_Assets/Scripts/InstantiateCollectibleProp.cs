using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCollectibleProp : MonoBehaviour
{
    public GameObject prop;
    public Vector3 scale = new Vector3(1.5f,1.5f,1.5f);
    private Terrain terrain;
    public Vector3 center = new Vector3(380f,135.5f,385f);
    public int radiusMax = 45;


    void Start()
    {
        terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        prop.transform.localScale = scale;
        for (int i = 0; i < GameVariables.nbProps; i++)
        {
            Vector2 randomPoint_2D = Random.insideUnitCircle;
            Vector3 pointRandomUnit = new Vector3(center.x + randomPoint_2D.x, center.y, center.z + randomPoint_2D.y);
            Vector3 mouvementVector = Vector3.Normalize(pointRandomUnit - center); 
            Vector3 finalPoint = pointRandomUnit + (Random.Range(0, radiusMax) * mouvementVector);

            float distanceToCenter = Vector3.Distance(center, finalPoint);

            if (distanceToCenter > 35f)
            {
                finalPoint.y -= 4f;
            }
            else if(distanceToCenter > 22f)
            {
                finalPoint.y -= 3.1f;
            }
            else if(distanceToCenter > 16.5)
            {
                finalPoint.y -= 1.8f;
            }
            else if(distanceToCenter > 11.5)
            {
                finalPoint.y -= 1f;
            }
            else if(distanceToCenter > 5)
            {
                finalPoint.y -=0.5f;
            }
            else
            {
                finalPoint.x += 3f;
                finalPoint.y -= 0.5f;
                finalPoint.z += 3f;
            }

            GameObject newProp = Instantiate(prop, finalPoint, Quaternion.identity);
            newProp.SetActive(true); 
        }
    }

}
