using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    [SerializeField] private GameObject energyPointPrefab; // Prefab del EnergyPoint
    [SerializeField] private Transform spawnPoint; // Punto donde se instanciará el EnergyPoint

    [Header("Health Properties")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead = false;

    [Header("Character Type")]
    [SerializeField] private bool isEnemy = true; // Indica si este objeto es un enemigo

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else if (!dead)
        {
            Die();
        }
    }

    private void Die()
    {
        foreach (Behaviour component in components)
            component.enabled = false;

        anim.SetBool("Grounded", true);
        anim.SetTrigger("Death");
        anim.SetTrigger("die");
        dead = true;

        if (isEnemy && energyPointPrefab != null && spawnPoint != null)
        {
            Instantiate(energyPointPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        currentHealth = startingHealth;
        anim.ResetTrigger("Death");
        anim.Play("Idle");
        foreach (Behaviour component in components)
            component.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
    }
}
