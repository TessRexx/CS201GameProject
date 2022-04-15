// THIS SCRIPT IS TO LOAD NEXT SCENE/LEVEL

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevelScript : MonoBehaviour
{
    // References
    KeyCollectibleScript keyCollected;
    Animator transitionAnimator;

    // Start is called before the first frame update
    void Start()
    {
        keyCollected = GameObject.FindObjectOfType(typeof(KeyCollectibleScript)) as KeyCollectibleScript;
        transitionAnimator = GetComponent<Animator>();
    }

    // Collison Method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If player collides with object and has collected the key, call LoadScene method
        if (collision.gameObject.CompareTag("Player") && keyCollected.KeyAmount == 1)
        {
            FindObjectOfType<AudioManager>().PlaySound("UnlockNextLevel"); // Trigger Sound
            transitionAnimator.SetTrigger("Crossfade");
            LoadScene();
        }
    }

    // Load Scene Method
    void LoadScene()
    {
        // Loads next scene from build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
