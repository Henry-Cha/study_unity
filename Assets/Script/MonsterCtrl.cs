using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class MonsterCtrl : MonoBehaviour
{
    public float runSpeed;
    private Slider slider;
    public float maxHP;
    public float hp;
    Rigidbody rigid;
    CapsuleCollider capsuleCol;
    Animator animator;
    bool isDead;
    GameObject target;
    NavMeshAgent nav;
    public int damage = 1;
    public float timeBetAttack = 1f;
    private float lastAttackTime;

    void Awake()
    {
        runSpeed = 5;
        maxHP = 5;
        isDead = false;
        slider = GetComponentInChildren<Slider>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        capsuleCol = GetComponent<CapsuleCollider>();
        target = GameObject.FindGameObjectWithTag("TARGET");
        nav = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {   
        maxHP += Score.score / 3;
        hp = maxHP;
        slider.maxValue = maxHP;
        runSpeed = 5 + Score.score / 10;
        nav.speed = runSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "BULLET")
        {
            BulletCtrl bulletCtrl = collision.collider.GetComponent<BulletCtrl>();
            hp -= bulletCtrl.damage;
            Destroy(collision.collider.gameObject);
            StartCoroutine(onDamage());
        }
    }

    IEnumerator onDamage()
    {
        yield return new WaitForSeconds(0.1f);

        if(hp > 0)
        {
            slider.gameObject.SetActive(true);
            slider.value = maxHP - hp;
        }
        else
        {
            isDead = true;
            slider.value = maxHP;
            gameObject.layer = 13;
            nav.isStopped = true;
            animator.SetBool("isAttack", false);
            animator.SetBool("isMove", false);
            animator.SetTrigger("isDie");
            Destroy(gameObject, 1);
            Score.score +=1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.transform.position);
        if (hp > 0)
        {
            animator.SetBool("isMove", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(!isDead&&Time.time>=timeBetAttack+lastAttackTime)
        {
            if(other.tag == "TARGET")
            {
                animator.SetBool("isAttack", true);
                lastAttackTime = Time.time;
                TargetCtrl.hp -= damage;
            }
        }      
            
    }
}
