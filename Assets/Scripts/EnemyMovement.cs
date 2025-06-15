using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    

    [Header("Patrol Settings")]
    public Transform[] patrolPoints; // Lista punktów patrolowych
    public float patrolSpeed = 2f; // Prêdkoœæ poruszania podczas patrolowania
    public float patrolSpeed2 = 10f;
    private int _currentPatrolIndex = 0; // Aktualny indeks punktu patrolowego

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (patrolPoints.Length > 0)
        {
            GoToNextPatrolPoint();
        }
    }

    private void Update()
    {

        Patrol();
        
    }

    private void Patrol()
    {
        if (Vector2.Distance(transform.position, patrolPoints[_currentPatrolIndex].position) < 1f)
        {
            // Jeœli dotarliœmy do punktu patrolowego, przechodzimy do nastêpnego
            _currentPatrolIndex = (_currentPatrolIndex + 1) % patrolPoints.Length;
            GoToNextPatrolPoint();
        }
        else
        {
            // Poruszamy siê w kierunku aktualnego punktu patrolowego
            Vector2 direction = (patrolPoints[_currentPatrolIndex].position - transform.position).normalized;
            direction.y = 0;
            _rigidbody2D.velocity = direction * patrolSpeed;
        }

        Flip(-_rigidbody2D.velocity.x);
    }

    private void Flip(float moveInput)
    {
        if (moveInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        Vector2 targetPosition = patrolPoints[_currentPatrolIndex].position;
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        _rigidbody2D.velocity = direction * patrolSpeed;
    }
    

    /*private void OnTriggerEnter2D(Collider2D collision)
    {float moveInput = Input.GetAxis("Horizontal");
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
            _rigidbody2D.velocity = new Vector2(moveInput * patrolSpeed2, _rigidbody2D.velocity.y);*/
       

    
}