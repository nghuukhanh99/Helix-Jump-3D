using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;

    public float ySpawn = 0;

    public float ringDistance = 5;

    public int numberOfRings;

    
    // Start is called before the first frame update
    void Start()
    {
        numberOfRings = GameManager.currentLevelIndex + 5;

        // spawn rings
        for (int i = 0; i < numberOfRings; i++)
        {
            if(i == 0)
            {
                SpawnRing(0);
            }
            else
            {
                SpawnRing(Random.Range(1, helixRings.Length - 1));
            }

        }

        // spawn last ring
        SpawnRing(helixRings.Length - 1);

    }

   
    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, transform.rotation * Quaternion.Euler(0f, Random.Range(-360f, 360f),0f));

        go.transform.parent = transform;

        ySpawn -= ringDistance;
    }
}
