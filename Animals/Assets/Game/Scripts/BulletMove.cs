using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float Timer;
    [SerializeField] private int WaitTime;
    [SerializeField] private float Speed = 3f;
    Vector3 vec;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > WaitTime){
            vec = (new Vector3(0, -0.85f, 0) - transform.position).normalized;
            rigid.AddForce(vec * Speed);

            Timer = 0;
        }
    }
}
