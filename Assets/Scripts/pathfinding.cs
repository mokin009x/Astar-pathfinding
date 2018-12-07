using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinding : MonoBehaviour
{
    public create_grid gridScript;
    /* A* variables */
    public float f;/*total cost of node*/
    public float g;/*is the distance between the current node and the start node*/
    public float h;/*is the heuristic estimated distance from the current node to the end*/
    /* Pythagorean variables*/
    public float pythagorean_A;
    public float pythagorean_B;
    public float pythagorean_C;

    public List<GameObject> openList;
    public List<GameObject> closedList;
    
    // Start is called before the first frame update
    void Start()
    {
        g = 0f;
        f = 0f;
        h = 0f;
        
        gridScript = GameObject.Find("GameManager").GetComponent<create_grid>();
    }

    public int Pythagorean()
    {
        pythagorean_C = Mathf.Pow(pythagorean_A, 2) + Mathf.Pow(pythagorean_B,2);
        return Mathf.RoundToInt(pythagorean_C);
    }

    public int ConvertPosToSingleInt( Vector3 pos)
    {
        var singlePosInt = Mathf.RoundToInt(pos.x) + Mathf.RoundToInt(pos.y) + Mathf.RoundToInt(pos.z);
        return singlePosInt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CalculateValue()
    {
        int value;
        
        
        
        
     
        return value; 
    }
}
