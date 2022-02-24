using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [Header("Delay Settings")] 
    [SerializeField] private float delayAfterCrash;

    [Header("Particle System Settings")] 
    [SerializeField] private ParticleSystem crashEffect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            crashEffect.Play();
            Invoke(nameof(ReloadScene), delayAfterCrash);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}