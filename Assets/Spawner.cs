using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject meteorite1;
    public GameObject meteorite2;
    public GameObject meteorite3;
    public int initNum;
    public int maxNum;
    public int x_size;
    public int y_size;
    public float spawnTime;
    public float spawnDelay;
    public int curNum;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        curNum = 0;
        initSpawn();
    }
    
    private void initSpawn()
    {
        while (curNum < initNum)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-x_size, x_size), Random.Range(-y_size, y_size), 2);
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(-180, 180));

            GameObject[] meteoriteList = GameObject.FindGameObjectsWithTag("meteorite");

            for (int i = 0; i < meteoriteList.Length; ++i)
            {
                if(Vector2.Distance(meteoriteList[i].transform.position, randomPosition) 
                    < meteoriteList[i].transform.localScale.x)
                {
                    randomPosition = new Vector3(Random.Range(-x_size, x_size), Random.Range(-y_size, y_size), 2);
                    i = 0;
                }
            }

            int rnd = Random.Range(0, 3);
            if (rnd == 0)
            {
                Instantiate(meteorite1, transform.position + randomPosition, randomRotation);
            }else if(rnd == 1)
            {
                Instantiate(meteorite2, transform.position + randomPosition, randomRotation);
            }
            else if(rnd == 2)
            {
                Instantiate(meteorite3, transform.position + randomPosition, randomRotation);
            }
            curNum += 1;
        }
    }

    public void SpawnObject()
    {
        if (curNum < maxNum)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-x_size, x_size), Random.Range(-y_size, y_size), 2);
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(-180, 180));

            GameObject[] meteoriteList = GameObject.FindGameObjectsWithTag("meteorite");

            for (int i = 0; i < meteoriteList.Length; ++i)
            {
                if (Vector2.Distance(meteoriteList[i].transform.position, randomPosition)
                    < meteoriteList[i].transform.localScale.x)
                {
                    randomPosition = new Vector3(Random.Range(-x_size, x_size), Random.Range(-y_size, y_size), 2);
                    i = 0;
                }
            }

            int rnd = Random.Range(0, 3);
            if (rnd == 0)
            {
                Instantiate(meteorite1, transform.position + randomPosition, randomRotation);
            }
            else if (rnd == 1)
            {
                Instantiate(meteorite2, transform.position + randomPosition, randomRotation);
            }
            else if (rnd == 2)
            {
                Instantiate(meteorite3, transform.position + randomPosition, randomRotation);
            }

            curNum += 1;
        }
    }
}