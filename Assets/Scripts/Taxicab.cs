using System;
using System.Collections.Generic;
using UnityEngine;

public class Taxicab : MonoBehaviour
{
    [SerializeField]
    private string[] _testCase;
    private string[,] _grid;
    private GridPosition[] _targetPOSs;
    private GridPosition _playerPOS;
    private int columnCount;
    private int rowCount;

    private void Start()
    {
        MakeGrid();
        GetTargets();
        GetPlayer();
        CalculateClosest();
    }

    void MakeGrid() 
    {
        ///Make a Super Grid
        /// A SuperGrid consists of a Grid of grids
        /// This allows for easy world wrap checks
        columnCount = _testCase[0].Length;
        rowCount = _testCase.Length;
        _grid = new string[rowCount * 3, columnCount * 3];
        int TotalTargets = 0;

        for (int x = 0; x < rowCount; x++) 
        {
            string feed = _testCase[x];

            for (int y = 0; y < columnCount; y++)
            {
                _grid[x, y] = feed[y].ToString();
                _grid[x, y + columnCount] = feed[y].ToString();
                _grid[x, y + columnCount * 2] = feed[y].ToString();
                _grid[x + rowCount, y] = feed[y].ToString();
                _grid[x + rowCount, y + columnCount] = feed[y].ToString();
                _grid[x + rowCount, y + columnCount * 2] = feed[y].ToString();
                _grid[x + rowCount * 2, y] = feed[y].ToString();
                _grid[x + rowCount * 2, y + columnCount] = feed[y].ToString();
                _grid[x + rowCount * 2, y + columnCount * 2] = feed[y].ToString();
                if (feed[y].ToString() == "2")
                    TotalTargets += 9;
            }
        }

        _targetPOSs = new GridPosition[TotalTargets];

    }

    void GetTargets() //Find All Targets
    {
        int totalTargets = 0;
        for (int x = 0; x < _grid.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                if (_grid[x, y] == "2")
                {
                    _targetPOSs[totalTargets] = new GridPosition(x, y);
                    totalTargets++;
                }
            }
        }
        Debug.Log($"Total nuber of Targets = {_targetPOSs.Length / 9}");
    }

    void GetPlayer() //Find Player in Center (master) grid
    {
        for (int x = rowCount; x < rowCount * 2; x++)
        {
            for (int y = columnCount; y < columnCount * 2; y++)
            {
                if (_grid[x, y] == "1")
                {
                    _playerPOS = new GridPosition(x, y);
                }
            }
        }
    }

    void CalculateClosest() //Calculate Manhattan Distance.
    {
        int BestSteps = 1000;

        int PlayerX = _playerPOS.GetXPosition();
        int PlayerY = _playerPOS.GetYPosition();

        for (int i = 0; i < _targetPOSs.Length-1; i++)
        {
            if (_targetPOSs[i] != null)
            {                
                int TargetX = _targetPOSs[i].GetXPosition();
                int TargetY = _targetPOSs[i].GetYPosition();
                
                int horizontal = Mathf.Abs(TargetX - PlayerX);
                int vertical = Mathf.Abs(TargetY - PlayerY);

                if ((horizontal + vertical) < BestSteps)
                    BestSteps = horizontal + vertical;
            }
        }
        if (BestSteps != 1000)
            Debug.Log($"Closest Enemy is {BestSteps} steps away");
        else
            Debug.Log("No close Enemies");
    }

}

public class GridPosition
{
    private int x;
    private int y;

    public GridPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int GetXPosition()
    {
        return x;
    }

    public int GetYPosition()
    {
        return y;
    }
}
