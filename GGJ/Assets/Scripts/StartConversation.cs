using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartConversation : MonoBehaviour
{
    public GameObject prefab;
    private float initial;
    private int randomBegin;
    private float startAnswerTime;//the time of begin answer
    private int answerDuration = 5;
    private int DontAnswer = 20;
    static public bool startAnswer = false;//whether start answer or not
    // Start is called before the first frame update
    void Start()
    {
        initial = Time.time;
        randomBegin = Random.Range(5, 9);
    }


    void FixedUpdate()
    {
       // Debug.Log("time" + Time.time);
       // Debug.Log("randomBegin" + randomBegin);
        if (Time.time - initial >= randomBegin && !startAnswer)
        {
            UIManager.Instance.ShowPanel("Question");
            UIManager.Instance.ShowPanel("Answer");
            startAnswer = true;
            startAnswerTime = Time.time;
        }


        if (startAnswer)
        {
            if(Time.time -startAnswerTime>=answerDuration)//the question is over
            {
                GameObject ValueText = GameObject.Find("Conversation/ValueOfAngry/Text");
                Answer.valueOfAngry = Mathf.Min(100, Answer.valueOfAngry + DontAnswer);
                ValueText.GetComponent<Text>().text = "愤怒值：" + Answer.valueOfAngry;
                Close();
            }
        }


    }


     public void Close()
    {
        UIManager.Instance.ClosePanel("Question");
        UIManager.Instance.ClosePanel("Answer");
        startAnswer = false;
        initial = Time.time;
        randomBegin = Random.Range(5, 9);
    }
}
