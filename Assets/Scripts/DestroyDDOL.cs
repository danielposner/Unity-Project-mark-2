using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyDDOL : MonoBehaviour
{
    PDFMenuScript script;
    private void Start()
    {
        // Not functioning properly - needs to reference instance - static is in way. Do not want to break code
        // This was an attempt to find and destroy the DDOL objects. What we need to do (to optimize) is store a array to contain them on creation
        // then destroy the contents of the array. 
        script = gameObject.GetComponent<PDFMenuScript>();
        Destroy(GameObject.Find("StorageHousing"));
        Destroy(GameObject.Find("DontDestroyOnLoad"));
    }
}
