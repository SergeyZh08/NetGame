using System;
using UnityEngine;

public class Field : MonoBehaviour
{
    public static event Action<int> OnMoved;
    public static event Action<bool> LevelCompleted;
    [SerializeField] private Initialization _startInitialization;
    [SerializeField] private Cell _cellPrefab;
    private Cell[,] _allCell;
    private int _size = 5;
    public int MoveToFail { get; private set; }

    private void OnEnable()
    {
        Interaction.OnCellTaped += ChangeCells;
    }

    private void OnDisable()
    {
        Interaction.OnCellTaped -= ChangeCells;
    }

    void Start()
    {
        _allCell = new Cell[_size, _size];

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                Cell cell = Instantiate(_cellPrefab, new Vector3(i, j, 0), Quaternion.identity);
                _allCell[i, j] = cell;

                if (_startInitialization.StartArray[i, j] == 1)
                {
                    _allCell[i, j].SetCell(true, CellState.Circle, new Vector2Int(i, j));
                }
                else
                {
                    _allCell[i, j].SetCell(false, CellState.Empty, new Vector2Int(i, j));
                }
            }
        }

        MoveToFail = _startInitialization.MoveToFail;
        OnMoved?.Invoke(MoveToFail);
    }

    private void ChangeCells(Cell cell)
    {
        MoveToFail--;
        OnMoved?.Invoke(MoveToFail);

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i != 0 && j != 0)
                {
                    continue;
                }

                Vector2Int newCell = cell.Position + new Vector2Int(i, j);

                if (newCell.x < 0 || newCell.x >= _size || newCell.y < 0 || newCell.y >= _size)
                {
                    continue;
                }

                _allCell[newCell.x, newCell.y].Click();
            }
        }

        Check();
    }

    private void Check()
    {
        int count = 0;
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (_allCell[i, j].CellState == CellState.Empty)
                {
                    count++;
                }
            }
        }

        if (count == _size * _size)
        {
            LevelCompleted?.Invoke(true);
            return;
        }

        if (MoveToFail == 0)
        {
            LevelCompleted?.Invoke(false);
        }
    }
}
