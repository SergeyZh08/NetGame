using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] public static int Level { get; private set; }
    private int _allLevels;

    private void OnEnable()
    {
        Field.LevelCompleted += LevelUp;
    }

    private void OnDisable()
    {
        
        Field.LevelCompleted -= LevelUp;
    }

    private void Awake()
    {
        _allLevels = Resources.LoadAll("Levels").Length;

        Level = PlayerPrefs.GetInt("Level", 1);
    }

    private void LevelUp(bool completed)
    {
        if (completed)
        {
            Level++;

            if (Level > _allLevels)
            {
                Level = 1;
            }

            PlayerPrefs.SetInt("Level", Level);
        }
    }
}
