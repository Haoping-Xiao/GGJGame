using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Answer : MonoBehaviour
{

    private GameObject over;
    private GameObject win;
    private GameObject Audio;
    private AudioSource audio_source;

    private int[] correctAnswer = { 2, 2, 1 ,2, 1,
                                    1, 2, 2, 2, 1,
                                    1, 2, 1, 2, 2};
    private int[,] score ={ { -20, 0 }, { -10, 20 }, { 10, -10 }, { -10, 10 }, { 10, -20 },
                            {-10, -20}, {-10, 10 }, {-30, 30 }, {-20, 20}, { 10, -10},
                            {20, -20},  {-10, 10 }, {-10,-20 }, { -10,10}, {-10, 10 } };


    private GameObject session;
    static public int valueOfAngry = 40;
    private int min = 0;
    private int max = 100;
    private float duration = 1.0f;
    private float count = 0;
    AudioClip[] MotherSound;
    
    void Start()
    {
        over = Resources.Load("Prefabs/GamePanel/EndCanvas") as GameObject;
        win = Resources.Load("Prefabs/GamePanel/Win") as GameObject;
        session = GameObject.Find("Conversation");
        MotherSound = new AudioClip[] {
                                     (AudioClip)Resources.Load("Sounds/00-1"),//答对了
                                     //(AudioClip)Resources.Load("Sounds/00-2"),
                                     (AudioClip)Resources.Load("Sounds/00-3")//答错了
        };
        Audio = GameObject.Find("Audio");
        audio_source = Audio.GetComponent<AudioSource>();
    }
    void Update()
    {
        GameObject ValueText = GameObject.Find("Conversation/ValueOfAngry/Text");
        ValueText.GetComponent<Text>().text = "愤怒值：" + valueOfAngry;
        //Debug.Log("Answer.valueOfAngry     " + Answer.valueOfAngry);
        //Debug.Log("!StartConversation.IsOver   " + !StartConversation.IsOver);
        if (Answer.valueOfAngry >= 100 && !StartConversation.IsOver)
        {
            StartConversation.IsOver = true;
            StartCoroutine(delay());
            
        }

        if (StartConversation.startAnswer)
        {
            if (GameObject.Find("Conversation/Answer/Choice1") != null) {
                GameObject Choice1 = GameObject.Find("Conversation/Answer/Choice1");
                Button btn1 = (Button)Choice1.GetComponent<Button>();
               
                btn1.onClick.AddListener(btn1Click);
            }

            if (GameObject.Find("Conversation/Answer/Choice2") != null)
            {
                GameObject Choice2 = GameObject.Find("Conversation/Answer/Choice2");
                Button btn2 = (Button)Choice2.GetComponent<Button>();
                
                btn2.onClick.AddListener(btn2Click);
            }
        }


    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
        GameObject over1 = Instantiate(over);
    }
    void btn1Click()
    {
        //Debug.Log("按钮1");
        if (StartConversation.startAnswer)
        {
            if (correctAnswer[StartConversation.LastRandomNum] == 1)
            {//回答正确
                if (valueOfAngry != min)
                {
                    valueOfAngry = Mathf.Max(min, valueOfAngry - score[StartConversation.LastRandomNum, 0]);
                }
                audio_source.PlayOneShot(MotherSound[0]);//答对音效
            }
            else
            {//回答错误
                if (valueOfAngry != max)
                {
                    valueOfAngry = Mathf.Min(max, valueOfAngry - score[StartConversation.LastRandomNum, 0]);
                }
                audio_source.PlayOneShot(MotherSound[1]);//答错音效
            }
            GameObject ValueText = GameObject.Find("Conversation/ValueOfAngry/Text");
            ValueText.GetComponent<Text>().text = "愤怒值：" + valueOfAngry;
            session.GetComponent<StartConversation>().Close();//停止回答
            if (StartConversation.question_num == StartConversation.limit_num)
            {
                StartConversation.IsWin = true;
                GameObject win1 = Instantiate(win);
            }

        }


    }

    void btn2Click()
    {
        Debug.Log("按钮2");
        if (StartConversation.startAnswer)
        {

            if (correctAnswer[StartConversation.LastRandomNum] == 2)
            {//回答正确
                if (valueOfAngry != min)
                {
                    valueOfAngry = Mathf.Max(min, valueOfAngry - score[StartConversation.LastRandomNum, 1]);
                }
                audio_source.PlayOneShot(MotherSound[0]);//答对音效
            }
            else
            {//回答错误
                if (valueOfAngry != max)
                {
                    valueOfAngry = Mathf.Min(max, valueOfAngry - score[StartConversation.LastRandomNum, 1]);
                }
                audio_source.PlayOneShot(MotherSound[1]);//答错音效
            }
            GameObject ValueText = GameObject.Find("Conversation/ValueOfAngry/Text");
            ValueText.GetComponent<Text>().text = "愤怒值：" + valueOfAngry;
            session.GetComponent<StartConversation>().Close();//停止回答
            if (StartConversation.question_num == StartConversation.limit_num)
            {
                StartConversation.IsWin = true;
                GameObject win1 = Instantiate(win);
            }
        }

    }


}
