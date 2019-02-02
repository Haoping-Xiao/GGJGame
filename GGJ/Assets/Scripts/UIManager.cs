using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{




    private string UI_GAMEPANEL_ROOT = "Prefabs/GamePanel/";

    public GameObject m_CanvasRoot;

    public Dictionary<string, GameObject> m_PanelList = new Dictionary<string, GameObject>();
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
    public GameObject ShowPanel(string name,Vector3 position)
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

        panel.transform.position = position;
        //if (name == "Question")
        //{
        //    panel.transform.localPosition = Q_position[1];

        //    GameObject panelText = panel.transform.GetChild(0).gameObject;//get the text
        //    panelText.GetComponent<Text>().text = quesiton[GetRandomNum()];//give the random question
        //}
        //else if (name == "YouWin")
        //{
        //    panel.transform.position = Win_position;
        //}
        //else if (name == "GameOver")
        //{
        //    panel.transform.position = Win_position;
        //}
        //else
        //{
        //    panel.transform.localPosition = A_position;

        //    GameObject Choice1 = panel.transform.GetChild(0).gameObject;//get the first choice
        //    GameObject Choice1Text = Choice1.transform.GetChild(0).gameObject;//get the text of the first choice
        //    Choice1Text.GetComponent<Text>().text = answer[LastRandomNum, 0];//give the first answer

        //    GameObject Choice2 = panel.transform.GetChild(1).gameObject;//get the second choice
        //    GameObject Choice2Text = Choice2.transform.GetChild(0).gameObject;//get the text of the second choice
        //    Choice2Text.GetComponent<Text>().text = answer[LastRandomNum, 1];//give the second answer



        //}



        panel.name = name;

        m_PanelList.Add(name, panel);

        return panel;
    }
    public GameObject ShowPanelWithText(string name,string text,Vector3 position)
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
        panel.transform.localPosition = position;
        GameObject panelText= panel.transform.GetChild(0).gameObject;//get the text
        panelText.GetComponent<Text>().text = text;
        panel.name = name;
        m_PanelList.Add(name, panel);
        return panel;
    }

    public GameObject ShowPanelWithTwoButton(string name, string text1, string text2, Vector3 position)
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
        panel.transform.localPosition = position;


        GameObject Choice1 = panel.transform.GetChild(0).gameObject;//get the first choice
        GameObject Choice1Text = Choice1.transform.GetChild(0).gameObject;//get the text of the first choice
        Choice1Text.GetComponent<Text>().text = text1;//give the first answer

        GameObject Choice2 = panel.transform.GetChild(1).gameObject;//get the second choice
        GameObject Choice2Text = Choice2.transform.GetChild(0).gameObject;//get the text of the second choice
        Choice2Text.GetComponent<Text>().text = text2;//give the second answer


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

    
}
