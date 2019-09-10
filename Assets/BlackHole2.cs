using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject blackHole = GameObject.Find("BlackHole1");
            col.gameObject.transform.position = blackHole.transform.position + col.gameObject.transform.right * 3;
        }
    }
}
