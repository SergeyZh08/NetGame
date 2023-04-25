using System;
using UnityEditor;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    public int[,] StartArray { get; private set; }
    public int MoveToFail { get; private set; }
    private int _size = 5;

    void Awake()
    {
        int k = 0;
        StartArray = new int[_size, _size];

        string path = "Levels/Level" + LevelController.Level;
        var textFile = Resources.Load<TextAsset>(path);

        string str = textFile.text;

        string clearStr = "";

        int index = 0;

        while (index < str.Length)
        {
            if (str[index] >= 48 && str[index] <= 57)
            {
                clearStr += str[index];
            }

            index++;
        }

        for (int i = _size - 1; i >= 0; i--)
        {
            for (int j = 0; j < _size; j++)
            {
                StartArray[i, j] = clearStr[k++] - '0';
            }
        }

        index = _size * _size;

        while (index < clearStr.Length)
        {
            MoveToFail += clearStr[index] - '0';

            index++;

            if (index < clearStr.Length)
            {
                MoveToFail *= 10;
            }
        }
    }
}