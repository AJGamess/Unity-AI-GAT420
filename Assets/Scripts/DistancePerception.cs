using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePerception : Perception
{
    public override GameObject[] GetGameObjects() 
    {
        List<GameObject> result = new List<GameObject>();

        var colliders = Physics.OverlapSphere(transform.position, maxDistance);
        // get all colliders inside sphere
        foreach ( var collider in colliders )
        {
            // do not include ourselves
            if (collider.gameObject == gameObject) continue;
            //check for matching tag
            if (tagName == "" || collider.tag == tagName)
            {
            Vector3 direction = collider.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            if (angle <= maxAngle)
                {
                    result.Add(collider.gameObject);
                }
            }
        }

        return result.ToArray();
    }
}
