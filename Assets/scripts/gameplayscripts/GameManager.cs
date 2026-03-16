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
    public void MarbleKnockedOut(Marble marble)
{
    Debug.Log("Marble Out!");

    // Yaha score increment karo
    // Yaha turn logic check karo
}

    private void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
