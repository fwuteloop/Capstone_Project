using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmovement : MonoBehaviour
{
    public Vector3 closestNodeDistance;
    public GameObject[] nodes;
    int currentNode;
    // Start is called before the first frame update
    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("node");
       
    }

    // Update is called once per frame
    void Update()
    {
        FindNodeDistances();
    }

    void FindNodeDistances()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            Vector3 nodeDistance = transform.position - nodes[i].transform.position;
            if(nodeDistance.x < nodes[i + 1].transform.position.x && nodeDistance.y < nodes[i + 1].transform.position.y)
            {
                if (i < nodes.Length)
                {
                    closestNodeDistance = nodeDistance;
                    Debug.Log("closest node is " + nodes[i].name);
                }
                else
                    return;
            }
        }
    }
}
