using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Score : MonoBehaviour
{
    public int score = 0;
     public Text _score;
    public bool OnAdd = false;
    // Start is called before the first frame update
    void Start()
    {
        _score.GetComponent < Text > ();
    }

    // Update is called once per frame
    void Update()
    {
        _score.text = score.ToString();

        if (OnAdd)
        {
            _score.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.5f);
        }
        else
        {
            _score.transform.DOScale(new Vector3(1, 1, 1), 0.1f);
        }
    }
}
