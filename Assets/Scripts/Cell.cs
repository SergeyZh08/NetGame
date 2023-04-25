using UnityEngine;

public enum CellState
{
    Empty,
    Circle
}

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject _circle;
    private bool _isCircle;
    public CellState CellState { get; private set; }
    public Vector2Int Position { get; private set; }

    public void SetCell(bool isCircle, CellState state, Vector2Int position)
    {
        _isCircle = isCircle;
        CellState = state;
        Position = position;

        _circle.SetActive(_isCircle);
    }
    
    public void Click()
    {
        _isCircle = !_isCircle;
        _circle.SetActive(_isCircle);

        if (_isCircle)
        {
            CellState = CellState.Circle;
        }
        else
        {
            CellState = CellState.Empty;
        }
    }
}
