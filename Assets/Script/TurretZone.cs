using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretZone : MonoBehaviour
{
    public GameObject turret;
    public static bool isOut=true;
    bool done=false;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="PLAYER")
        {
            isOut = false;
            if (!done)
            {
                if (Score.score > 10)
                {
                    MsgCtrl.msg.text = "[F]키를 눌러 포탑을 설치합니다(Score -10)";
                    if (Input.GetKey(KeyCode.F))
                    {
                        if (!done)
                        {
                            Instantiate(turret, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                            Score.score -= 10;
                        }
                       
                        done = true;
                    }
                }
                else
                    MsgCtrl.msg.text = "스코어가 부족합니다(최소 11점)";               
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PLAYER")
        {
            isOut = true;
            MsgCtrl.msg.text = "";
        }
    }
    
}
