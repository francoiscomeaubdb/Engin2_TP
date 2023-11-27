using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpiralMatrix : MonoBehaviour
{

    [SerializeField] int mapWidth;
    [SerializeField] int mapHeight;
    [SerializeField] int numberWorkers;
    void Start()
    {
        int[,] map = new int[mapWidth, mapHeight];

        // Example usage:
        List<Vector2Int>[] explorerLocations = new List<Vector2Int>[5];

        for (int i = 0; i < numberWorkers; i++)
        {
            explorerLocations[i] = ExploreMap(map, $"Explorer {i + 1}");
        }

       
    }

    List<Vector2Int> ExploreMap(int[,] map, string explorerName)
    {
        int x = mapWidth / 2;  
        int y = mapHeight / 2; 

        int deltax = 0;
        int deltay = -1;
        int steps = 1;
        int stepCount = 0;

        List<Vector2Int> explorerLocations = new List<Vector2Int>();

        for (int i = 0; i < mapWidth * mapHeight; i++)
        {

            explorerLocations.Add(new Vector2Int(x, y));

            if (++stepCount == steps)
            {
                stepCount = 0;
                if (i % 2 == 0)
                    steps++;

                int temp = deltax;
                deltax = -deltay;
                deltay = temp;
            }

            x += deltax;
            y += deltay;

          
        }

        return explorerLocations;
    }
}
