﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorcontrol : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject momintheroom;
    void Start()
    {
        momintheroom.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animstop()
    {
        momintheroom.SetActive(true);
        this.GetComponent<Animator>().SetBool("openanim", false);
    }

    public void animstart()
    {
        this.GetComponent<Animator>().SetBool("openanim", true);
    }
}
