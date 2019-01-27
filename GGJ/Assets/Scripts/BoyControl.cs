﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class BoyControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Sprite[] frontheads;

    public static int hairstate=3;
    public AudioClip mao;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(hairstate);
        if(hairstate>=0&&hairstate<=frontheads.Length)
            this.GetComponent<Image>().sprite = frontheads[hairstate];
        
    }
}
