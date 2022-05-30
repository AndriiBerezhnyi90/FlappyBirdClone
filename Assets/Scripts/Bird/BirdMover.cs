using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _flapForce;
    [SerializeField] private float _maxRotation;
    [SerializeField] private float _minRotation;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _startPosition;

    private float _maxHeight;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startPosition = transform.position;

        _maxHeight = Camera.main.ViewportToWorldPoint(new Vector2(0, 1f)).y;
        _maxHeight -= transform.localScale.y / 2;
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (Input.GetMouseButtonDown(0))
            WingFlap();

        if (transform.position.y >= _maxHeight)
            transform.position = new Vector2(transform.position.x, _maxHeight);

        transform.rotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0,0,_minRotation), _rotationSpeed * Time.deltaTime);
    }

    public void Restart()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = new Vector2(0, 0);
    }

    private void WingFlap()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _flapForce);

        _animator.SetTrigger(BirdAnimator.Parameters.Flap);

        transform.rotation = Quaternion.Euler(0, 0, _maxRotation);
    }
}