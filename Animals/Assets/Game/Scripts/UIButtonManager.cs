using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject Banner;
    public float time1;
    public static int firstRun = 0;
    public Image tutorial;
    public Sprite[] sprite;
    private int i = 0;

    void Start()
    {
        if (GameObject.Find("Button") != null)
        {
            tutorial = GameObject.Find("Button").GetComponent<Image>();
        }
        Time.timeScale = 1;
        firstRun = PlayerPrefs.GetInt("firstRun");
        if (firstRun == 0)
        {
            PlayerPrefs.SetInt("listNum0", 0);
            PlayerPrefs.SetInt("listNum1", 1);
            PlayerPrefs.SetInt("listNum2", 2);
            PlayerPrefs.SetInt("listNum3", 3);
            PlayerPrefs.SetInt("firstRun", 1);
            PlayerPrefs.SetFloat("Sensitivity", 100);
        }
    }

    private void Update()
    {
        time1 = Time.timeScale;
    }

    public void OpenSettingPanel()
    {
        SettingPanel.SetActive(true);
    }

    public void CloseSettingPanel()
    {
        SettingPanel.SetActive(false);
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        ColorChange.score = 0;
        SceneManager.LoadScene("Play");
    }

    public void GStart()
    {
        SceneManager.LoadScene("Play");
        Time.timeScale = 1;
        ColorChange.score = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

    public void NextTutorial()
    {
        Time.timeScale = 1;
        tutorial.sprite = sprite[i];
        i++;
    }
}
