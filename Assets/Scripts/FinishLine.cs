using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [Header("Delay Settings")] 
    [SerializeField] private float delayAfterFinish;

    [Header("Particle System Settings")] 
    [SerializeField] private ParticleSystem finishEffect;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke(nameof(ReloadScene), delayAfterFinish);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}