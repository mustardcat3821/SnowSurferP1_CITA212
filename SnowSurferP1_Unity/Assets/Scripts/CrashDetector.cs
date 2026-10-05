using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 2f;
    [SerializeField] ParticleSystem crashParticle;

    playerController playerController;

    private void Start()
    {
        playerController = FindAnyObjectByType<playerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            playerController.disableControls();
            crashParticle.Play();
            Invoke("ReloadScene", reloadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
