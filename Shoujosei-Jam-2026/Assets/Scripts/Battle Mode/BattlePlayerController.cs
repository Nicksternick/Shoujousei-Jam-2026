using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattlePlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private float dampFactor;

    private Vector3 refVelocity;
    
    private InputAction move;

    private void Awake()
    {
        move = input.actions.FindAction("Move");
        BattleManager.instance.UpdatePlayerHealthUI(health);
    }

    private void Start()
    {
        transform.position = BattleManager.instance.CenterOnState();
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        Vector3 velocity = move.ReadValue<Vector2>().normalized * speed;

        position += velocity;

        position = BattleManager.instance.ClampToStage(position);

        transform.position = Vector3.SmoothDamp(transform.position, position, ref refVelocity, dampFactor);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        BattleManager.instance.UpdatePlayerHealthUI(health);
    }
}
