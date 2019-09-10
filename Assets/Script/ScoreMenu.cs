using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreMenu : MonoBehaviour
{
    public string SceneName;
    public string SceneNameBack;

    public Timer _timer;
    float myTime=0;

    public Score _score;
    public GameObject CanvasScore;
    public GameObject menuScore;
    public GameObject UiScene;
    public Text ScoreText;


    // Start is called before the first frame update
    void Start()
    {
        _timer.GetComponent<Timer>();
        ScoreText.text=_score.score.ToString();
        menuScore.GetComponent<RectTransform>().localScale=new Vector3(1,1,1);

    }
    void Enable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myTime=_timer.time;
        if(myTime<=0)
        {
            UiScene.SetActive(false);
            CanvasScore.SetActive(true);
            menuScore.transform.DOScale(new Vector3(19.54f, 11.13f, 10),1.5f).SetEase(Ease.OutBack);
            ScoreText.text = _score.score.ToString();

        }
    }
    public void ReturnScene()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void BackScene()
    {
        SceneManager.LoadScene(SceneNameBack);
    }
}
