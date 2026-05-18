using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Transform foodPrefab;

    public float cellSize = 0.3f;

    public int initialFoods = 1;

    List<Transform> foods = new List<Transform>();

    public void SpawnInitialFood()
    {
        for (int i = 0; i < initialFoods; i++)
        {
            SpawnFood();
        }
    }

    public void SpawnFood()
    {
        float x = Random.Range(-23, 23) * cellSize;
        float y = Random.Range(-13, 11) * cellSize;

        Vector2 randomPosition = new Vector2(x, y);

        foods.Add(
            Instantiate(foodPrefab, randomPosition, Quaternion.identity).transform
        );
    }

    public List<Transform> GetFoods()
    {
        return foods;
    }

    public void RemoveFood(int index)
    {
        Destroy(foods[index].gameObject);
        foods.RemoveAt(index);
    }

    public void ClearFoods()
    {
        // Deleta os objetos de trás para frente para evitar erros de índice
        for (int i = foods.Count - 1; i >= 0; i--)
        {
            if (foods[i] != null)
            {
                Destroy(foods[i].gameObject);
            }
        }
        foods.Clear();
    }
}
