using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Interaction _interaction;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private Image _foneImage;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _moves;

    private void OnEnable()
    {
        Field.OnMoved += MoveToFail;
        Field.LevelCompleted += GameOver;
    }

    private void OnDisable()
    {
        Field.OnMoved -= MoveToFail;
        Field.LevelCompleted -= GameOver;
    }

    private void Start()
    {
        _level.text = $"Уровень {LevelController.Level}";

        _menu.SetActive(false);
        _winMenu.SetActive(false);
        _loseMenu.SetActive(false);
        _foneImage.gameObject.SetActive(false);
    }

    private void GameOver(bool win)
    {
        if (win)
        {
            Menu(_winMenu);
        }
        else
        {
            Menu(_loseMenu);
        }
    }
     
    public void Menu(GameObject menu)
    {
        menu.SetActive(!menu.activeSelf);
        _foneImage.gameObject.SetActive(!_foneImage.gameObject.activeSelf);
        _interaction.enabled = !_interaction.enabled;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void MoveToFail(int move)
    {
        _moves.text = $"Ходов: {move}";
    }
}
