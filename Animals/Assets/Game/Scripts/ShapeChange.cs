using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeChange : MonoBehaviour
{
    private int[] listNum = new int[4];
    public bool isPlayedAd = true;
    private int PlayAdRandom;
    [SerializeField] private Sprite[] shape;
    [SerializeField] private Sprite[] LineShape;
    [SerializeField] private Sprite[] BulletShape;
    [SerializeField] private Sprite[] BouncyBulletShape;
    [SerializeField] private GameObject[] Box;
    [SerializeField] private GameObject[] Line;
    [SerializeField] private GameObject BulletManager;
    [SerializeField] private GameObject ScreenAd;
    [SerializeField] private int selectionNum;
    [SerializeField] private int[] ColorNum = new int[4];
    [SerializeField] private int[] LineColorNum = new int[4];
    [SerializeField] private int ResetCount = 1;
    [SerializeField] private bool Tutorial;


    [SerializeField] private GameObject GameOver;

    private void Start()
    {
        // get Circle
        Box[0] = GameObject.Find("01");
        Box[1] = GameObject.Find("02");
        Box[2] = GameObject.Find("03");
        Box[3] = GameObject.Find("04");

        // get Line
        Line[0] = GameObject.Find("1");
        Line[1] = GameObject.Find("2");
        Line[2] = GameObject.Find("3");
        Line[3] = GameObject.Find("4");

        // getImageNum
        listNum[0] = PlayerPrefs.GetInt("listNum0");
        listNum[1] = PlayerPrefs.GetInt("listNum1");
        listNum[2] = PlayerPrefs.GetInt("listNum2");
        listNum[3] = PlayerPrefs.GetInt("listNum3");

        BulletManager = GameObject.Find("BulletManager");
        if (!Tutorial)
        {
            ChangeLineNum();
        }

        // Line and Circle get Image
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Box[j].GetComponent<ColorChange>().SetColor(shape[listNum[i]], i);
                Line[j].GetComponent<LineColorChange>().SetLine(LineShape[listNum[i]], i);
            }
            BulletManager.GetComponent<BulletManager>().SetBullet(BulletShape[listNum[i]], i);
            BulletManager.GetComponent<BulletManager>().SetBouncyBullet(BouncyBulletShape[listNum[i]], i);
        }
        isPlayedAd = true;
    }

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            ColorNum[i] = Box[i].GetComponent<ColorChange>().colorNum;
        }
        for (int i = 0; i < 4; i++)
        {
            LineColorNum[i] = Line[i].GetComponent<LineColorChange>().Num;
        }
        //Line and Box is Same
        if(ColorNum[0] == LineColorNum[0] && ColorNum[1] == LineColorNum[1] && ColorNum[2] == LineColorNum[2] && ColorNum[3] == LineColorNum[3] ||
            ColorNum[1] == LineColorNum[0] && ColorNum[2] == LineColorNum[1] && ColorNum[3] == LineColorNum[2] && ColorNum[0] == LineColorNum[3] ||
            ColorNum[2] == LineColorNum[0] && ColorNum[3] == LineColorNum[1] && ColorNum[0] == LineColorNum[2] && ColorNum[1] == LineColorNum[3] ||
            ColorNum[3] == LineColorNum[0] && ColorNum[0] == LineColorNum[1] && ColorNum[1] == LineColorNum[2] && ColorNum[2] == LineColorNum[3])
        {
            for (int i = 0; i < 4; i++)
            {
                Box[i].GetComponent<ColorChange>().colorNum = Box[i].GetComponent<ColorChange>().FirstNum;
            }
            ResetCount++;
            ColorChange.score += 5;
            ChangeLineNum();
        }

        if(ColorNum[0] == ColorNum[1] && ColorNum[1] == ColorNum[2] && ColorNum[2] == ColorNum[3] && ColorNum[3] == ColorNum[0])
        {
            GameOver.SetActive(true);
            if (isPlayedAd)
            {
                //PlayAdRandom = Random.Range(0,5);
                //if (PlayAdRandom == 1)
                //{
                    ScreenAd.GetComponent<AdMobScreenAd>().Show();
                //}
                isPlayedAd = false;
            }
            Time.timeScale = 0;
        }
    }
    

    public void ChangeShape(int num)
    {
        // change New Image
        for (int i = 0; i < 4; i++)
        {
            Box[i].GetComponent<ColorChange>().SetColor(shape[num], selectionNum);
            Line[i].GetComponent<LineColorChange>().SetLine(LineShape[num], selectionNum);
        }
        BulletManager.GetComponent<BulletManager>().SetBullet(BulletShape[num], selectionNum);
        BulletManager.GetComponent<BulletManager>().SetBouncyBullet(BouncyBulletShape[num], selectionNum);
        // change New Image's Number
        listNum[selectionNum] = num;
        if (selectionNum == 0)
        {
            PlayerPrefs.SetInt("listNum0", listNum[selectionNum]);
        }
        else if (selectionNum == 1)
        {
            PlayerPrefs.SetInt("listNum1", listNum[selectionNum]);
        }
        else if (selectionNum == 2)
        {
            PlayerPrefs.SetInt("listNum2", listNum[selectionNum]);
        }
        else
        {
            PlayerPrefs.SetInt("listNum3", listNum[selectionNum]);
        }
    }
    // get changing Circle and Line Number
    public void Selection(int num)
    {
        selectionNum = num;
    }

    public void ChangeLineNum()
    {
        do
        {
            for (int i = 0; i < 4; i++)
            {
                Line[i].GetComponent<LineColorChange>().Num = Random.Range(0, 4);
            }
        }
        while (Line[0].GetComponent<LineColorChange>().Num == Line[1].GetComponent<LineColorChange>().Num &&
            Line[1].GetComponent<LineColorChange>().Num == Line[2].GetComponent<LineColorChange>().Num &&
            Line[2].GetComponent<LineColorChange>().Num == Line[3].GetComponent<LineColorChange>().Num &&
            Line[3].GetComponent<LineColorChange>().Num == Line[0].GetComponent<LineColorChange>().Num);
    }

    public void ResetBoxColor()
    {
        if (ResetCount >= 1)
        {
            for (int i = 0; i < 4; i++)
            {
                Box[i].GetComponent<ColorChange>().colorNum = Box[i].GetComponent<ColorChange>().FirstNum;
            }
            ResetCount--;
        }
    }

    public void BoxChangeColor(int BoxNum,int BulletNum)
    {
        if (BoxNum == 0)
        {
            if (ColorNum[0] == ColorNum[1])
            {
                if (ColorNum[0] == ColorNum[2])
                {
                    if (ColorNum[0] == ColorNum[3])
                    {
                        Box[3].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                    }
                    Box[2].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                }
                Box[1].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
            }
            if (ColorNum[0] == ColorNum[3])
            {
                if (ColorNum[0] == ColorNum[2])
                {
                    if (ColorNum[0] == ColorNum[1])
                    {
                        Box[1].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                    }
                    Box[2].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                }
                Box[3].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
            }
        }
        if (BoxNum == 1)
        {
            if (ColorNum[1] == ColorNum[2])
            {
                if (ColorNum[1] == ColorNum[3])
                {
                    if (ColorNum[1] == ColorNum[0])
                    {
                        Box[0].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                    }
                    Box[3].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                }
                Box[2].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
            }
            if (ColorNum[1] == ColorNum[0])
            {
                if (ColorNum[1] == ColorNum[3])
                {
                    if (ColorNum[1] == ColorNum[2])
                    {
                        Box[2].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                    }
                    Box[3].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                }
                Box[0].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
            }
        }
        if (BoxNum == 2)
        {
            if (ColorNum[2] == ColorNum[3])
            {
                if (ColorNum[2] == ColorNum[0])
                {
                    if (ColorNum[2] == ColorNum[1])
                    {
                        Box[1].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                    }
                    Box[0].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                }
                Box[3].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
            }
            if (ColorNum[2] == ColorNum[1])
            {
                if (ColorNum[2] == ColorNum[0])
                {
                    if (ColorNum[2] == ColorNum[3])
                    {
                        Box[3].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                    }
                    Box[0].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                }
                Box[1].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
            }
        }
        if (BoxNum == 3)
        {
            if (ColorNum[3] == ColorNum[0])
            {
                if (ColorNum[3] == ColorNum[1])
                {
                    if (ColorNum[3] == ColorNum[2])
                    {
                        Box[2].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                    }
                    Box[1].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                }
                Box[0].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
            }
            if (ColorNum[3] == ColorNum[0])
            {
                if (ColorNum[3] == ColorNum[1])
                {
                    if (ColorNum[3] == ColorNum[2])
                    {
                        Box[0].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                    }
                    Box[1].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
                }
                Box[2].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
            }
            
        }
        if (BoxNum == 0)
        {
            Box[0].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
        }
        if(BoxNum == 1)
        {
            Box[1].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
        }
        if(BoxNum == 2)
        {
            Box[2].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
        }
        if(BoxNum == 3)
        {
            Box[3].GetComponent<ColorChange>().ChangeMyColor(BulletNum);
        }
    }
}
