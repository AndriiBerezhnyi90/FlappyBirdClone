using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private PipeGenerator _pipeGenerator;

    private void Start()
    {
        _gameOverScreen.Off();
        _startScreen.On();
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _bird.Died += OnDied;
        _startScreen.StartButtonClick += OnStartButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _bird.Died -= OnDied;
        _startScreen.StartButtonClick -= OnStartButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
    }

    private void OnDied()
    {
        Time.timeScale = 0;
        _gameOverScreen.On();
    }

    private void OnRestartButtonClick()
    {
        _bird.SetStartPosition();
        _pipeGenerator.Restart();
        _gameOverScreen.Off();
        _startScreen.On();
        Time.timeScale = 0;
    }

    private void OnStartButtonClick()
    {
        _startScreen.Off();
        Time.timeScale = 1;
    }
}