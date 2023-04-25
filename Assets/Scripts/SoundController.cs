using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Image _target;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;
    private int _isPause;

    private void Start()
    {
        _isPause = PlayerPrefs.GetInt("Pause", 1);

        _target.sprite = _isPause == 1 ? _soundOn : _soundOff;
        AudioListener.volume = _isPause;
    }

    public void Change()
    {
        if (_isPause == 1)
        {
            AudioListener.volume = 0;
            _isPause = 0;
            _target.sprite = _soundOff;
        }
        else if (_isPause == 0)
        {
            AudioListener.volume = 1;
            _isPause = 1;
            _target.sprite = _soundOn;
        }

        PlayerPrefs.SetInt("Pause", _isPause);
    }
}
