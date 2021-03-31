using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetCtrl : MonoBehaviour
{
    [SerializeField]
    public static int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("end");
        }
    }
}
