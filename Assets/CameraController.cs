using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
public class CameraController : MonoBehaviour
{
    public Camera camera;
    public Vector3 CameraOriginPosition;
    public Vector3 CameraMeteoritePosition;
    public float originCamera;
    public float offsetCamera;
    public float zoomSpeed=0.5f;
    public float TimeSlow=0.3f;
    public static bool zoomCamera=false;

    public PostProcessVolume postProcessVolume;
    public static bool shouldEffect = false;
    public float duration = 1.0f;
    float initialDuration;

    // Start is called before the first frame update
    void Start()
    {
        camera=camera.GetComponent<Camera>();
        originCamera=camera.orthographicSize;
        CameraOriginPosition=new Vector3(0,0,0);

        postProcessVolume = camera.GetComponent<PostProcessVolume>();
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(zoomCamera)
        {
            if(camera.orthographicSize>offsetCamera)
            {
                camera.orthographicSize-=zoomSpeed*Time.deltaTime;
                Time.timeScale=TimeSlow;
            }
        }
        else
        {
            transform.DOMove(new Vector3(0, 0, -10), 0.3f);
            if (camera.orthographicSize<originCamera)
            {
                camera.orthographicSize+=zoomSpeed*Time.deltaTime;
                Time.timeScale=1f;
            }
        }
        cameraEffect();
    }

    public void cameraEffect()
    {
        if (shouldEffect)
        {
            if (duration > 0)
            {
                postProcessVolume.weight += Time.deltaTime * 50;
                duration -= Time.deltaTime;
            }
            else
            {
                shouldEffect = false;
                duration = initialDuration;
                if (postProcessVolume.weight >= 0.9)
                    postProcessVolume.weight = 0;
            }
        }
    }
}
