using UnityEngine;

public class MarbleShooter : MonoBehaviour
{
    public float forceMultiplier = 10f;
    private Rigidbody rb;

    private Vector3 startDragPosition;
    private Vector3 endDragPosition;

    private bool isDragging = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startDragPosition = GetMouseWorldPosition();
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endDragPosition = GetMouseWorldPosition();
            Shoot();
            isDragging = false;
        }
    }

    void Shoot()
    {
        Vector3 direction = startDragPosition - endDragPosition;
        rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }
}