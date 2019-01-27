using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mother : MonoBehaviour
{


    //母亲出现的位置
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 angerypos;
    static public int momposrandom;

    public static bool islooking = false;

    float looktime = 0f;

    [Space]
    //位置变化的时间间隔
    public float intervaltime = 0f;

    Animator Momanim;


    // Use this for initialization
    void Start()
    {
        Momanim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GameObject.FindGameObjectWithTag("Anger").GetComponent<Slider>().value = Answer.valueOfAngry;
        if (!StartConversation.startAnswer)
        {
            intervaltime += Time.fixedDeltaTime;
        }
        if (intervaltime > 3.0f)
        {
            //Debug.Log(Time.time);
            intervaltime = 0f;

            //妈位置随机
            momposrandom = Random.Range(1, 3);

            if (momposrandom == 1)
            {
                this.GetComponent<RectTransform>().position = pos1;
                //Debug.Log("position 1");
            }
            else if (momposrandom == 2)
            {
                this.GetComponent<RectTransform>().position = pos2;
                //Debug.Log("position 2");
            }



            //妈动作随机
            int momanimrandom = Random.Range(1, 4);

            if (momanimrandom == 1)
            {
                Momanim.SetBool("one", true);
                Momanim.SetBool("two", false);
                Momanim.SetBool("three", false);
                //Debug.Log("anim 1");
            }
            else if (momanimrandom == 2)
            {
                Momanim.SetBool("two", true);
                Momanim.SetBool("one", false);
                Momanim.SetBool("three", false);
                //  Debug.Log("anim 2");
            }
            else
            {
                Momanim.SetBool("three", true);
                Momanim.SetBool("two", false);
                Momanim.SetBool("one", false);
                // Debug.Log("anim 3");
            }



            if (Answer.valueOfAngry == 50||Answer.valueOfAngry==60)
            {
                Momanim.SetBool("peeping", true);
                islooking = true;
                Invoke("Stoplooking", 5.0f);
            }


            if (Answer.valueOfAngry >= 100)
            {
                Momanim.SetBool("pointing", true);
                Momanim.SetBool("ispoint", true);
               
            }
        }
        }

    
    void Stoplooking()
    {
        Answer.valueOfAngry -=30;
        Momanim.SetBool("peeping", false);
        islooking = false;
        
    }


}


