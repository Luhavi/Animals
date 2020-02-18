using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchToScreen : MonoBehaviour
{
    int firstRun;
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1080, 1920, false);
    }

    // Update is called once per frame
    void Update()
    {
        firstRun = PlayerPrefs.GetInt("firstRun");
    }
    private void OnMouseDown() // 눌렀을 때
    {
        if (firstRun == 0)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            SceneManager.LoadScene("Home");
        }

    }
}
