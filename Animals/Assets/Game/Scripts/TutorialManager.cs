using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject circle;
    public GameObject FirstBullet;
    public GameObject SecondBullet;
    public GameObject ThirdBullet;
    public GameObject FourthBullet;
    public GameObject FifthBullet;
    public GameObject EndPanel;
    public int stop = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FirstBullet == null)
        {
            if (SecondBullet != null)
            {
                SecondBullet.SetActive(true);
                if (stop == 0)
                    stop = 1;
            }
        }
        if (SecondBullet == null)
        {
            if (ThirdBullet != null)
            {
                ThirdBullet.SetActive(true);
                if (stop == 2)
                    stop = 3;
            }
        }
        if (ThirdBullet == null)
        {
            if (FourthBullet != null)
            {
                FourthBullet.SetActive(true);
                if (stop == 4)
                    stop = 5;
            }
        }
        if (FourthBullet == null)
        { 
            if (FifthBullet != null)
            {
                FifthBullet.SetActive(true);
                if (stop == 6)
                    stop = 7;
            }
        }
        if(FifthBullet == null)
        {
            EndPanel.SetActive(true);
        }
        if (stop%2 == 1)
        {
            Time.timeScale = 0;
            stop++;
        }
    }
}
