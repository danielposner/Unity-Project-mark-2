using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PDFMenuScript : MonoBehaviour
{

    public static PDFMenuScript instance;
    public string PDFstring;
    

    // Error Handling Rules
    // If more than one item is selected, pick the FIRST one that isn't none

    // Start is called before the first frame update

    string triggeredstring;
    [SerializeField] private TMP_Dropdown dropdown1;
    [SerializeField] private TMP_Dropdown dropdown2;
    [SerializeField] private TMP_Dropdown dropdown3;


    //[SerializeField] private string dropdown1;
    //[SerializeField] private string dropdown2;
    //[SerializeField] private string dropdown3;


    //string dropdown2 = "test2unlinked";
    //string dropdown3 = "test3unlinked";

    void TriggerOnClick()
    {
        /// Finds the first valid output for triggeredstring


        if (dropdown1.options[dropdown1.value].text != "N/A")
        {
            triggeredstring = dropdown1.options[dropdown1.value].text;
        }
        else if (dropdown2.options[dropdown2.value].text != "N/A")
        {
            triggeredstring = dropdown2.options[dropdown2.value].text;
        }
        else if (dropdown3.options[dropdown3.value].text != "N/A")
        {
            triggeredstring = dropdown3.options[dropdown3.value].text;
        }
        else
        {
            triggeredstring = "N/A";
        }

        //string output = "Wibble";
        //Debug.Log(output);
    }

    void PDFButtonEvent(string triggerstring)
    {
        if (triggerstring == "test1unlinked")
        {
            Debug.Log("Linked to triggerstring");
        }
    }



    //void resetFrames()
    //    // Resets the dropdown lists ## DO LATER
    //{

    //}

    // Update is called once per frame

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnPress()
    {
        Debug.Log(dropdown1.options[dropdown1.value].text + "Dropdown1");
        Debug.Log(dropdown2.options[dropdown2.value].text + "Dropdown2");
        Debug.Log(dropdown3.options[dropdown3.value].text + "Dropdown3");
        PDFstring = triggeredstring;

        TriggerOnClick();
        PDFstring = triggeredstring;
        PDFButtonEvent(triggeredstring);
        PDFstring = triggeredstring;

    }
}


