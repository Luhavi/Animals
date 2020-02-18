using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public static int score;
    private int HighScore;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text HightScoreText;


    private ShapeChange shapeManager;
    private SpriteRenderer render;

    // 버튼 관련 변수
    [SerializeField] private GameObject shapeSetting;
    private GameObject Store;
    [SerializeField] private GameObject Exit;
    [SerializeField] private GameObject GameStart;
    [SerializeField] private GameObject DestroySound;

    [SerializeField] private bool gameMode;

    [SerializeField] private Sprite[] color;
    public int colorNum = 0;
    public int FirstNum;

    public float force = 0.2f;

    private void Awake()
    {
        Screen.SetResolution(1080, 1920, false);
    }

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        shapeManager = GameObject.Find("ShapeManager").GetComponent<ShapeChange>();
        Store = GameObject.Find("StoreButton");
        GameStart = GameObject.Find("GameStart");

        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (HightScoreText != null)
        {
            HightScoreText.text = HighScore.ToString();
        }
    }

    private void Update()
    {
        render.sprite = color[colorNum]; // 이미지 업데이트
        if (score > 100 && Time.timeScale > 0f)
        {
            Time.timeScale = 1.2f;
        }
        else if (score > 200 && Time.timeScale > 0f)
        {
            Time.timeScale = 1.4f;
        }
        else if (score > 300 && Time.timeScale > 0f)
        {
            Time.timeScale = 1.6f;
        }
        else if (score > 400 && Time.timeScale > 0f)
        {
            Time.timeScale = 1.8f;
        }
        else if (score > 500 && Time.timeScale > 0f)
        {
            Time.timeScale = 2f;
        }
        if (ScoreText != null)
        {
            ScoreText.text = score.ToString();
        }
        if (score > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", ColorChange.score);
            HighScore = PlayerPrefs.GetInt("HighScore", 0);
            if (HightScoreText != null)
            {
                HightScoreText.text = HighScore.ToString();
            }
        }
    }
    // 동물을 바꿈
    public void SetColorNum(int num)
    {
        colorNum = num;
    }
    // 동물의 모양을 바꿈
    public void SetColor(Sprite shape, int num)
    {
        color[num] = shape;
    }
    // 버튼 함수
    public void SettingMode()
    {
        gameMode = !gameMode;
        shapeSetting.SetActive(gameMode);
        Store.SetActive(!gameMode);
        Exit.SetActive(gameMode);
        GameStart.SetActive(!gameMode);
    }

    private void OnMouseEnter() // 마우스가 들어왔을 때
    {
        if (gameMode)
        {
            render.color = Color.gray;
        }
    }

    private void OnMouseDown() // 눌렀을 때
    {
        if (gameMode)
        {
            shapeManager.Selection(FirstNum);
        }
    }

    private void OnMouseExit() // 마우스가 나갔을 때
    {
        if (gameMode)
        {
            render.color = Color.white;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            shapeManager.GetComponent<ShapeChange>().BoxChangeColor(FirstNum, collision.gameObject.GetComponent<BulletColor>().ColorNum);
            if (colorNum == collision.gameObject.GetComponent<BulletColor>().ColorNum)
            {
                score++;
            }
            score++;
            Instantiate(DestroySound);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BouncyBullet")
        {
            if (colorNum == collision.gameObject.GetComponent<BulletColor>().ColorNum)
            {
                Instantiate(DestroySound);
                Destroy(collision.gameObject);
                score += 2;
            }
            score--;
        }
    }

    public void ChangeMyColor(int Color)
    {
        colorNum = Color;
    }
}
