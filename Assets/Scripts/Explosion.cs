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

    private void FixedUpdate()
    {
        _circleCollider.radius += _radialAcceleration;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float forceMagnitude = _baseForce / (Mathf.Pow(_circleCollider.radius, 2));
        Vector2 forceDirection = (collision.transform.position - this.transform.position).normalized;
        collision.rigidbody.AddForce(_baseForce * forceDirection);
    }
}
