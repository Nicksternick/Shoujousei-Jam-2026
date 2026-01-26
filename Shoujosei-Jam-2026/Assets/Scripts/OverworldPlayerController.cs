using UnityEngine;
using UnityEngine.InputSystem;

public class OverworldPlayerController : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 refVel;

   [SerializeField] private float speed;
    [SerializeField] private float dampValue;
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
        Vector3 position = transform.position;
        Vector3 velocity = direction * speed * Time.deltaTime;
        position += velocity;
        var temp = Vector3.SmoothDamp(transform.position, position, ref refVel, dampValue);
        transform.position = temp;
    }
}
