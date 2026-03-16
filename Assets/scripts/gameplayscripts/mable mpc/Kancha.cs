using UnityEngine;

public class Kancha : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Arena"))
        {
            MatchManager.Instance.AddScore();
            Destroy(gameObject);
        }
    }

    void Collect()
    {
        MatchManager.Instance.AddScore();
        Destroy(gameObject);
    }
}