using UnityEngine;
using System.Collections;

public class PlayerAttack1 : MonoBehaviour
{
    private bool _attacking = false;

    private float _attackTimer = 0;
    private float _attackCooldown = 0.3f;

    public Collider2D attackTrigger;

    private Animator _animator;

    public void Awake()
    {
        //_animator = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown("z") && !_attacking)
        {
            _attacking = true;
            _attackTimer = _attackCooldown;

            attackTrigger.enabled = true;
        }

        if(_attacking)
        {
            if(_attackTimer > 0)
            {
                _attackTimer -= Time.deltaTime;
            }
            else
            {
                _attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}
