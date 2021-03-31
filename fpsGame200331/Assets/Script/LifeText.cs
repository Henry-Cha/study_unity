using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeText : MonoBehaviour
{
    Text lifeLable;

    // Start is called before the first frame update
    void Awake()
    {
        lifeLable = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeLable.text = "내구도 : " + TargetCtrl.hp.ToString();
    }
}
