using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    CircleCollider2D _circleCollider;

    [SerializeField]
    float _radialAcceleration;

    [SerializeField]
    float _baseForce;

    [SerializeField]
    float _maximumRadius;

    private void FixedUpdate()
    {
        _circleCollider.radius += _radialAcceleration;
        if (_circleCollider.radius > _maximumRadius)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float forceMagnitude = _baseForce / (Mathf.Pow(_circleCollider.radius, 2));
        Vector2 forceDirection = (collision.transform.position - this.transform.position).normalized;
        collision.GetComponent<Rigidbody2D>().AddForce(_baseForce * forceDirection);
    }
}
