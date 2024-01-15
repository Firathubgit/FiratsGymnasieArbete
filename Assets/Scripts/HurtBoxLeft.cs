using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxLeft : MonoBehaviour
{
    //This script is used for refrense purposes
    public PlayerHealth1 playerHealth1;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth1 = GetComponent<PlayerHealth1>();
        rb = transform.GetComponent<Rigidbody>();
    }
}
