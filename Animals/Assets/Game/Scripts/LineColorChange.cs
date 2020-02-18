using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColorChange : MonoBehaviour
{
    private SpriteRenderer Render;

    [SerializeField] private Sprite[] Line;

    public int Num;

    private void Start()
    {
        Render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Render.sprite = Line[Num];
    }

    public void SetLine(Sprite shape,int num)
    {
        Line[num] = shape;
    }

}
