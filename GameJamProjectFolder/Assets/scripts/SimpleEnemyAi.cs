using UnityEngine;
using System.Collections;
using System;

public class SimpleEnemyAi : MonoBehaviour, ITakeDamage
{
    public float Speed;
    public float FireRate = 1;

    private CharacterController2D _controller;
    private Vector2 _direction;
    private Vector2 _startPosition;
    

    public void Start()
    {
        _controller = GetComponent<CharacterController2D>();
        _direction = new Vector2(-1, 0);
        _startPosition = transform.position;
    }

    public void Update()
    {
        _controller.SetHorizontalForce(_direction.x * Speed);

        if((_direction.x < 0 && _controller.State.IsCollidingLeft) || (_direction.x > 0 && _controller.State.IsCollidingRight))
        {
            _direction = -_direction;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Knife")
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage, GameObject instigator)
    {
        throw new NotImplementedException();
    }
}
