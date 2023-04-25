using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private AudioSource _tap;
    public static event Action<Cell> OnCellTaped;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                 if (hit.collider.GetComponent<Cell>() is Cell cell)
                 {
                    _tap.Play();
                    OnCellTaped?.Invoke(cell);
                 }
            }
        }
    }
}
