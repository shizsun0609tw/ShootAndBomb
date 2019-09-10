using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

    public float power = 0.7f;
    public float duration = 1.0f;
    public new Transform camera;
    public float slowDownAmount = 1.0f;
    public static bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;


    // Use this for initialization
    void Start () {
        camera = Camera.main.transform;
        initialDuration = duration;
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldShake == true)
        {
            if (duration > 0)
            {
                camera.localPosition = camera.localPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }

            else
            {
                shouldShake = false;
                duration = initialDuration;
                transform.position = new Vector3(0, 0, -10);
            }
        }        
     }
}
