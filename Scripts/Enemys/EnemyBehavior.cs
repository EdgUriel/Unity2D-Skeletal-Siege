/*using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{
    [Header("Basic Enemy Settings")]
    public float speed = 1.0f; // Velocidad de movimiento común para todos los enemigos

    protected Animator anim;
    protected Transform enemyTransform;
    protected Health health;

    protected virtual void Awake()
    {
        // Inicialización de componentes comunes
        anim = GetComponent<Animator>();
        enemyTransform = GetComponent<Transform>();
        health = GetComponent<Health>();

        // Añadir más configuraciones comunes si es necesario
    }

    protected virtual void Start()
    {
        // Configuraciones adicionales al iniciar
    }

    protected virtual void Update()
    {
        // Comportamiento común de actualización si es necesario
    }

    protected virtual void OnDeath() {
    // Implementación base que puede ser sobrescrita por las clases derivadas.
    }

    // Puedes añadir métodos comunes aquí, como métodos para moverse, morir, atacar, etc.
}
*/