using System.Collections.Generic;
using UnityEngine;

public class create_grid : MonoBehaviour
{
    public GameObject badPathScore;
    public GameObject closedListScore;
    public GameObject goal;
    public GameObject start;
    public GameObject currentGridSpace;
    public GameObject gridMaker;
    public Vector3 currentGridSpacePos;

    public GameObject customMarker;
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
        gridMaker = world0Space;
        MakeGrid();
        
        start = worldGrid[1][1];
        goal = worldGrid[19][19];

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(customMarker, worldGrid[Random.Range(0, 19)][Random.Range(0, 19)].transform.position, Quaternion.identity);
    }

    public void MakeGrid()
    {
        currentGridSpacePos = gridMaker.transform.position;
        for (var i = 0; i < worldSize; i++)
        {
            var sublist = new List<GameObject>();

            for (var j = 0; j < worldSize; j++)
            {
                Debug.Log(currentGridSpacePos);
                sublist.Add(gridMaker);
                currentGridSpacePos = currentGridSpacePos + new Vector3(1, 0, 0); /*skipped 0,0,0 reason why its before placeMarker*/
            }


            worldGrid.Add(sublist);

            currentGridSpacePos = currentGridSpacePos + new Vector3(-worldSize, 0, 1);

            Debug.Log("hoi");
        }

        for (int i = 0; i < worldSize; i++)
        {
            for (int j = 0; j < worldSize; j++)
            {
                
                PlaceMarkers(worldGrid[i][j].transform.position);
            }
        
        }

    }

 

    public void PlaceMarkers(Vector3 markerPos)
    {
        var value = pathFindingScript.CalculateValue();
        Debug.Log(markerPos +"markerpos");

        if (value <= 200)
        {
            Debug.Log(value);
            gridMarker = mediumPathScore;
            Instantiate(gridMarker, markerPos, Quaternion.identity);
        }
    }
}