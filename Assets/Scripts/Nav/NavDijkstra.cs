using NUnit.Framework;
using Priority_Queue;
using System.Collections.Generic;
using UnityEngine;

public class NavDijkstra
{
    public static bool Generate(NavNode startNode, NavNode endNode, ref List<NavNode> path)
    {
        var nodes = new SimplePriorityQueue<NavNode>();

        startNode.Cost = 0;
        nodes.Enqueue(startNode, startNode.Cost);

        bool found = false;
        while (nodes.Count > 0 && !found)
        {
            var currentNode = nodes.Dequeue();
            if (currentNode == endNode)
            {
                found = true;
                break;
            }

            foreach(var neighbor in currentNode.neighbors)
            {
                float cost = currentNode.Cost + (currentNode.transform.position - neighbor.transform.position).magnitude;
                if (cost < neighbor.Cost)
                {
                    neighbor.Cost = cost;
                    neighbor.Previous = currentNode;

                    nodes.Enqueue(neighbor, cost);
                }
            }
        }
        if (found)
        {
            NavNode.CreatePath(endNode, ref path);
        }
        return true;
    }
}
