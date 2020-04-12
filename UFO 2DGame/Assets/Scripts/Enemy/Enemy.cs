﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakeDamage  
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    // how much gold is deployed when killed
    [SerializeField]
    private int gold;

    // how much XP is deployed when killed
    [SerializeField]
    private float XP;

    // true if it is a boss
    [SerializeField]
    private bool boss;

    // true if this enemy throws a heart when die
    [SerializeField]
    private bool throwsHeart;

    public GameObject heartPrefab;
    public GameObject deathEffectPrefab;

    private void Awake()
    {
        currentHealth = maxHealth;
    }


    //ThrowObject
    //ThrowHeart

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if(currentHealth <= 0)
        {
            //ThrowObject() 

            ThrowHeart();
            //ThrowGold();

            GameObject deathEffect = Instantiate(deathEffectPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
            Destroy(deathEffect, 0.4f);
        }
    }

    private void ThrowHeart()
    {
        if (throwsHeart)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }
    }
}
