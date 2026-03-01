using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject marblePrefab;
    public Transform spawnPoint;

    void Start()
    {
        Instantiate(marblePrefab, spawnPoint.position, Quaternion.identity);
    }
}