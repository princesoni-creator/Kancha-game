using UnityEngine;
using UnityEngine.InputSystem;

public class MarbleShooter : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxForce = 8f;

    public float forceMultiplier = 10f;
    private Rigidbody rb;

    private Vector3 startDragPosition;
    private Vector3 endDragPosition;

    private bool isDragging = false;
    AudioSource hitSound;
    CameraShake camShake;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer.enabled = false;
        hitSound = GetComponent<AudioSource>();
        camShake = Camera.main.GetComponent<CameraShake>();
    }

    void Update()
{
    if (Mouse.current.leftButton.wasPressedThisFrame)
{
    Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
        if (hit.collider.gameObject == gameObject)
        {
            startDragPosition = GetMouseWorldPosition();
            isDragging = true;
            lineRenderer.enabled = true;
        }
    }
}

    if (isDragging)
    {
        Vector3 currentDragPosition = GetMouseWorldPosition();
        Vector3 direction = startDragPosition - currentDragPosition;
        direction.y = 0f;

        if (direction.magnitude > maxForce)
        {
            direction = direction.normalized * maxForce;
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + direction);
    }

    if (Mouse.current.leftButton.wasReleasedThisFrame && isDragging)
    {
        endDragPosition = GetMouseWorldPosition();
        Shoot();
        isDragging = false;
        lineRenderer.enabled = false;
    }
}
void OnCollisionEnter(Collision collision)
{
    if(collision.gameObject.CompareTag("Wall"))
    {
        hitSound.Play();
        camShake.Shake(0.1f);
    }
}

    void Shoot()
{
    Vector3 direction = startDragPosition - endDragPosition;
    direction.y = 1f;

    float maxForce = 40f;

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