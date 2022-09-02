using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelector : MonoBehaviour
    



{
    public string PDFstring;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("1 down ois loadvalue");
        Debug.Log(PDFMenuScript.instance.PDFstring);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
