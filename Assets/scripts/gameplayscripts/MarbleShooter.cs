using UnityEngine;
using UnityEngine.InputSystem;

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
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            startDragPosition = GetMouseWorldPosition();
            isDragging = true;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame && isDragging)
        {
            endDragPosition = GetMouseWorldPosition();
            Shoot();
            isDragging = false;
        }
    }

    void Shoot()
{
    Vector3 direction = startDragPosition - endDragPosition;
    direction.y = 0.5f;

    float maxForce = 30f;

    if (direction.magnitude > maxForce)
    {
        direction = direction.normalized * maxForce;
    }

    rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);
}
    
    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }
}