using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;

    private int _scores;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction Died;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
        ScoreChanged?.Invoke(_scores);
    }

    public void AddScore()
    {
        ScoreChanged?.Invoke(++_scores);
    }

    public void SetStartPosition()
    {
        _scores = 0;
        ScoreChanged?.Invoke(_scores);
        _birdMover.Restart();
    }

    public void Die()
    {
        Died?.Invoke();
    }
}