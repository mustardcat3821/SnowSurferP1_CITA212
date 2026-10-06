using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUpSO powerUp;

    playerController player;

    SpriteRenderer spriteRenderer;
    float timeLeft;

    void Start()
    {
        player = FindAnyObjectByType<playerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerUp.getDuration();
    }

    void Update()
    {
        countdownTimer();
    }

    void countdownTimer()
    {
        if (!spriteRenderer.enabled)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;

                if (timeLeft <= 0)
                {
                    print("Time's up!");
                    player.deactivatePowerUp(powerUp);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex && spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            player.activatePowerUp(powerUp);
        }
    }
}
