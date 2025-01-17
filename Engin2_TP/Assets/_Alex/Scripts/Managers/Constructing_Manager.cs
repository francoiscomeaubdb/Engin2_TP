using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructing_Manager : MonoBehaviour
{
    public List<Camp_Alex> Camps { get; private set; } = new List<Camp_Alex>();
    private const float MIN_OBJECTS_DISTANCE = 2.0f;

    public static Constructing_Manager _Instance
    {
        get;
        private set;
    }
    private void Awake()
    {
        if (_Instance == null || _Instance == this)
        {
            _Instance = this;
            return;
        }
        Destroy(this);
    }

    public bool CanPlaceObject(Vector2 coordinates)
    {
        foreach (var collectible in Collecting_Manager._Instance.KnownCollectibles)
        {
            var collectibleLocation = new Vector2(collectible.transform.position.x, collectible.transform.position.y);
            if (Vector2.Distance(coordinates, collectibleLocation) < MIN_OBJECTS_DISTANCE)
            {
                return false;
            }
        }

        foreach (var camp in Camps)
        {
            var collectibleLocation = new Vector2(camp.transform.position.x, camp.transform.position.y);
            if (Vector2.Distance(coordinates, collectibleLocation) < MIN_OBJECTS_DISTANCE)
            {
                return false;
            }
        }

        return true;
    }
}
