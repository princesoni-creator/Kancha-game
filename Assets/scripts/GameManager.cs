using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
