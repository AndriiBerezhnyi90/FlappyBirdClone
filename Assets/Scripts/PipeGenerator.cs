using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private Pipe _prefab;
    [SerializeField] private int _pipesAmount;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _maxOffsetY;
    [SerializeField] private Transform _container;

    private List<Pipe> _pipes = new List<Pipe>();

    private float _elapsedTime;
    private float _outOfScreenPoint;

    private void Awake()
    {
        _outOfScreenPoint = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.5f)).x - _prefab.transform.localScale.x;
        FillPipes();
    }

    private void OnEnable()
    {
        foreach (var pipe in _pipes)
            pipe.OutOfScreen += RemovePipe;
    }

    private void OnDisable()
    {
        foreach (var pipe in _pipes)
            pipe.OutOfScreen -= RemovePipe;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _timeBetweenSpawn)
        {
            AddPipe();
            _elapsedTime = 0;
        }
    }

    public void Restart()
    {
        foreach (var pipe in _pipes)
        {
            RemovePipe(pipe);
        }
    }

    private void FillPipes()
    {
        for (int i = 0; i < _pipesAmount; i++)
        {
            Pipe pipe = Instantiate(_prefab, _container);
            _pipes.Add(pipe);
            pipe.SetDestroyPoint(_outOfScreenPoint);
            pipe.gameObject.SetActive(false);
        }
    }

    private void AddPipe()
    {
        var pipe = _pipes.FirstOrDefault(p => p.gameObject.activeSelf == false);
        Vector3 startPosition = new Vector3(_container.position.x, _container.position.y + Random.Range(-_maxOffsetY, _maxOffsetY));

        if (pipe != null)
        {
            pipe.transform.position = startPosition;
            pipe.gameObject.SetActive(true);    
        }
    }

    private void RemovePipe(Pipe pipe)
    {
        pipe.gameObject.SetActive(false);
        pipe.transform.position = _container.position;
    }
}