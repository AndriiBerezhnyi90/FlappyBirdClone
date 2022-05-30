using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Bird))]
public class BirdCollistionHandler : MonoBehaviour
{
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PipePass scoreTrigger))
        {
            _bird.AddScore();
        }
        else
        {
            _bird.Die();
        }
    }
}