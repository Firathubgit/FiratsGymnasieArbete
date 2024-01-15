using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxRight : MonoBehaviour
{
    //This script is used for refrense purposes
    public PlayerHealth2 playerHealth2;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth2 = GetComponent<PlayerHealth2>();
        rb = transform.GetComponent<Rigidbody>();
    }
}
