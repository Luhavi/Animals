using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Sprite[] BulletShape;
    public Sprite[] BouncyBulletShape;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject BouncyBullet;
    [SerializeField] private GameObject Circle;
    private Vector3 TempPos;


    private float timer;
    private float timer1;
    private float waitTime;
    private float waitTime1 = 10;
    void Start()
    {
        waitTime1 = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bullet != null)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                timer = 0;
                while (Vector3.Distance(Circle.transform.position, TempPos) < 2.1)
                {
                    TempPos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-4.6f, 2.9f), 0);
                }
                Instantiate(Bullet, TempPos, Quaternion.identity);
                TempPos = Vector3.zero;
                waitTime = 2f;
            }
        }
        if (BouncyBullet != null)
        {
            timer1 += Time.deltaTime;
            if (timer1 > waitTime1)
            {
                timer1 = 0;
                while (Vector3.Distance(Circle.transform.position, TempPos) < 2.1)
                {
                    TempPos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-4.6f, 2.9f), 0);
                }
                Instantiate(BouncyBullet, TempPos, Quaternion.identity);
                TempPos = Vector3.zero;
                waitTime1 = 10f;
            }
        }
    }

    public void SetBullet(Sprite shape, int num)
    {
        BulletShape[num] = shape;
    }

    public void SetBouncyBullet(Sprite shape, int num)
    {
       BouncyBulletShape[num] = shape;
    }

}
