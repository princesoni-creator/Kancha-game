using UnityEngine;

public class Marble : MonoBehaviour
{
    public bool isInsideCircle = true;
    public bool hasBeenCounted = false;
    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("CircleZone") && !hasBeenCounted)
        {
            isInsideCircle = false;
            hasBeenCounted = true;

            GameManager.Instance.MarbleKnockedOut(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CircleZone"))
        {
            isInsideCircle = true;
        }
    }
}