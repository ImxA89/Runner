using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _exitButton.onClick.AddListener(OnExitButtonClicked);
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _exitButton.onClick.RemoveListener(OnExitButtonClicked);
        _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0f;
        _gameOverGroup.interactable = false;
    }

    private void OnPlayerDied()
    {
        Time.timeScale = 0f;
        _gameOverGroup.alpha = 1f;
        _gameOverGroup.interactable = true;
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    private void OnRestartButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
