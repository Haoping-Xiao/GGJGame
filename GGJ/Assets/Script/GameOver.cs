using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        StopPlayer(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) {
            StartCoroutine(resetGame());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            isGameOver = true;
            print("Game over");
        }
    }


    void StopPlayer(bool isStop) {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = isStop;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharactorController>().enabled = !isStop;
    }

    IEnumerator resetGame() {
        yield return new WaitForSeconds(2);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 5, -2);
        StopPlayer(true);
        isGameOver = false;
        isGameStart = false;
        GameController.isHaveHealthBuff = false;
        GameController.isHaveTimeBuff = false;
        GameController.currentHealthTime = 0;
        GameController.currentTimeTime = 0;
        CharactorController.Happyness = 1;
        CharactorController.Emission = 1;
    }

    public void StartGame() {
        isGameOver = false;
        isGameStart = true;
        StopPlayer(false);
    }
}
