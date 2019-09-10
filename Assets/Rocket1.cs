using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket1 : MonoBehaviour
{
    public GameObject rockBomb1;
    public GameObject rockBomb2;
    public GameObject rockBomb3;
    public RocketState _rocketState;
    public Transform firstTarget;
    Rigidbody2D rb;
    GameObject parent;
    public GameObject Explosion;
    private AudioSource bomb;
    Score score;
    public enum RocketState
    {
        small,mid,big
    }

    // Start is called before the first frame update
    void Start()
    {
        _rocketState=RocketState.big;
        rb=GetComponent<Rigidbody2D>();
        bomb = transform.GetChild(2).GetComponent<AudioSource>();
        score = GameObject.Find("Score").GetComponent<Score>();

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "meteorite")
        {
            parent = col.gameObject.transform.parent.gameObject;
            Rigidbody2D rigid = GetComponent<Rigidbody2D>();
            float speed = GetComponent<Rocket>().speed;
                
            rigid.velocity = transform.TransformDirection(1, 0, 0).normalized * speed * Time.deltaTime;

            Instantiate(Explosion, col.transform.position, Explosion.transform.rotation);
            
            if(col.gameObject.transform.parent.gameObject.tag == "rock1")
            {
                Instantiate(rockBomb1, col.transform.position, col.transform.rotation);
            }
            else if(col.gameObject.transform.parent.gameObject.tag == "rock2")
            {
                Instantiate(rockBomb2, col.transform.position, col.transform.rotation);
            }
            else if (col.gameObject.transform.parent.gameObject.tag == "rock3")
            {
                Instantiate(rockBomb3, col.transform.position, col.transform.rotation);
            }

            score.score += (int)(parent.GetComponent<Meteorite>().score * speed * 1.345);

            score.OnAdd = true;
            CameraShaker.shouldShake = true;
            Destroy(parent);
            CameraController.zoomCamera = false;

            GameObject.Find("Spawner").GetComponent<Spawner>().curNum -= 1;

            bomb.Play();
        }
        else
            score.OnAdd = false;

    }

}
