using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{




    private string UI_GAMEPANEL_ROOT = "Prefabs/GamePanel/";

    public GameObject m_CanvasRoot;

    public Dictionary<string, GameObject> m_PanelList = new Dictionary<string, GameObject>();

    Vector3[] Q_position = new Vector3[] { new Vector3(450, 300, 0), new Vector3(450, 300, 0) };//position of question
    Vector3 A_position = new Vector3(350, 100, 0);
    Vector3 Win_position = new Vector3(350, 350, 0);

    string[] quesiton = new string[] { "我来扫一扫你房间嗷", "上次考试你考了全班倒数第一这次打算咋办？！", "之前隔壁李阿姨晾的貂皮大衣是你踢球弄脏的吗！" , "这个游戏你不能暂停吗？",
                                       "我和你爸同时掉河里，你先救谁？","你是不又找女朋友了？" ,"你也别闲着，去帮我浇一下花呀？","啊！那有一只蟑螂，快帮我把它抓走！",
                                       "突然想起今天我还没有偷菜，你赶快帮我去偷菜！","今天你想吃饺子还是肯德基？","班主任说你上课总跟朱戈说话，你有啥解释的吗！","你寒假作业做好了吗？",
                                       "你想不想学钢琴？","你上次买的那个闹钟被你丢哪儿了？","隔壁小叶昨天上网吧被他爸逮住了你知道不？"};


    string[,] answer = { { "反对", "好的" },{ "这学期好好学习!", "我现在就去学习！" }, { "如实回答是自己弄脏的！", "撒谎说不是你弄脏的！" }, { "妈！这是宇宙组织ggj制作的大型多人在线角色扮演类游戏！不能暂停！", "假装把这个不能暂停的游戏暂停！" },
                         { "当然是先救你啦！","当然是先救我爸！"}, { "如实回答没有啊！","假装说：是的又找了！"} , {"啊，我在玩游戏去不了！","好的我现在就去！" } , { "啊，我在玩游戏去不了！","好的我现在就去！"},
                          { "啊，我在玩游戏去不了！","好的我现在就去！"} , { "我喜欢吃妈妈包的饺子","肯德基！"} , { "朱戈总鸽我，ggj都没来，害得我一个人当策划美术程序音频QA！","没有"}, {"老早做好了" ,"我做好了在看网课呢"},
                           { "我不喜欢钢琴，我喜欢电子琴","我不想学乐器"} , {"床上","墙柜上"}, { "表示你不知道小叶去了网吧","谴责小军的行为"} };

    static public int LastRandomNum = 0;

    private bool CheckCanvasRootIsNull()
    {
        if (m_CanvasRoot == null)
        {
            Debug.LogError("m_CanvasRoot is null,Pls add UIRoothandler.cs in your canvas");
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool IsPanelLive(string name)
    {
        return m_PanelList.ContainsKey(name);
    }
    public GameObject ShowPanel(string name)
    {
        if (CheckCanvasRootIsNull())
        {
            return null;
        }
        if (IsPanelLive(name))
        {
            Debug.LogErrorFormat("[{0}] is showing,if u want to show,pls close first!", name);
            return null;
        }
        GameObject loadGo = Utility.AssetRelate.ResourcesLoadCheckNull<GameObject>(UI_GAMEPANEL_ROOT + name);
        if (loadGo == null)
            return null;

        GameObject panel = Utility.GameObjectRelate.InstantiateGameObject(m_CanvasRoot, loadGo);//实例化
        if (name == "Question")
        {
            //Debug.Log("Mother.momposrandom " + Mother.momposrandom);
            if (Mother.momposrandom == 2)
            {
                panel.transform.position = Q_position[1];                              //positon of question
                                                                                       // Debug.Log("panel.transform.position  " + panel.transform.position);
            }
            else if (Mother.momposrandom == 1 || Mother.momposrandom == 0)
            {
                panel.transform.position = Q_position[0];                              //positon of question
                                                                                       // Debug.Log("panel.transform.position  " + panel.transform.position);

            }


            GameObject panelText = panel.transform.GetChild(0).gameObject;//get the text
            panelText.GetComponent<Text>().text = quesiton[GetRandomNum()];//give the random question
        }
        else if (name == "YouWin")
        {
            panel.transform.position = Win_position;
        }
        else if (name == "GameOver")
        {
            panel.transform.position = Win_position;
        }
        else
        {
            panel.transform.position = A_position;

            GameObject Choice1 = panel.transform.GetChild(0).gameObject;//get the first choice
            GameObject Choice1Text = Choice1.transform.GetChild(0).gameObject;//get the text of the first choice
            Choice1Text.GetComponent<Text>().text = answer[LastRandomNum, 0];//give the first answer

            GameObject Choice2 = panel.transform.GetChild(1).gameObject;//get the second choice
            GameObject Choice2Text = Choice2.transform.GetChild(0).gameObject;//get the text of the second choice
            Choice2Text.GetComponent<Text>().text = answer[LastRandomNum, 1];//give the second answer



        }



        panel.name = name;

        m_PanelList.Add(name, panel);

        return panel;
    }
    public void TogglePanel(string name, bool isOn)
    {
        if (IsPanelLive(name))
        {
            if (m_PanelList[name] != null)
                m_PanelList[name].SetActive(isOn);
        }
        else
        {
            Debug.LogErrorFormat("TogglePanel [{0}] not found.", name);
        }
    }
    public void ClosePanel(string name)
    {
        if (IsPanelLive(name))
        {
            if (m_PanelList[name] != null)
                Object.Destroy(m_PanelList[name]);
            m_PanelList.Remove(name);
        }
        else
        {
            Debug.LogErrorFormat("ClosePanel [{0}] not found.", name);
        }
    }
    public void CloseAllPanel()
    {
        foreach (KeyValuePair<string, GameObject> item in m_PanelList)
        {
            if (item.Value != null)
                Object.Destroy(item.Value);
        }
        m_PanelList.Clear();
    }
    public Vector2 GetCanvasSize()
    {
        if (CheckCanvasRootIsNull())
            return Vector2.one * -1;
        RectTransform trans = m_CanvasRoot.transform as RectTransform;
        return trans.sizeDelta;
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
