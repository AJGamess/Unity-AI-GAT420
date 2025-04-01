using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Waypoint[] waypoints;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<NavAgents>(out NavAgents agent))
        {
            //agent.waypoint = waypoints[Random.Range(0, waypoints.Length)];
        }
    }
}
