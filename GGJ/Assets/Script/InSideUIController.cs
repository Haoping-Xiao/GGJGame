using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSideUIController : MonoBehaviour
{
    public static bool isInDesktop = false;
    public GameObject GameoverUI;
    public GameObject StartButtonUI;
    public GameObject WinUI;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
