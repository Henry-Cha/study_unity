using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] points;
    public GameObject monster;

    public float createTime;
    public int maxMonster;
    public bool isGameOver;

    // Use this for initialization
    void Start()
    {
        isGameOver = false;
        maxMonster = 500;
        createTime = 2f;
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            StartCoroutine(this.CreateMonster());
        }
    }

    private void Update()
    {
        if(TargetCtrl.hp <=0)
        {
            isGameOver = true;
        }
        if (Score.score > 50)
            createTime = 0.5f;
        else if (Score.score > 30)
            createTime = 1;
        else if (Score.score > 10)
            createTime = 1.5f;

    }

    IEnumerator CreateMonster()
    {
        while (!isGameOver)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("MONSTER").Length;

            if (monsterCount < maxMonster)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);
                Vector3 zone = new Vector3(0,1,0)+ points[idx].position;
                Instantiate(monster, zone, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
}
