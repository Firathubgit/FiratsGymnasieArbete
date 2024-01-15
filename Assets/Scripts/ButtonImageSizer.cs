using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageSizer : MonoBehaviour
{

    public float aplhaThreshold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = aplhaThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
