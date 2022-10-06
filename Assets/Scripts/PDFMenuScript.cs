using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PDFMenuScript : MonoBehaviour
{
    /// <summary>
    ///  Loads in the variables from the landing page for the other scripts
    ///  Checks the dropdowns sequentially for the first legal input. Then extracts the relevant GPS and String and Audio data and
    ///  sends it to a new scene.
    /// </summary>

    public static PDFMenuScript instance;
    public string PDFstring;
    public string gpsImport;
    public string audioString;

    // Error Handling Rules
    // If more than one item is selected, pick the FIRST one that isn't none

    // Start is called before the first frame update

    public string triggeredstring = "N/A"; // was just string before
    [SerializeField] private TMP_Dropdown dropdown1;
    [SerializeField] private TMP_Dropdown dropdown2;
    [SerializeField] private TMP_Dropdown dropdown3;
    [SerializeField] private TMP_Dropdown dropdown4;


    //[SerializeField] private string dropdown1;
    //[SerializeField] private string dropdown2;
    //[SerializeField] private string dropdown3;


    //string dropdown2 = "test2unlinked";
    //string dropdown3 = "test3unlinked";

    void TriggerOnClick()
    {
        /// Finds the first valid output for triggeredstring. This could also be done by creating an array of the four dropdowns and cycling through that. As there are only
        /// 4 lists, I felt it was easier (if perhaps a little messy) just to manually input all 4.


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

        else if (dropdown4.options[dropdown4.value].text != "N/A")
        {
            triggeredstring = dropdown4.options[dropdown4.value].text;
        }

        else
        {
            triggeredstring = "N/A";
        }

        /// Load in a variable. if none found set to N/A (takes user to dummy page)

    }





    //void resetFrames()
    //    // Resets the dropdown lists ## DO LATER
    //{

    //}

    // Update is called once per frame

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject); //This keeps the variables from being destroyed when we load another scene. There are other methods, however given the low-memory of the
        // first page + my limited unity knowledge at the time, we used this. 
    }
    
    public void OnPress()
    {
        /// OnPress is linked to the buttoms at the bottom of the first page. It serves to store all the variables before we swap scenes
        PDFstring = triggeredstring;
        TriggerOnClick();
        PDFstring = triggeredstring;
        gpsImport = GpsStrings(triggeredstring); // set to a placeholder if fails
        audioString = AudioSourceCreation(PDFstring);
        //createAudio = AudioSourceCreation(triggeredstring);

    }


    // Yes I know a dictionary or sorted list would be more effective than the below. Since they're affixed to individual values however, this doesn't make a big difference
    // If gps load has issues maybe import it from page 1 in the background


    // With the benefit of hindsight having done a separate unity course - these should have been set to SerializedFields, or better yet, a list of serialized fields
    // This would allow on the spot editing requiring less code. Live and learn.

    public string GpsStrings(string location)
    {
        if (location == "Food Court 1")
        {
            return "-27.498969577640548, 153.01208514719522";
        }
        
        else if (location == "Food Court 2")
        {
            return "-27.497500483190674, 153.01549780000755";
        }

        else if (location == "Darwin's Cafe")
        {
            return "-27.496735702251726, 153.0113627292482";
        }

        else if (location == "Law Library")
        {
            return "-27.49709754130185, 153.01252832749697";
        }

        else if (location == "Central Library")
        {
            return "-27.496122128120863, 153.0136299367523";
        }

        else if (location == "BioSciences Library")
        {
            return "-27.496823682879636, 153.01132255633308";
        }

        else if (location == "Engineering Library")
        {
            return "-27.50000144543322, 153.0133479618558";
        }

        else if (location == "Healthcare Centre")
        {
            return "-27.496434269577698, 153.01559054671336";
        }

        else if (location == "Student Services")
        {
            return "-27.49887965099978, 153.01378151719453";
        }

        else if (location == "Employment Centre")
        {
            return "-27.49887665991271, 153.01378218516948";
        }

        else if (location == "Student Union")
        {
            return "-27.49644266386453, 153.01594175891617";
        }

        else if (location == "UQ Ventures")
        {
            return "-27.49766548959945, 153.01475090000375";
        }

        else if (location == "EAIT Faculty Building")
        {
            return "-27.499748618701336, 153.01345897838834";
        }

        else if (location == "BEL Faculty Building")
        {
            return "-27.49567526970519, 153.01393268516918";
        }

        else if (location == "HBS Faculty Building")
        {
            return "-27.49598163117237, 153.0147542464698";
        }

        else
        {
            return "";
        }

    }

    public string AudioSourceCreation (string selectionString)
    {
        // Create a string to load in the audio.
        string audioString = selectionString + "AUDIO";
        print("AudioString"+audioString);
        return audioString;
    }
}


