using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    enum State { Holding, Shooting };

    public Rigidbody2D rigid;
    public float minSpeed;
    public float speed;
    public float maxSpeed;
    public float speedUpRate;
    public float speedDownPerCollision;
    private State state;
    private Vector2 dir;
    private bool rotateDir;

    public GameObject Explosion;///HERE
    public GameObject Ring;///HERE

    private AudioSource shoot;

    // Start is called before the first frame update
    void Start()
    {
        rotateDir = true;
        state = State.Shooting;
        rigid.velocity = new Vector2(1, 0) * speed * Time.deltaTime;
        dir = rigid.velocity;
        shoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Holding && speed < maxSpeed)
        {
            speed += speedUpRate;
        }
        dir = rigid.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            ContactPoint2D contactPoint = collision.contacts[0];
            Vector2 newDir = Vector2.zero;
            Vector2 curDir = transform.TransformDirection(Vector2.right);
            newDir = Vector2.Reflect(curDir, contactPoint.normal);
            Quaternion rotation = Quaternion.FromToRotation(Vector2.right, newDir);
            transform.rotation = rotation;
            if (speed > minSpeed) speed -= speedDownPerCollision;
            rigid.velocity = transform.TransformDirection(1, 0, 0).normalized * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform t = collision.GetComponent<Transform>();
        if (collision.gameObject.tag == "Planet")
        {
            Instantiate(GameObject.Find("planetShading"), t.position + new Vector3(0, 0, 10), new Quaternion());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform t = collision.GetComponent<Transform>();
        if (collision.gameObject.tag == "planetShading")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "planetHolding")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D trigger)
    {
        Transform t = trigger.GetComponent<Transform>();
        float r = Vector2.Distance(t.position, transform.position);
        Vector3 cross = Vector3.Cross(t.position - transform.position, rigid.velocity);
        if (trigger.gameObject.tag == "Planet" && Input.GetMouseButtonDown(0) && state == State.Shooting)
        {
            state = State.Holding;
            if (cross.z < 0) rotateDir = true;
            else rotateDir = false;

            Instantiate(GameObject.Find("planetHolding"), t.transform.position, new Quaternion());
        }
        if (trigger.gameObject.tag == "Planet" && state == State.Holding && Input.GetMouseButton(0))
        {
            if (rotateDir)
            {
                transform.RotateAround(t.position, new Vector3(0, 0, 1), Time.deltaTime * speed / r);
            }
            else
            {
                transform.RotateAround(t.position, new Vector3(0, 0, -1), Time.deltaTime * speed / r);
            }
            rigid.velocity = new Vector2(0, 0);
        }
        else if (trigger.gameObject.tag == "Planet" && state == State.Holding )
        {
            rigid.velocity = transform.TransformDirection(1, 0, 0) * speed * Time.deltaTime;
            state = State.Shooting;
            Instantiate(Ring, transform.position, transform.rotation);
            CameraController.shouldEffect = true;
            shoot.Play();
        }
    }
}
