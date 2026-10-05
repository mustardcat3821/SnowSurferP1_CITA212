using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int LayerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == LayerIndex)
        {
            snowParticles.Play();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        int LayerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == LayerIndex)
        {
            snowParticles.Stop();
        }
    }
}
