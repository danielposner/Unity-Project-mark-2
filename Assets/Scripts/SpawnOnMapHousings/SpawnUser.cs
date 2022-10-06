using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This is an adapted version of the Mapbox Spawn code.
// It's been separated from the other spawn objects (see SPAWN POI)
// It also used imported variables rather than manual inputs 
// We didn't destroy the serialized fields because the user can't see them, but functionally they do nothing here (didn't want to mess with functional code)

public class SpawnUser : MonoBehaviour
{


    public GameObject otherGameObject;
    public static PDFMenuScript instance;
    public string gpsImport;
    public GPSLocation gpsLocation;
    public Text magicStringValue;
    public string msvString;


    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    [Geocode]
    string[] _locationStrings;
    Vector2d[] _locations;


    [SerializeField]
    float _spawnScale = 100f;

    [SerializeField]
    GameObject _markerPrefab;

    List<GameObject> _spawnedObjects;

    void Start()
    {
        /// See SpawnPOI, same logic
        gpsImport = PDFMenuScript.instance.gpsImport;
        string[] _locationStrings = {"10, 10" }; // Check for testing, set to 10,10 if issues. Defaulting it avoids crashes when no input or an illegal input is made
        _locations = new Vector2d[_locationStrings.Length];
        _spawnedObjects = new List<GameObject>();
        for (int i = 0; i < _locationStrings.Length; i++)
        {
            var locationString = _locationStrings[i];
            _locations[i] = Conversions.StringToLatLon(locationString);
            var instance = Instantiate(_markerPrefab);
            instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
            instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            _spawnedObjects.Add(instance);
        }










    }



    private void Update()
    {
// See SpawnPOI Same Logic except the update is used
        int count = _spawnedObjects.Count;

        gpsLocation = GetComponent<GPSLocation>(); 

        for (int i = 0; i < count; i++)
        {
            // Keep updating the players location

            string[] _locationStrings = {gpsLocation.magicStringValue.text }; 
            var locationString = _locationStrings[0];
            _locations[i] = Conversions.StringToLatLon(locationString);


            var spawnedObject = _spawnedObjects[i];
            var location = _locations[i];
            spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
            spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
        }
    }
}
 