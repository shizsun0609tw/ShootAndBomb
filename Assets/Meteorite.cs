using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Meteorite : MonoBehaviour
{

    public MeteoriteState _meteoriteState;
    public int score;

    public enum MeteoriteState
    {
        small, mid, big
    }

    public GameObject rocket;
    // Start is called before the first frame update
    void Start()
    {
        if (_meteoriteState == MeteoriteState.big) score = 3;
        else if (_meteoriteState == MeteoriteState.mid) score = 5;
        else if (_meteoriteState == MeteoriteState.small) score = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).transform.position = transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            CameraController.zoomCamera = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        CameraController.zoomCamera = false;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            rocket=col.gameObject;
            GameObject.FindGameObjectWithTag("MainCamera").transform.DOMove(new Vector3(transform.position.x, transform.position.y, -10), 0.3f);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            Debug.Log("Collision");
        }
    }
}
