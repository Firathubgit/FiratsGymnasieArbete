using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStart : MonoBehaviour
{
    LookAtEachOther lookAtEachOther;
    // Start is called before the first frame update
    void Start()
    {
        lookAtEachOther = FindAnyObjectByType<LookAtEachOther>();

        Invoke("activateChildObject", 3f);
 
    }
    public void activateChildObject()
    {
        

        gameObject.transform.GetChild(0).gameObject.SetActive(true);


    }
}
