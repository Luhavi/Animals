using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCircle : MonoBehaviour
{
    [SerializeField] private float TurnSpeed;

    [SerializeField] private Vector2 PrevPoint;
    [SerializeField] private Slider sensitivity;
    private int isReverse;
    [SerializeField] private bool Move;

    private void Start()
    {
        TurnSpeed = PlayerPrefs.GetFloat("Sensitivity", 0);
        isReverse = PlayerPrefs.GetInt("Reverse", 0);
        sensitivity.value = TurnSpeed;
    }


    private void Update()
    {
        TurnSpeed = sensitivity.value;
        PlayerPrefs.SetFloat("Sensitivity",TurnSpeed);
        if (isReverse != 0)
        {
            TurnSpeed *= -1;
        }
        if (Move)
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    PrevPoint = Input.GetTouch(0).position;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    transform.Rotate(0, 0, (Input.GetTouch(0).position.x - PrevPoint.x) * TurnSpeed * Time.deltaTime);
                    PrevPoint = Input.GetTouch(0).position;
                }
            }
        }
    }

    public void Reverse()
    {
        if (isReverse == 0)
        {
            isReverse = 1;
        }
        else
        {
            isReverse = 0;
        }
        PlayerPrefs.SetInt("Reverse", isReverse);
    }
}
