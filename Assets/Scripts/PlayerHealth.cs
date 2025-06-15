using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health = 100;

    public TextMeshProUGUI CurrentHealthText;
    private PlayerAnimator _animator;

    public bool isDead = false;

    private void Start()
    {
        isDead = false;
       CurrentHealthText.text = $"{health}";
       _animator = GetComponent<PlayerAnimator>();
    }
    private void Update()
    {
                CurrentHealthText.text = $"{health}";
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health>0)
        _animator.TriggerHurt();


        if (health < 0)
        {
            health = 0;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health == 0)
        {
            isDead = true;
            _animator.TriggerDeath();

        }


    }

    public void Heal(float heal)
    {
        health = health + heal;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

}
