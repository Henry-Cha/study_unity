using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCrtl : MonoBehaviour
{
    [SerializeField] Transform m_tgunbody = null;
    [SerializeField] float m_range = 0f;
    [SerializeField] LayerMask m_layerMask = 0;
    [SerializeField] float m_spinSpeed = 0f;
    [SerializeField] float m_fireRate = 0f;
    float m_currentFireRate;
    Transform m_tTarget = null;
    Transform m_tHead = null;
    public Transform firePOS;
    public GameObject bullet;

    void SearchEnemy()
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_range, m_layerMask);
        Transform t_shortestTarget = null;

        if(t_cols.Length > 0)
        {
            float t_shortestDistance = Mathf.Infinity;
            foreach(Collider t_colTarget in t_cols)
            {
                float t_distance = Vector3.SqrMagnitude(transform.position - t_colTarget.transform.position);
                if(t_shortestDistance>t_distance)
                {
                    t_shortestDistance = t_distance;
                    t_shortestTarget = t_colTarget.transform;
                }
            }
        }
        m_tTarget = t_shortestTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_tHead = GetComponent<Transform>();
        m_currentFireRate = m_fireRate;
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_tTarget == null)
            m_tgunbody.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        else
        {
            Quaternion t_lookRotation = Quaternion.LookRotation(m_tTarget.position - m_tHead.position);
            Vector3 t_euler = Quaternion.RotateTowards(m_tgunbody.rotation, t_lookRotation, m_spinSpeed * Time.deltaTime).eulerAngles;
            m_tgunbody.rotation = Quaternion.Euler(0, t_euler.y, 0);
            Quaternion t_fireRotation = Quaternion.Euler(0, t_lookRotation.eulerAngles.y, 0);
            if (Quaternion.Angle(m_tgunbody.rotation, t_fireRotation) < 5f)
            {
                m_currentFireRate -= Time.deltaTime;
                if(m_currentFireRate<=0)
                {
                    m_currentFireRate = m_fireRate;
                    Fire();
                }
            }
        }         
    }
    void Fire()
    {
            CreateBullet();
    }
    void CreateBullet()
    {
        Instantiate(bullet, firePOS.position, firePOS.rotation);
    }

}
