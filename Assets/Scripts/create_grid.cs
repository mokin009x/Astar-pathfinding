using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class create_grid : MonoBehaviour
{
    public GameObject badPathScore;
    public GameObject goodPathScore;
    public GameObject mediumPathScore;
    public GameObject gridMarker;
    public pathfinding pathFindingScript;
    public GameObject currentGridSpace;
    public Vector3 currentGridSpacePos;

    public GameObject customMarker;
    public GameObject world0Space;
    public List<List<GameObject>> worldGrid = new List<List<GameObject>>();
    public int worldSize;


    // Start is called before the first frame update
    private void Start()
    {
        pathFindingScript = GameObject.Find("GameManager").GetComponent<pathfinding>();
        world0Space = GameObject.FindGameObjectWithTag("WorldZeroSpace");
        currentGridSpace = world0Space;

        MakeGrid();
        pathFindingScript.pythagorean_A = pathFindingScript.ConvertPosToSingleInt(world0Space.transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Instantiate(customMarker, worldGrid[Random.Range(0,19)][Random.Range(0,19)].transform.position, Quaternion.identity);
    }

    public void MakeGrid()
    {
        for (var i = 0; i < worldSize; i++)
        {
            var sublist = new List<GameObject>();

            for (var j = 0; j < worldSize; j++)
            {
                sublist.Add(currentGridSpace);
                currentGridSpacePos = currentGridSpace.transform.position + new Vector3(1, 0, 0);/*skipped 0,0,0 reason why its before placeMarker*/
/*
                PlaceMarkers();
*/
            }
            
            
            

            worldGrid.Add(sublist);

            currentGridSpacePos = currentGridSpacePos + new Vector3(-worldSize, 0, 1);

            Debug.Log("hoi");
        }
    }

    public void PlaceMarkers()
    {
        Instantiate(gridMarker, currentGridSpace, Quaternion.identity);
    }

    
}