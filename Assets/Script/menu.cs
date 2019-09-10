using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneName;
    public float earth_r = 90.0f;
    public GameObject clickObject;
    public GameObject earth;
    public Text Click;

    void Start()
    {
        clickObject = GameObject.Find("Text_Click");
        Click = clickObject.GetComponent<Text>();
        earth = GameObject.Find("earth");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Input.mousePosition, earth.transform.position) < earth_r)
        {
            transform.DOScale(new Vector3(4, 4, 4), 0.5f);
            Click.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutBack);
            if (Input.GetMouseButtonUp(0))
            {
                NextScene();
            }
        }
        else
        {
            transform.DOScale(new Vector3(3, 3, 3), 0.5f);
            Click.transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), 0.5f).SetEase(Ease.OutBack);
        }

    }
    
    public void NextScene()
    {
        SceneManager.LoadScene(SceneName);
    }

}
