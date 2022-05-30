using UnityEngine;
using UnityEngine.Events;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _destroyPointX;

    public event UnityAction<Pipe> OutOfScreen;

    public void SetDestroyPoint(float destroyPointX)
    {
        _destroyPointX = destroyPointX;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, _speed * Time.deltaTime);

        if (transform.position.x < _destroyPointX)
            OutOfScreen?.Invoke(this);
    }
}