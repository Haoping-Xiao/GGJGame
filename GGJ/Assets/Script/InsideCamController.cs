using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideCamController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookPos = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        Vector3 targetPostition = new Vector3(lookPos.x,
                                        this.transform.position.y,
                                        lookPos.z);
        this.transform.LookAt(targetPostition);
        //var lookPos = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        //Vector3 targetPostition = new Vector3(lookPos.position.x,
        //                               this.transform.position.y,
        //                               lookPos.position.z);
        //Quaternion targetRotation = Quaternion.LookRotation(lookPos);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
    }
}
