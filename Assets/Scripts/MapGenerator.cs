using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] backYardTiles;
    private Transform boardHolder;                 
    private int xMin = -10;
    private int xMax = 10;
    
    private int yMin = -10;
    private int yMax = 2;
    private List <Vector3> gridPositions = new List <Vector3> ();    


    void InitialiseList ()
    {
        gridPositions.Clear ();

        for(int x = xMin; x < xMax; x++)
        {
            for(int y = yMin; y < yMax; y++)
            {
                gridPositions.Add (new Vector3(x, y, 0f));
            }
        }
    }
    void Start()
    {
        // InitialiseList();
        // boardHolder = new GameObject("Board").transform;
        // //boardHolder.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,1f));
        // for (int i=0; i<gridPositions.Count;i++)
        // {
        //         int rand = Random.Range(0,backYardTiles.Length);
        //         GameObject instance = Instantiate(backYardTiles[rand],gridPositions[i], Quaternion.identity);
        //         instance.transform.SetParent(boardHolder);
        // }
        GenerateMap();
    }
    public void GenerateMap()
    {
        InitialiseList();
        boardHolder = new GameObject("Board").transform;
        //boardHolder.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,1f));
        for (int i=0; i<gridPositions.Count;i++)
        {
                int rand = Random.Range(0,backYardTiles.Length);
                GameObject instance = Instantiate(backYardTiles[rand],gridPositions[i], Quaternion.identity);
                instance.transform.SetParent(boardHolder);
        }
    }
}
