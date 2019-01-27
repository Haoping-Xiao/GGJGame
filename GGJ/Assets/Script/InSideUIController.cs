using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InSideUIController : MonoBehaviour
{
    //读取这个参数，若为真则妈妈未察觉到打游戏，否则察觉到
    public static bool isInDesktop = false;
    public GameObject GameoverUI;
    public GameObject StartButtonUI;
    public GameObject WinUI;
    
    // Start is called before the first frame update
    void Start()
    {
       
        StartButtonUI.GetComponent<Button>().onClick.AddListener(delegate { StartBedroom("Hello"); });
    }

    // Update is called once per frame
    void Update()
    {


        if (GameOver.isGameOver) {
            showGamover();
            StartCoroutine(hideGameover());
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            ToggleWindows();
        }
    }

    public void showGamover() {
        GameoverUI.SetActive(true);
        //----------------------------------------------------------
        //这里需要调用使男孩掉头发的函数
        //----------------------------------------------------------
    }
    IEnumerator hideGameover() {
        yield return new WaitForSeconds(2);
        GameoverUI.SetActive(false);
        StartButtonUI.SetActive(true);
    }

    public void hideSelf(GameObject go) {
        go.SetActive(false);
    }

    public void ToggleWindows() {
        isInDesktop = !isInDesktop;
        WinUI.SetActive(isInDesktop);
    }

    void StartBedroom(string message)
    {
        if (GameObject.Find("room") != null)
        {
            //----------------------------------------------------------
            //这里需要调用卧室里进程开始的函数（就是妈妈开始进来）
            if (GameController.IsFirstPlay) {
                GameController.IsFirstPlay = false;
                GameObject.Find("room").GetComponent<doorcontrol>().animstart();
            }
            //----------------------------------------------------------
        }
        else {
            print("mergeFailed");
        }
        
    }
}
