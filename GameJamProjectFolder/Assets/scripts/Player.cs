using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private bool _isFacingRight;
    private CharacterController2D _controller;
    private HealthController _healthController;
    private float _normalizedHorizontalSpeed;
    private bool _hasGun;

    public float MaxSpeed = 8;
    public float SpeedAccelerationOnGround = 10f;
    public float SpeedAccelerationInAir = 5f;
    public int MaxHealth = 100;
    public GameObject HealthBar;

    public Projectile Projectile;
    public float FireRate;
    public Transform ProjectileFireLocation;

    public AudioClip PlayerHitSound;
    public AudioClip PlayerMeleeSound;
    public AudioClip PlayerShootSound;
    public AudioClip PlayerDeathSound;
	
    // public GameObject OuchEffect;

    public int Health { get; private set; }
    public bool IsDead { get; private set; }
    public bool HasGun { get { return _hasGun; } }

    public Animator Animator;
    private float _canFireIn;

    public void Awake()
    {
        _controller = GetComponent<CharacterController2D>();
        _healthController = HealthBar.GetComponent<HealthController>();
        _healthController.ResetHealth();
        _isFacingRight = transform.localScale.x > 0;
        Health = MaxHealth;
        _hasGun = false;
    }

    public void Update()
    {
        _canFireIn -= Time.deltaTime;

        if (!IsDead) HandleInput();

        var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;

        if (IsDead)
            _controller.SetHorizontalForce(0);
        else
            _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed * MaxSpeed, Time.deltaTime * movementFactor));


        Animator.SetBool("IsGrounded", _controller.State.IsGrounded);
        //Animator.SetBool("IsDead",IsDead);
        Animator.SetFloat("Speed", Mathf.Abs(_controller.Velocity.x) / MaxSpeed);
        Animator.SetBool("IsAttacking", GetComponent<PlayerAttack1>().IsAttacking);
    }
    public void FinishLevel()
    {
        enabled = false;
        _controller.enabled = false;
    }

    public void Kill()
    {
        AudioSource.PlayClipAtPoint(PlayerDeathSound, transform.position);
        _controller.HandleCollisions = false;
        GetComponent<Collider2D>().enabled = false;
        IsDead = true;
        Health = 0;

        _controller.SetForce(new Vector2(0, 10));
    }

    public void RespawnAt(Transform spawnpoint)
    {
        if (!_isFacingRight)
            Flip();

        IsDead = false;
        GetComponent<Collider2D>().enabled = true;
        _controller.HandleCollisions = true;
        Health = MaxHealth;
        _healthController.ResetHealth();

        transform.position = spawnpoint.position;
    }

    public void TakeDamage(int damage)
    {
        AudioSource.PlayClipAtPoint(PlayerHitSound, transform.position);
        // Instantiate(OuchEffect, transform.position, transform.rotation);
        Health -= damage;
        _healthController.UpdateHealth(Health, MaxHealth);
        if(Health <= 0)
        {
            LevelManager.Instance.KillPlayer();
        }
            
    }

    public void GiveHealth(int health, GameObject instagator)
    {
        this.Health = Mathf.Min(health + Health, MaxHealth);
        _healthController.UpdateHealth(Health, MaxHealth);
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.RightArrow))
        {
            _normalizedHorizontalSpeed = 1;
            if (!_isFacingRight)
                Flip();
        }
        else if (Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.LeftArrow))
        {
            _normalizedHorizontalSpeed = -1;
            if (_isFacingRight)
                Flip();
        }
        else
        {
            _normalizedHorizontalSpeed = 0;
        }

        if (_controller.CanJump && Input.GetKeyDown(KeyCode.Space))
        {
            _controller.Jump();
        }

        if (Input.GetKeyDown(KeyCode.X))
            FireProjectile();
    }

    private void FireProjectile()
    {
        if (_canFireIn > 0) return;

        var direction = _isFacingRight ? Vector2.right : Vector2.left;

        var projectile = (Projectile)Instantiate(Projectile, ProjectileFireLocation.position, ProjectileFireLocation.rotation);
        Projectile.Initialize(gameObject, direction, _controller.Velocity);

        _canFireIn = FireRate;

        AudioSource.PlayClipAtPoint(PlayerShootSound, transform.position);
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }
}
