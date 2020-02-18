using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColor : MonoBehaviour
{
    private SpriteRenderer Render;

    [SerializeField] private int BulletKind;
    [SerializeField] private GameObject bulletManager;
    [SerializeField] private bool Tutorial;

    public int ColorNum = 1;


    void Start()
    {
        if (!Tutorial)
        {
            ColorNum = Random.Range(0, 4);
        }

        Render = GetComponent<SpriteRenderer>();

        bulletManager = GameObject.Find("BulletManager");

        if (BulletKind == 0) {

            Render.sprite = bulletManager.GetComponent<BulletManager>().BulletShape[ColorNum];
        }
        else
        {
            Render.sprite = bulletManager.GetComponent<BulletManager>().BouncyBulletShape[ColorNum];
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
