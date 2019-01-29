using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedroomScript : MonoBehaviour
{
    [Header("InsideGame")]
    public string LoadLevelName = "InsideGame";
    void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadSceneAsync(LoadLevelName, LoadSceneMode.Additive);
    }
    public void TestCall()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            RestartAll();
        }
    }
    public void RestartAll() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        Answer.valueOfAngry = 0;
        GameController.IsFirstPlay = true;
        BoyControl.hairstate = 3;
        GameOver.ResetInsideGame();
    }
}
