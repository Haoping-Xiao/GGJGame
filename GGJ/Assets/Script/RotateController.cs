using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    Animator ani;
    public float Frequency;
    int currentState = 0;
    float timePassed;
    public static bool IsRotate = true;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver.isGameStart) {
            if (IsRotate)
            {
                ani.enabled = true;
                timePassed += Time.deltaTime;
                if (timePassed > Frequency && currentState == 0)
                {
                    currentState = Random.Range(1, 5);
                    ani.SetInteger("State", currentState);
                    StartCoroutine(setBack());
                    timePassed = 0;
                }
            }
            else
            {
                StartCoroutine(RestartRotate());
                ani.enabled = false;
            }
        }
    }

    IEnumerator setBack() {
        yield return new WaitForSeconds(0.5f);
        currentState = 0;
        ani.SetInteger("State", currentState);
    }

    IEnumerator RestartRotate()
    {
        yield return new WaitForSeconds(GameController.TimeBuffWorkTime);
        IsRotate = true;
    }
}
