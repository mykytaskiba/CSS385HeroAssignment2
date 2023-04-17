using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    static WaypointManager instance;

    [SerializeField]
    private Waypoint[] waypoints;

    public bool waypointsShown = true;
    public bool randomWaypoints = false;

    public static WaypointManager Get()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public Vector3 GetNextTarget(ref int lastTarget)
    {
        if (randomWaypoints)
        {
            randomTarget(ref lastTarget);
        } else
        {
            incrementTarget(ref lastTarget);
        }
        return waypoints[lastTarget].transform.position;
    }

    void incrementTarget(ref int incremented)
    {
        incremented++;
        if (incremented >= waypoints.Length)
        {
            incremented = 0;
        }
    }

    void randomTarget(ref int index)
    {
        index = Random.Range(0, waypoints.Length);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void switchRandomMode()
    {
        randomWaypoints = !randomWaypoints;

        VisualUI.Get().updateWaypointsText();
    }
    void switchWaypointsShow()
    {
        waypointsShown = !waypointsShown;

        foreach (Waypoint waypoint in waypoints)
        {
            waypoint.gameObject.SetActive(waypointsShown);
        }
        VisualUI.Get().updateWaypointsText();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            switchWaypointsShow();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            switchRandomMode();
        }
    }
}
