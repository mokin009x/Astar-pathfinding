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

    /*complete values(pos)*/
    public Vector3 posStart;
    public Vector3 posCurrent;
    public Vector3 posEnd;
    
    /*converted values(pos)*/
    public int posStartSingleInt;
    public int posCurrentSingleInt;
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


    public void AssigningCurrentPos()
    {
        posCurrent = gridScript.current.transform.position;
        posStart = gridScript.start.transform.position;
        posEnd = gridScript.goal.transform.position;
    }
   
    public int Pythagorean()
    {
        posEnd = gridScript.goal.transform.position;/* get it out of here later*/
        
        pythagorean_A = posCurrent;
        pythagorean_B = posEnd;
        Debug.Log(pythagorean_B + "BBB");
        var pyt1int = pythagorean_A.x + pythagorean_A.y + pythagorean_A.z;
        
        var pyt2int = pythagorean_B.x + pythagorean_B.y +pythagorean_B.z;
        pyt1int = Mathf.Pow(pyt1int,2);
        pyt2int = Mathf.Pow(pyt2int,2);
        Debug.Log(pyt1int + "pyt 1");
        Debug.Log(pyt2int + "pyt 2");
        pythagorean_C = Mathf.RoundToInt(pyt1int + pyt2int);

        /*Debug.Log(pythagorean_A + "A");
        Debug.Log(pythagorean_B + "B");
        Debug.Log(pythagorean_C + "C");*/
        return pythagorean_C;
    }

    public void ConvertPosToSingleInt( Vector3 vector1, Vector3 vector2)
    {
        posCurrentSingleInt = Mathf.RoundToInt(vector1.x + vector1.y + vector1.z);
        posStartSingleInt = Mathf.RoundToInt(vector2.x + vector2.y + vector2.z);

        Debug.Log(posStartSingleInt + "start int");
        Debug.Log(posEndSingleInt + "end int");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  int CalculateValue()
    {
        AssigningCurrentPos();
        ConvertPosToSingleInt(posCurrent, posStart);
        h = Pythagorean();
        g =  posCurrentSingleInt - posStartSingleInt;
        Debug.Log(g + "g");
        Debug.Log(h + "h");
        Debug.Log(f + "f");
        f = g + h;
        return Mathf.RoundToInt(f); 
    }
}
