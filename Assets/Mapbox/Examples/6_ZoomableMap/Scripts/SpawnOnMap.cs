namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using System.Collections.Generic;

	public class SpawnOnMap : MonoBehaviour
	{
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
            // New Bit

            string[] _locationStrings2 = { "-27.499582, 153.016217" };
			_locations2 = new Vector2d[_locationStrings2.Length];
            _spawnedObjects2 = new List<GameObject>();

			for (int i = 0; i < _locationStrings2.Length; i++)
			{
				var locationString2 = _locationStrings2[i];
				_locations[i] = Conversions.StringToLatLon(locationString2);
				var instance = Instantiate(_markerPrefab);
				instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
				instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
				_spawnedObjects2.Add(instance);
			}










			}

        private void Update()
		{
            //playerLocation = new Vector2d(-27.499582, 153.016217);


            int count = _spawnedObjects.Count;
			for (int i = 0; i < count; i++)
			{

				// Import New String Code Lat Long form
				// Set up Conversions
				var spawnedObject = _spawnedObjects[i];
				var location = _locations[i];
				spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
				spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
			}
		}
	}
}