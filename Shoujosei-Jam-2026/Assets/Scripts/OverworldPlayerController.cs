using UnityEngine;
using UnityEngine.InputSystem;

public class OverworldPlayerController : MonoBehaviour
{
    private Vector3 direction;
    public float speed;
    public void OnMove (InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
