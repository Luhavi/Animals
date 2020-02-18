using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChange : MonoBehaviour
{
    private SpriteRenderer Render;

    [SerializeField] private Sprite[] BackG;

    private int ImageNum;


    void Start()
    {
        ImageNum = PlayerPrefs.GetInt("BGNUM");

        Render = GetComponent<SpriteRenderer>();

        Render.sprite = BackG[ImageNum];
    }

    public void ChangeBackGround(int num)
    {
        ImageNum = num;

        Render.sprite = BackG[ImageNum];

        PlayerPrefs.SetInt("BGNUM", ImageNum);
    }
}
