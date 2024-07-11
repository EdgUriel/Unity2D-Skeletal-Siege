using UnityEngine;

public class CrowBehavior : MonoBehaviour
{
    [Header("Detection Parameters")]
    [SerializeField] private Transform player;
    [SerializeField] private float initialDetectionRange = 5f;
    [SerializeField] private float extendedDetectionRange = 10f;
    [SerializeField] private float stopDistance = 1.5f;

    [Header("Movement Parameters")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float descentSpeed = 2f;  // Velocidad de descenso

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown = 2f;
    private float attackTimer;

    [Header("Say Parameters")]
    [SerializeField] private float sayDuration = 5f;
    private float sayTimer;

    [Header("Animator and Audio")]
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip audioSource; // Asegúrate de tener este componente

    private float currentDetectionRange;
    private bool hasSeenPlayer = false;
    private bool isDescending = false;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = player.GetComponent<Health>();
        currentDetectionRange = initialDetectionRange; // Empezamos con el rango de detección inicial
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= currentDetectionRange)
        {
            hasSeenPlayer = true;
            currentDetectionRange = extendedDetectionRange;

            if (distanceToPlayer > stopDistance)
            {
                MoveTowardsPlayer();
            }
            else
            {
                AttackPlayer();
            }
        }
        else if (hasSeenPlayer)
        {
            GoToGround();
        }

        HandleSay();
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        anim.SetBool("moving", true);
    }

    private void AttackPlayer()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown && playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(1);
            attackTimer = 0;
        }
    }

    private void GoToGround()
    {
        if (!isDescending)
        {
            isDescending = true;
            anim.SetBool("moving", false);  // Si tienes una animación para descender, actívala aquí
        }
        transform.position += Vector3.down * descentSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isDescending)
        {
            isDescending = false;
            hasSeenPlayer = false;
            currentDetectionRange = initialDetectionRange;
            anim.SetBool("moving", false);
            anim.SetTrigger("idle");  // Asegúrate de tener esta animación para el estado de reposo
        }
    }

    private void HandleSay()
    {
        sayTimer += Time.deltaTime;
        if (sayTimer >= sayDuration)
        {
            bool isAttacking = anim.GetCurrentAnimatorStateInfo(0).IsName("Attack");
            bool isMoving = anim.GetBool("moving");

            if (!isMoving && !isAttacking)
            {
                anim.SetTrigger("say");
            }

            SongController.Instance.PlaySong(audioSource, 1.0f);  // Reproduce el sonido "say"
            sayTimer = 0;
        }
    }
}
