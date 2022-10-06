using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{

    /// <summary>
    /// This tracks the GPS of the user.
    /// The code was originally created by Code-3 Interactive at https://www.youtube.com/watch?v=JWccDbm69Cg&ab_channel=Code-3Interactive
    /// Although slightly adapted, credit belongs to the Code-3 Interactive team.
    /// </summary>

    public Text GPSStatus;
    public Text latitudeValue;
    public Text longitudeValue;
    public Text altitudeValue;
    public Text horizontalAccuracyValue;
    public Text timestampValue; // These are all optional - used for testing (returns text values for outputs). Can erase later
    public Text magicStringValue;
    public string msvString;

    // Start is called before the first frame update
    void Start()
    {
        magicStringValue.text = "4,4 "; // placeholder - used for debugging purposes
        msvString = "5,5";
        StartCoroutine(GPSLoc()); // keep checking the GPS
        
    }

    IEnumerator GPSLoc()
    {
        // Check if locations ervice enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location

        Input.location.Start();

        // Wait until service initialize

        int maxWait = 20;
        while (Input.location.status== LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            GPSStatus.text = "Time out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            // Access granted
            GPSStatus.text = "Running";
            InvokeRepeating("UpdateGPSData", 0.5f, 1f); // Called after 0.5 seconds, repeated every second
        }

    } // End of GPSLoc

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            GPSStatus.text = "Running";
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
            timestampValue.text = Input.location.lastData.timestamp.ToString();
            magicStringValue.text = Input.location.lastData.latitude.ToString() + ", " + Input.location.lastData.longitude.ToString();


            // Access granted to GPS
        }
        else
        {
            // Service is stopped
            GPSStatus.text = "Stop";
            print(magicStringValue.text);

        }
    } // End of Update GPS Data

    // Update is called once per frame
    void Update()
    {
        
    }
}