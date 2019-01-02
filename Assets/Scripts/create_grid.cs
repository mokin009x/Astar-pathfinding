using System.Collections.Generic;
using UnityEngine;

public class create_grid : MonoBehaviour
{
    public GameObject badPathScore;
    public GameObject closedListScore;
    public GameObject goal;
    public GameObject current;
    public GameObject start;
    public GameObject gridSpace;
    public Vector3 currentGridSpacePosDigital;
    
    public GameObject goodPathScore;
    public GameObject gridMarker;
    public GameObject mediumPathScore;
    public pathfinding pathFindingScript;
    public GameObject world0Space;
    public List<List<GameObject>> worldGrid = new List<List<GameObject>>();
    public int worldSize;


    // Start is called before the first frame update
    private void Start()
    {
        pathFindingScript = GameObject.Find("GameManager").GetComponent<pathfinding>();
        world0Space = GameObject.FindGameObjectWithTag("WorldZeroSpace");
        MakeGrid();
        
        start = worldGrid[0][0];
        
        goal = worldGrid[19][19];
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            /*for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    Debug.Log(worldGrid[i][j].transform.position + "worldGrid");    
                }
            }       */
            StartPathFinding();
        }
    }

    public void MakeGrid()
    {
        currentGridSpacePosDigital = world0Space.transform.position;
        for (var i = 0; i < worldSize; i++)
        {
            var sublist = new List<GameObject>();

            for (var j = 0; j < worldSize; j++)
            {
/*
                Debug.Log(currentGridSpacePos + "currentGridSpacePos");
*/
                currentGridSpacePosDigital = currentGridSpacePosDigital + new Vector3(1, 0, 0); /*skipped 0,0,0 reason why its before placeMarker*/
                GameObject placedObj = PlaceMarkers(currentGridSpacePosDigital, gridSpace);
                sublist.Add(placedObj);
                
            }


            worldGrid.Add(sublist);

            currentGridSpacePosDigital = currentGridSpacePosDigital + new Vector3(-worldSize, 0, 1);

            Debug.Log("hoi");
        }
    }

    public void StartPathFinding()
    {
        for (int i = 0; i < worldSize; i++)
        {
            for (int j = 0; j < worldSize; j++)
            {
                current = worldGrid[i][j];
                var value = pathFindingScript.CalculateValue();
                Debug.Log(value + "value");    
            }
        }
    }


    public GameObject PlaceMarkers(Vector3 markerPos, GameObject gridspaceobj)
    {
/*
        Debug.Log(markerPos +"markerpos");
*/

        GameObject spawnedObj =Instantiate(gridspaceobj, markerPos, Quaternion.identity);
        
            
        

        return spawnedObj;
    }
}