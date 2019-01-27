using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class BoyControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Sprite[] frontheads;
    public float HairNewTime = 20f;
    float currentTime = 0;
    public static int hairstate=3;
    public AudioClip mao;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mother.islooking)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if (GameOver.isGameStart) {
          

            currentTime += Time.deltaTime;
            if (currentTime > HairNewTime)
            {
                addHair();
                currentTime = 0;
            }
            print(hairstate);
            if (hairstate >= 0 && hairstate <= frontheads.Length)
                this.GetComponent<Image>().sprite = frontheads[hairstate];

        }
      
        
    }

    void addHair() {
        if (hairstate < 3) {
            hairstate += 1;
        }
    }


}
