using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float delayAfterCrash;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            Invoke(nameof(ReloadScene), delayAfterCrash);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}