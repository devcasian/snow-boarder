using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delayAfterFinish;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Invoke(nameof(ReloadScene), delayAfterFinish);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}