using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _flapForce;
    [SerializeField] private KeyCode _flapKey;
    [SerializeField] private float _maxRotation;
    [SerializeField] private float _minRotation;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float _maxHeight;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _maxHeight = Camera.main.ViewportToWorldPoint(new Vector2(0, 1f)).y;
        _maxHeight -= transform.localScale.y / 2;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_flapKey))
        {
            WingFlap();
        }

        if (transform.position.y >= _maxHeight)
            transform.position = new Vector2(transform.position.x, _maxHeight);

        transform.rotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0,0,_minRotation), _rotationSpeed * Time.deltaTime);
    }

    private void WingFlap()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(Vector2.up * _flapForce);

        _animator.SetTrigger(BirdAnimator.Parameters.Flap);

        transform.rotation = Quaternion.Euler(0, 0, _maxRotation);
    }

    
}