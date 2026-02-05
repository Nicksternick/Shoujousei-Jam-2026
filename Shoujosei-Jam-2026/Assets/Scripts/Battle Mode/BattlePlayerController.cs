using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerStateMachine
{
    Normal,
    Charging,
    Damage
}

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
        BattleManager.Instance.UpdatePlayerHealthUI(health);
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        Vector3 velocity = move.ReadValue<Vector2>().normalized * speed;

        position += velocity;

        position = BattleManager.Instance.Arena.ClampToStage(position);

        transform.position = Vector3.SmoothDamp(transform.position, position, ref refVelocity, dampFactor);
    }
    
    public void EnterState(PlayerStateMachine state)
    {
        switch (state)
        {
            case PlayerStateMachine.Normal:
                break;
            case PlayerStateMachine.Charging:
                break;
            case PlayerStateMachine.Damage:
                break;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        BattleManager.Instance.UpdatePlayerHealthUI(health);
    }
}
