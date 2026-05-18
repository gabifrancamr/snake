using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Transform foodPrefab;
    public int initialFoods = 1;
    private List<GameObject> foods = new List<GameObject>();

    public void SpawnInitialFood(float cellSize)
    {
        for (int i = 0; i < initialFoods; i++)
        {
            SpawnFood(cellSize);
        }
    }

    public void SpawnFood(float cellSize)
    {
        float x = Random.Range(-23, 23) * cellSize;
        float y = Random.Range(-13, 11) * cellSize;

        GameObject newFood = Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity).gameObject;
        foods.Add(newFood);
    }

    public void RemoveFood(GameObject foodObject)
    {
        if (foods.Contains(foodObject))
        {
            foods.Remove(foodObject);
            Destroy(foodObject);
        }
    }

    public void ClearFoods()
    {
        for (int i = foods.Count - 1; i >= 0; i--)
        {
            if (foods[i] != null) Destroy(foods[i]);
        }
        foods.Clear();
    }
}