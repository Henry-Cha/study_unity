using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Anim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runLeft;
    public AnimationClip runRight;
}

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    public float moveSpeed = 10.0f;
    public float rotSpeed = 100.0f;

     public Anim anim;
     public Animation _animation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        tr = GetComponent<Transform>();
        _animation = GetComponent<Animation> ();
        _animation.clip = anim.idle;
        _animation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        
        Vector3 moveDir = ((Vector3.forward * v) + (Vector3.right * h)).normalized;
        tr.Translate(moveSpeed * moveDir * Time.deltaTime, Space.Self);

        tr.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed, Space.Self);

        if( v>= 0.1f)
        {
            _animation.CrossFade(anim.runForward.name, 0.3f);
        }
        else if(v<= -0.1f)
        {
            _animation.CrossFade(anim.runBackward.name, 0.3f);
        }
        else if(h>=0.1f)
        {
            _animation.CrossFade(anim.runRight.name, 0.3f);
        }
        else if(h<=-0.1f)
        {
            _animation.CrossFade(anim.runLeft.name, 0.3f);
        }
        else
        {
            _animation.CrossFade(anim.idle.name, 0.3f);
        }
    }
}
