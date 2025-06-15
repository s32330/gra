using SmallScaleInteractive._2DCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public GroundChecker groundChecker;
    public Rigidbody2D rb;
    public PlayerHealth health;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private string isMovingParameterName = "IsMoving";
    [SerializeField] private string isGroundedParameterName = "IsGrounded";
    [SerializeField] private string isFallingParameterName = "IsFalling";
    [SerializeField] private string isHurtingParameterName = "IsHurt";
    [SerializeField] private string isDeadParameterName = "IsDead";
  //[SerializeField] private string isRunningParameterName = "IsRunning";

    int _isMovingHash;
    int _isGroundedHash;
    int _isFallingHash;
    int _isHurtingHash;
    int _isDeadHash;
  //int _isRunningHash;


    private void Start()
    {
        _isMovingHash = Animator.StringToHash(isMovingParameterName);
        _isGroundedHash = Animator.StringToHash(isGroundedParameterName);
        _isFallingHash = Animator.StringToHash(isFallingParameterName);
        _isHurtingHash = Animator.StringToHash(isHurtingParameterName);
        _isDeadHash = Animator.StringToHash(isDeadParameterName);
     // _isRunningHash = Animator.StringToHash(isRunningParameterName);
       
    }

    private void Update()
    {
        animator.SetBool(_isMovingHash, movement.IsMoving());
      //animator.SetBool(_isRunningHash, movement.IsRunning());
        animator.SetBool(_isGroundedHash, groundChecker.IsGrounded());

        bool isFalling = rb.velocity.y < -0.001f;
        animator.SetBool(_isFallingHash, isFalling);

    }

    public void TriggerDeath()
    {
        animator.SetTrigger(_isDeadHash);
    }

    public void TriggerHurt()
    {
        animator.SetTrigger(_isHurtingHash);
    }

}


