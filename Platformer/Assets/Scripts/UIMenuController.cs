using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Text _score;
    [SerializeField] private Text _lifes;
    [SerializeField] private Transform _player;
    [SerializeField] private AudioSource _music;

    private float _scoreValue;
    private float _lifeValue;

    private bool _isPaused;

    private void Start()
    {
        _isPaused = false;

        _scoreValue = 0;
        _lifeValue = PlayerPrefs.GetFloat("Record", 0);

        _score.text = _scoreValue.ToString();
        _lifes.text = _lifeValue.ToString();
    }

    private void Update()
    {


        if (_isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePause();
        }

        _pausePanel.SetActive(_isPaused);
    }

    public void ChangePause()
    {
        _isPaused = !_isPaused;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenuGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SwitchSound(bool state)
    {
        if (state)
        {
            _music.volume = 0.5f;
        }
        else
        {
            _music.volume = 0f;
        }
    }
}

