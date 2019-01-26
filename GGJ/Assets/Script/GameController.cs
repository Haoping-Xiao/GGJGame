using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float HealthBuffNewTime = 1f;
    public float TimeBuffNewTime = 10f;
    public static float HappniessPerBuff = 0.8f;
    public static float HealthBuffDuration = 5f;
    public static float TimeBuffDuration = 10f;
    public static float TimeBuffWorkTime = 6f;
    public static bool isHaveHealthBuff = false, isHaveTimeBuff = false;
    public static float currentHealthTime = 0, currentTimeTime = 0;
    GameObject[] healthTrans = new GameObject[] { };
    GameObject[] TimeTrans = new GameObject[] { };
    int HealthPointNum = 0, TimePointNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        healthTrans = GameObject.FindGameObjectsWithTag("HealthPoint");
        HealthPointNum = healthTrans.Length;
        TimeTrans = GameObject.FindGameObjectsWithTag("TimePoint");
        TimePointNum = TimeTrans.Length;
    }

    // Update is called once per frame
    void Update()
    {        //print("Start: " + GameOver.isGameStart + "  Over:  " + GameOver.isGameOver);
        if (GameOver.isGameStart) {
            currentHealthTime += Time.deltaTime;
            currentTimeTime += Time.deltaTime;
            if (currentHealthTime > HealthBuffNewTime && !isHaveHealthBuff)
            {
                NewHealthBuff();
                isHaveHealthBuff = true;
            }
            if (currentTimeTime > TimeBuffNewTime && !isHaveTimeBuff)
            {
                NewTimeBuff();
                isHaveTimeBuff = true;
            }
        }
        
    }

    void NewHealthBuff() {
        GameObject hbp =  Resources.Load("HeathBuff") as GameObject;
        int posChosed =  Random.Range(0, HealthPointNum);
        GameObject currentBuff = Instantiate(hbp, healthTrans[posChosed].transform);
        currentBuff.transform.localPosition = Vector3.zero;

    }

    void NewTimeBuff() {
        GameObject tbp = Resources.Load("TimeBuff") as GameObject;
        int posChosed = Random.Range(0, TimePointNum);
        GameObject currentBuff = Instantiate(tbp, TimeTrans[posChosed].transform);
        currentBuff.transform.localPosition = Vector3.zero;
    }
}
