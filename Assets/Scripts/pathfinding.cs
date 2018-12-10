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
    public Vector3 pythagorean_A;
    public Vector3 pythagorean_B;
    public int pythagorean_C;
    public int posStartSingleInt;
    public int posEndSingleInt;

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
        ConvertPosToSingleInt(pythagorean_A, pythagorean_B);
        pythagorean_C = Mathf.RoundToInt(Mathf.Pow(posStartSingleInt,2) + Mathf.RoundToInt(Mathf.Pow(posEndSingleInt,2)));
        
        
        Debug.Log(pythagorean_A + "A");
        Debug.Log(pythagorean_B + "B");
        return Mathf.RoundToInt(Mathf.Pow(pythagorean_C,2));
    }

    public void ConvertPosToSingleInt( Vector3 posStart, Vector3 posEnd)
    {
        posStartSingleInt = Mathf.RoundToInt(posStart.x) + Mathf.RoundToInt(posStart.y) + Mathf.RoundToInt(posStart.z);
        posEndSingleInt = Mathf.RoundToInt(posEnd.x) + Mathf.RoundToInt(posEnd.y) + Mathf.RoundToInt(posEnd.z);
        Mathf.RoundToInt(posEndSingleInt);
        Mathf.RoundToInt(posEndSingleInt);

        Debug.Log(posStartSingleInt);
        Debug.Log(posEndSingleInt);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  int CalculateValue()
    {
        Debug.Log(pythagorean_C + "C");
        h = Pythagorean();
        g =  posStartSingleInt - posEndSingleInt;
        int value;
        f = g + h;
        return Mathf.RoundToInt(f); 
    }
}
