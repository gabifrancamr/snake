using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public Transform wallPrefab;

    public float cellSize = 0.3f;

    List<Transform> walls = new List<Transform>();

    public void CreateWalls()
    {
        int cellX = -24;
        int cellY = 11;
        int height = 25;

        float horizontal = cellX * cellSize;
        float vertical = cellY * cellSize;

        for (int i = 0; i < (int)Mathf.Abs((horizontal * 2) / cellSize) + 1; ++i)
        {
            Vector2 top = new Vector2(horizontal + cellSize * i, vertical);

            Vector2 bottom = new Vector2(
                horizontal + cellSize * i,
                vertical - height * cellSize
            );

            walls.Add(
                Instantiate(wallPrefab, top, Quaternion.identity).transform
            );

            walls.Add(
                Instantiate(wallPrefab, bottom, Quaternion.identity).transform
            );
        }

        for (int i = 0; i < height; ++i)
        {
            Vector2 right = new Vector2(
                horizontal,
                vertical - cellSize * i
            );

            Vector2 left = new Vector2(
                -horizontal,
                vertical - cellSize * i
            );

            walls.Add(
                Instantiate(wallPrefab, right, Quaternion.identity).transform
            );

            walls.Add(
                Instantiate(wallPrefab, left, Quaternion.identity).transform
            );
        }
    }

    public List<Transform> GetWalls()
    {
        return walls;
    }
}