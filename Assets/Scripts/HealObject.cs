using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : MonoBehaviour

{
    public float heal = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health == null)
        {
            return;
        }

        health.Heal(heal);
        Destroy(gameObject);
    }

}
