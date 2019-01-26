using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    public float ForceStrength = 20;
    public float GravityStrength = -30;
    public Material playerMat;
    public static float Happyness = 1;
    public static float Emission = 1;
    public static bool IsOnGround = false;
    Color baseColor = new Color(0.67f, 0.125f, 0.027f);
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, GravityStrength, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // print(GetComponent<Rigidbody>().velocity.x + GetComponent<Rigidbody>().velocity.y + GetComponent<Rigidbody>().velocity.z);
        print(IsOnGround);
        if (IsOnGround)
        {
            gameObject.GetComponent<AudioSource>().volume = 0.2f * Mathf.Abs(GetComponent<Rigidbody>().velocity.x + GetComponent<Rigidbody>().velocity.y + GetComponent<Rigidbody>().velocity.z);
        }
        else {
            gameObject.GetComponent<AudioSource>().volume = 0;
        }
        if (Happyness > 0)
        {
            Happyness -= 0.001f;
        }
        else {
            GameOver.isGameOver = true;
        }
        if (Emission > 0) 
            Emission -= 0.01f;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(Emission);
        playerMat.SetColor("_EmissionColor", finalColor);
        GetComponent<Light>().intensity = Happyness * 10f;
        Rigidbody rb = GetComponent<Rigidbody>();
        
            if (Input.GetKey(KeyCode.A))
                rb.AddForce(ForceStrength * Vector3.left, ForceMode.Acceleration);
            if (Input.GetKey(KeyCode.D))
                rb.AddForce(ForceStrength * Vector3.right, ForceMode.Acceleration);
            if (Input.GetKey(KeyCode.W))
                rb.AddForce(ForceStrength * Vector3.forward, ForceMode.Acceleration);
            if (Input.GetKey(KeyCode.S))
                rb.AddForce(ForceStrength * Vector3.back, ForceMode.Acceleration);
        

        //if (Input.GetKey(KeyCode.A)) 
        //    rb.velocity = ForceStrength * Vector3.left;
        //if (Input.GetKey(KeyCode.D))
        //    rb.velocity = ForceStrength * Vector3.right;
        //if (Input.GetKey(KeyCode.W))
        //    rb.velocity = ForceStrength * Vector3.forward;
        //if (Input.GetKey(KeyCode.S))
        //    rb.velocity = ForceStrength * Vector3.back;
    }

    
}
