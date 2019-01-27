using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorcontrol : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject momintheroom;
    public GameObject startconversation;
    void Start()
    {
        startconversation.SetActive(false);
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
        startconversation.SetActive(true);
        this.GetComponent<Animator>().SetBool("openanim", true);
    }
}
