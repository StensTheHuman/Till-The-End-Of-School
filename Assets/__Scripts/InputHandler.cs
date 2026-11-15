using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private bool readyToDestroyed = false;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return;

        if (rayHit.collider.gameObject.CompareTag("Joke") && context.started)
        {
            rayHit.collider.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            readyToDestroyed = true;
        }

        if (readyToDestroyed && context.canceled)
        {
            Destroy(rayHit.collider.gameObject);
        }
    }
}
