using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class OverworldPlayerController : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 refVel;

    [SerializeField] private float speed;
    [SerializeField] private float dampValue;

    private Interactable interactable;
    public Interactable Interactable 
    { 
        set { interactable = value; } 
    }


    public void OnMove (InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (interactable != null)
        {
            interactable.OnInteract(this);
        }
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
        transform.position = position;
    }
}
