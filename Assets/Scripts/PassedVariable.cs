using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PassedVariable : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI varText;
    PDFMenuScript script;
    // Start is called before the first frame update

    public void Start()
    {
        script = gameObject.GetComponent<PDFMenuScript>();
        varText.text = PDFMenuScript.instance.PDFstring; //Text = the passed variable string

        //varText.text = script.inst; //script.PDFstring
        // Add player GPS
    }
}
