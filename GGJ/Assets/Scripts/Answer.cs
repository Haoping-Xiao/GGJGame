using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Answer : MonoBehaviour
{
    private int[] correctAnswer = { 1, 1, 2 };
    private int[,] score ={ { 10, -10 }, { 20, -20 }, { -15, 15 } };


    public GameObject session;
    static public int valueOfAngry = 0;
    private int min = 0;
    private int max = 100;
    void Update()
    {
        if(StartConversation.startAnswer)
        {
            GameObject Choice1 = GameObject.Find("Conversation/Answer/Choice1");
            Button btn1 = (Button)Choice1.GetComponent<Button>();
            btn1.onClick.AddListener(btn1Click);

            GameObject Choice2 = GameObject.Find("Conversation/Answer/Choice2");
            Button btn2 = (Button)Choice2.GetComponent<Button>();
            btn2.onClick.AddListener(btn2Click);
        }

    }

    void btn1Click()
    {
        if(StartConversation.startAnswer)
        {
            if (correctAnswer[UIManager.LastRandomNum] == 1)
            {//回答正确
                if (valueOfAngry != min)
                {
                    valueOfAngry = Mathf.Max(min, valueOfAngry - score[UIManager.LastRandomNum, 0]);
                }
            }
            else
            {//回答错误
                if (valueOfAngry != max)
                {
                    valueOfAngry = Mathf.Min(max, valueOfAngry - score[UIManager.LastRandomNum, 0]);
                }
            }
            GameObject ValueText = GameObject.Find("Conversation/ValueOfAngry/Text");
            ValueText.GetComponent<Text>().text = "愤怒值：" + valueOfAngry;
            session.GetComponent<StartConversation>().Close();//停止回答
        }


    }

    void btn2Click()
    {
        if(StartConversation.startAnswer)
        {

            if (correctAnswer[UIManager.LastRandomNum] == 2)
            {//回答正确
                if (valueOfAngry != min)
                {
                    valueOfAngry = Mathf.Max(min, valueOfAngry - score[UIManager.LastRandomNum, 1]);
                }
            }
            else
            {//回答错误
                if (valueOfAngry != max)
                {
                    valueOfAngry = Mathf.Min(max, valueOfAngry - score[UIManager.LastRandomNum, 1]);
                }
            }
            GameObject ValueText = GameObject.Find("Conversation/ValueOfAngry/Text");
            ValueText.GetComponent<Text>().text = "愤怒值：" + valueOfAngry;
            session.GetComponent<StartConversation>().Close();//停止回答
        }
        
    }
}
