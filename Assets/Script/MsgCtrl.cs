using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgCtrl : MonoBehaviour
{
    public static Text msg;

    // Start is called before the first frame update
    void Start()
    {
        msg = GetComponent<Text>();
        msg.text = "";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
