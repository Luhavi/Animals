﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float DestroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
