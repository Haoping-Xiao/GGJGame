using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    //public float rotateCD = 3f;

    //public float relaxTime = 0.5f;
    //public float stayTime = 0.5f;
    //public float turnSpeed = 1f;
    ///// <summary>
    ///// 0：平
    ///// 1：左
    ///// 2：前
    ///// 3：右
    ///// 4：后
    ///// </summary>
    //public int TurnState = 0;
    //private Quaternion leftAngle = new Quaternion(0, 0, 0.1f, 1);
    //private Quaternion righttAngle = new Quaternion(0, 0, -0.1f, 1);
    //private Quaternion forwardtAngle = new Quaternion(-0.1f, 0, 0, 1);
    //private Quaternion backAngle = new Quaternion(0.1f, 0, 0, 1);
    //private Quaternion FlatAngle = new Quaternion(0, 0, 0, 1);

    //private bool isDirDecided = false;
    //private float TimePeriod =0;
    //private float StayTimePeriod =0;
    //private float RotateTimeToTake =5;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    TimePeriod += Time.deltaTime;
    //    if (TimePeriod > rotateCD)
    //    {
    //        if (!isDirDecided)
    //        {
    //            TurnState = Random.Range(1, 5);
    //            isDirDecided = true;
    //        }
    //        StartCoroutine(rotateRandomly());
    //    }

    //    if (StayTimePeriod > stayTime) {
    //        StartCoroutine(rotateBack());
    //    }
    //}

    //IEnumerator rotateRandomly() {
    //    StayTimePeriod += Time.deltaTime;
    //    switch (TurnState)
    //    {
    //        case 1:
    //            transform.rotation = Quaternion.Lerp(transform.rotation, leftAngle, Time.deltaTime * 1);
    //            break;
    //        case 2:
    //            transform.rotation = Quaternion.Lerp(transform.rotation, forwardtAngle, Time.deltaTime * 1);
    //            break;
    //        case 3:
    //            transform.rotation = Quaternion.Lerp(transform.rotation, leftAngle, Time.deltaTime * 1);
    //            break;
    //        case 4:
    //            transform.rotation = Quaternion.Lerp(transform.rotation, backAngle, Time.deltaTime * 1);
    //            break;
    //        case 0:
    //            break;
    //    };
    //    yield return new WaitForSeconds(rotateCD);
    //    TimePeriod = 0;
    //    isDirDecided = false;
    //}


    //IEnumerator rotateBack()
    //{
    //    transform.rotation = Quaternion.Lerp(transform.rotation, FlatAngle, Time.deltaTime * 1);
    //    yield return new WaitForSeconds(RotateTimeToTake);
    //    TurnState = 0;
    //    StayTimePeriod = 0;
    //}

    public GameObject targetObj;
    int speed = 5;

    public float stayTime = 1f, stableTime = 1f, leanFrequency = 5;
    int currentState = 0, lastState = 0;
    bool isDirDecided = false;
    Vector3 leftTargetPos = new Vector3(0, 3, 10);
    Vector3 rightTargetPos = new Vector3(0, -3, 10);
    Vector3 backTargetPos = new Vector3(-10, -3, 0);
    Vector3 forTargetPos = new Vector3(-10, 3, 0);
    Vector3 flatTargetPos = new Vector3(0, 0, 0);
    float TimePeriod = 0;

    void Update()
    {
        print("c:" + currentState + "  l:" + lastState);
        lastState = currentState;
        TimePeriod += Time.deltaTime;
        if (TimePeriod > leanFrequency)
        {
           
            currentState = Random.Range(1, 5);
            setTarget();
            TimePeriod = 0;
        }
        Quaternion targetRotation;
        if (currentState == 1 || currentState == 3)
        {
            targetRotation = Quaternion.LookRotation(targetObj.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
        else if (currentState == 2 || currentState == 4)
        {
            targetRotation = Quaternion.LookRotation(targetObj.transform.position - transform.GetChild(0).position);
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, targetRotation, speed * Time.deltaTime);
        }
        else {

        }

    }
    /// <summary>
    /// ture lr, flase bf
    /// </summary>
    /// <param name="dir"></param>
    /// 
    void setTarget()
    {
        switch (currentState)
        {
            case 1:
                targetObj.transform.position = leftTargetPos;
                break;
            case 2:
                targetObj.transform.position = forTargetPos;
                break;
            case 3:
                targetObj.transform.position = rightTargetPos;
                break;
            case 4:
                targetObj.transform.position = backTargetPos;
                break;
            case 0:
                targetObj.transform.position = flatTargetPos;
                break;
        }
    }
}
