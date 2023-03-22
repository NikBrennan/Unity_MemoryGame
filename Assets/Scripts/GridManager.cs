using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int width, height;
    [SerializeField] public Card cardPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var spawnCard = Instantiate(cardPrefab, new Vector3(i, j), Quaternion.identity);
                spawnCard.name = $"Card {i} {j}";
            }
        }
    }
}
