using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    float initY;
    AudioSource[] audiosource;
    AudioClip collide;
    bool isCollide = false;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponents<AudioSource>();
        initY = transform.localPosition.y;
        StartCoroutine(DestoryWithDelay(GameController.HealthBuffDuration - 1));
        StartCoroutine(DestoryWithDelay(GameController.HealthBuffDuration));
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, initY + 0.3f*Mathf.Sin(Time.time * 3), 0);
    }
    IEnumerator DispearWithDelay(float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        Dispear();
    }
    IEnumerator DestoryWithDelay(float delaytime) {
        yield return new WaitForSeconds(delaytime);

        GameController.isHaveHealthBuff = false;
        GameController.currentHealthTime = 0;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"&&!isCollide) {
            audiosource[0].PlayOneShot(audiosource[0].clip, 0.3F);
            audiosource[1].Stop();
            AddHappness();
            Fetched();
            isCollide = true;
        }
    }

    void Dispear() {

    }

    void Fetched()
    {
        GetComponent<Light>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        StartCoroutine(DestoryWithDelay(1));
    }
    void AddHappness() {
        if(CharactorController.Happyness<1)
            CharactorController.Happyness += GameController.HappniessPerBuff;
        if (CharactorController.Emission < 5)
            CharactorController.Emission += 4f;
    }
}
