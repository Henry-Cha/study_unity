using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText: MonoBehaviour
{
    Text scoreLable;

    // Start is called before the first frame update
    void Awake()
    {
        scoreLable = GetComponent<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        scoreLable.text = "스코어 : " + Score.score.ToString();
    }
}
