using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Rocket rocket;
    public float time = 59.9f;
    public Text _timer;

    // Start is called before the first frame update
    void Start()
    {
        rocket = GameObject.FindGameObjectWithTag("Player").GetComponent<Rocket>();
        _timer.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            rocket.speed = 0;
        }
        else
        {
            _timer.text = time.ToString().Substring(0, 4);
        }
    }
}
