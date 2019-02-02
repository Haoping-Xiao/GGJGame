using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartConversation : MonoBehaviour
{
    /****************************constant*****************************/
    private int answerDuration = 5;
    private int DontAnswer = 20;
    static public int limit_num = 10;
    Vector3 Q_position = new Vector3(50, 250, 0);
    Vector3 A_position = new Vector3(210, -140, 0);
    string[] quesiton = new string[] { "我来扫一扫你房间嗷", "上次考试你考了全班倒数第一这次打算咋办？！", "之前隔壁李阿姨晾的貂皮大衣是你踢球弄脏的吗！" , "这个游戏你不能暂停吗？",
                                       "我和你爸同时掉河里，你先救谁？","你是不又找女朋友了？" ,"你也别闲着，去帮我浇一下花呀？","啊！那有一只蟑螂，快帮我把它抓走！",
                                       "突然想起今天我还没有偷菜，你赶快帮我去偷菜！","今天你想吃饺子还是肯德基？","班主任说你上课总跟朱戈说话，你有啥解释的吗！","你寒假作业做好了吗？",
                                       "你想不想学钢琴？","你上次买的那个闹钟被你丢哪儿了？","隔壁小叶昨天上网吧被他爸逮住了你知道不？"};


    string[,] answer = { { "反对", "好的" },{ "这学期好好学习!", "我现在就去学习！" }, { "如实回答是自己弄脏的！", "撒谎说不是你弄脏的！" }, { "妈！这是宇宙组织ggj制作的大型多人在线角色扮演类游戏！不能暂停！", "假装把这个不能暂停的游戏暂停！" },
                         { "当然是先救你啦！","当然是先救我爸！"}, { "如实回答没有啊！","假装说：是的又找了！"} , {"啊，我在玩游戏去不了！","好的我现在就去！" } , { "啊，我在玩游戏去不了！","好的我现在就去！"},
                          { "啊，我在玩游戏去不了！","好的我现在就去！"} , { "我喜欢吃妈妈包的饺子","肯德基！"} , { "朱戈总鸽我，ggj都没来，害得我一个人当策划美术程序音频QA！","没有"}, {"老早做好了" ,"我做好了在看网课呢"},
                           { "我不喜欢钢琴，我喜欢电子琴","我不想学乐器"} , {"床上","墙柜上"}, { "表示你不知道小叶去了网吧","谴责小军的行为"} };

    /****************************constant*****************************/
    /*****************************************************************/

    /**************************RunOnlyOnce****************************/
    static public bool IsWin = false;
    static public bool IsOver = false;

    /**************************RunOnlyOnce****************************/
    /*****************************************************************/

    /**************************GameObject*****************************/
    public GameObject prefab;
    private GameObject over;
    private GameObject win;
    /**************************GameObject*****************************/
    /*****************************************************************/
    /******************************Record*****************************/
    private float initial;
    private int randomBegin;
    private float startAnswerTime;//the time of begin answer
    static public bool startAnswer = false;//whether start answer or not
    static public int question_num = 0;
    static public int LastRandomNum = 0;
    /******************************Record*****************************/
    /*****************************************************************/





    void Start()
    {
        initial = Time.time;
        randomBegin = Random.Range(5, 9);
        over = Resources.Load("Prefabs/GamePanel/EndCanvas") as GameObject;
        win = Resources.Load("Prefabs/GamePanel/Win") as GameObject;
    }
    void FixedUpdate()
    {
        
        if (BoyControl.hairstate == 0 && !IsOver)
        {
            IsOver = true;
            StartCoroutine(delay());
            
        }
        if (IsWin || IsOver) return;

        if (Time.time - initial >= randomBegin && !startAnswer)
        {
            question_num++;
            UIManager.Instance.ShowPanelWithText("Question", quesiton[GetRandomNum()], Q_position);
            UIManager.Instance.ShowPanelWithTwoButton("Answer", answer[LastRandomNum, 0], answer[LastRandomNum, 1], A_position);
            startAnswer = true;
            startAnswerTime = Time.time;
        }


        if (startAnswer)
        {
            
            if (Time.time - startAnswerTime >= answerDuration)//the question is over
            {
                GameObject ValueText = GameObject.Find("Conversation/ValueOfAngry/Text");
                Answer.valueOfAngry = Mathf.Min(100, Answer.valueOfAngry + DontAnswer);
                ValueText.GetComponent<Text>().text = "愤怒值：" + Answer.valueOfAngry;
                Close();
                if (question_num == limit_num )
                {
                    IsWin = true;                 
                    GameObject win1 = Instantiate(win);
                }
            }
        }


    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
        GameObject over1 = Instantiate(over);
    }
    public void Close()
    {
        UIManager.Instance.ClosePanel("Question");
        UIManager.Instance.ClosePanel("Answer");
        startAnswer = false;
        PlaySound.HadPlayed = false;
        initial = Time.time;
        randomBegin = Random.Range(5, 9);
    }

    private int GetRandomNum()
    {
        int RandomNum = 0;
        do
        {
            RandomNum = Random.Range(0, quesiton.Length);
        }
        while (RandomNum == LastRandomNum);
        LastRandomNum = RandomNum;

        return RandomNum;


    }
}
