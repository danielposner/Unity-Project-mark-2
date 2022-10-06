using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;

public class SpawnPOI : MonoBehaviour
{
    // This is an adapted version of the Mapbox Spawn code.
    // It's been separated from the other spawn objects (see SPAWN POI)
    // It also used imported variables rather than manual inputs 
    // We didn't destroy the serialized fields because the user can't see them, but functionally they do nothing here (didn't want to mess with functional code)


    public static PDFMenuScript instance;
    public string gpsImport;

    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    [Geocode]
    string[] _locationStrings;
    Vector2d[] _locations;

    // Player Location
    string[] _locationStrings2;
    Vector2d[] _locations2;
    List<GameObject> _spawnedObjects2;


    [SerializeField]
    float _spawnScale = 100f;

    [SerializeField]
    GameObject _markerPrefab;

    List<GameObject> _spawnedObjects;

    void Start()
    {
        // Import the GPS String and input it
        gpsImport = PDFMenuScript.instance.gpsImport;
        string[] _locationStrings = { gpsImport };
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
            // Create an instance on the map of a location
        }










    }

    private void Update()
    {


        int count = _spawnedObjects.Count;
        for (int i = 0; i < count; i++)
        {

            // Import New String Code Lat Long form
            // Set up Conversions
            var spawnedObject = _spawnedObjects[i];
            var location = _locations[i];
            spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
            spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            // Keep an updated version of the location on the map. Not strictly necessary but useful to keep in the event
            // we decied to add additional functionality. The update function could alternatively be disabled
        }
    }
}
