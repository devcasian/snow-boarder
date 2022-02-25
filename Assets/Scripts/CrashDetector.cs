using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [Header("Delay Settings")] 
    [SerializeField] private float delayAfterCrash;

    [Header("Particle System Settings")] 
    [SerializeField] private ParticleSystem crashEffect;

    [Header("Audio Settings")] 
    [SerializeField] private AudioClip crashSfx;

    private bool _hasCrashed;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Ground") || _hasCrashed) return;
        _hasCrashed = true;
        GetComponent<AudioSource>().PlayOneShot(crashSfx);
        FindObjectOfType<PlayerController>().DisableControls();
        crashEffect.Play();
        Invoke(nameof(ReloadScene), delayAfterCrash);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}