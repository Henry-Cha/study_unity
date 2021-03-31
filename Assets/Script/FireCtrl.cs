using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public Transform firePOS;
    public GameObject bullet;
    public MeshRenderer muzzleFlash;
    public AudioClip gunclip;
    private AudioSource audioSource;
    private bool FireState = true;

    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gunclip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }
    void Fire()
    {
        if (FireState == true)
        {
            StartCoroutine(FireCycleControl());
            CreateBullet();
            StartCoroutine(this.ShowMuzzle());
            audioSource.Play();
        }
    }
    IEnumerator FireCycleControl()
    {
        FireState = false;
        yield return new WaitForSeconds(0.1f);
        FireState = true;
    }

    void CreateBullet()
    {
        Instantiate(bullet, firePOS.position, firePOS.rotation);
    }

    IEnumerator ShowMuzzle()
    {
        float scale = Random.Range(1.0f, 2.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale;
        Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 90));
        muzzleFlash.transform.localRotation = rot;


        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.05f, 0.3f));
        muzzleFlash.enabled = false;
    }
}
