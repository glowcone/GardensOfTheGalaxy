using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FishingGameController : MonoBehaviour
{
    public int numRows;
    public int numCols;

    public GameObject[] fishPrefabs;

    public bool[,] isFish;
    public GameObject[,] grid;

    public List<Fish> allFish;
    public Fish chosenFish = null;

    void Start()
    {
        SpawnGrid();
    }
    private void SpawnGrid()
    {
        isFish = new bool[numRows,numCols];

        for (int r = 0; r < numRows; r++)
        {
            int randCol = Random.Range(0, numCols);
            for (int c = 0; c < numCols; c++)
            {
                if (c == randCol)
                {
                    isFish[r, c] = true;
                    GameObject go = Instantiate(fishPrefabs[Random.Range(0, fishPrefabs.Length)]);
                    Fish fish = go.GetComponent<Fish>();
                    fish.rowIndex = r;
                    allFish.Add(fish);
                }
                else
                {
                    isFish[r, c] = false;
                }
            }
        }
    }
    
    private void MoveFish()
    {
        Assert.IsTrue(chosenFish != null);

        // move all fish except player's fish
        foreach(Fish fish in allFish)
        {
            // if not the same fish fish
            if (fish.rowIndex != chosenFish.rowIndex)
            {
                // find random col to move to
                int randCol = Random.Range(0, numCols);
                fish.MoveTo(Vector3.zero, MoveFishComplete);
            }
        }
    }
    private void MoveFishComplete()
    {
        print("Move Fish Complete");
    
    }
    public Fish RandomFishSelection()
    {
        return allFish[Random.Range(0, allFish.Count)];
    }
    public void ChooseFish(Fish fish)
    {
        chosenFish = fish;
    }
}
