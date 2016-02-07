using UnityEngine;
using System.Collections;
using System;

public class SimpleEnemyAi : MonoBehaviour, ITakeDamage
{
    public float Speed;
    public float FireRate = 1;
    public float TimeUntilDeath = 1.0f;
    public Animator Animator;

    private bool grounded;
    private CharacterController2D _controller;
    private Vector2 _direction;
    private Vector2 _startPosition;
    private bool _beingKilled;
    


    public void Start()
    {
        _controller = GetComponent<CharacterController2D>();
        _direction = new Vector2(-1, 0);
        _startPosition = transform.position;
    }

    public void FixedUpdate()
    {

        grounded = GetComponent<CharacterController2D>().State.IsGrounded;

        if (!grounded)
        {
            _direction = -_direction;
        }

    }

    public void Update()
    {
        _controller.SetHorizontalForce(_direction.x * Speed);


        if ((_direction.x < 0 && _controller.State.IsCollidingLeft) || (_direction.x > 0 && _controller.State.IsCollidingRight))
        {
            _direction = -_direction;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }


        Animator.SetBool("IsDying", _beingKilled);
        if(_beingKilled)
        {
            GetComponent<BoxCollider2D>().enabled = false;

            if(TimeUntilDeath <= 0)
                Destroy(gameObject);

            TimeUntilDeath -= Time.deltaTime;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Knife")
        {
            _beingKilled = true;
        }
    }

    public void TakeDamage(int damage, GameObject instigator)
    {
        throw new NotImplementedException();
    }
}
