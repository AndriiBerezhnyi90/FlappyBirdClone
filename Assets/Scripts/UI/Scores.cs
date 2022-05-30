using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private Bird _bird;

    private void OnEnable()
    {
        _bird.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int scores)
    {
        _view.text = scores.ToString();
    }
}