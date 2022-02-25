using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [Header("Delay Settings")] 
    [SerializeField] private float delayAfterFinish;

    [Header("Particle System Settings")] 
    [SerializeField] private ParticleSystem finishEffect;

    private bool _hasPlayed;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        if (!_hasPlayed)
        {
            GetComponent<AudioSource>().Play();
            _hasPlayed = true;
        }

        finishEffect.Play();
        Invoke(nameof(ReloadScene), delayAfterFinish);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}