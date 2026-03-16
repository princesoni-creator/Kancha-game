using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    public int score;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}