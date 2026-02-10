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
    [SerializeField] PlayerStateMachine state;
    [SerializeField] private PlayerInput input;
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private float dampFactor;

    [SerializeField] private int iFrameCount;
    [SerializeField] private int iFrameTimer;

    [SerializeField] SpriteRenderer spriteRenderer;

    private Vector3 refVelocity;
    
    private InputAction move;

    private void Awake()
    {
        move = input.actions.FindAction("Move");
        BattleManager.Instance.UpdatePlayerHealthUI(health);
    }

    private void FixedUpdate()
    {
        UpdateState(state);
    }
    
    public void EnterState(PlayerStateMachine state)
    {
        this.state = state; 
        switch (state)
        {
            case PlayerStateMachine.Normal:
                Color color = spriteRenderer.color;
                color.a = 1;
                spriteRenderer.color = color;

                break;
            case PlayerStateMachine.Charging:
                break;
            case PlayerStateMachine.Damage:
                iFrameTimer = iFrameCount;
                break;
        }
    }

    public void UpdateState(PlayerStateMachine state)
    {
        switch (state)
        {
            case PlayerStateMachine.Normal:
                Move();
                break;

            case PlayerStateMachine.Charging:
                Move();
                break;

            case PlayerStateMachine.Damage:
                Move();

                iFrameTimer--;
                Color color = spriteRenderer.color;
                color.a = iFrameTimer % 2 == 0 ? 1 : 0.5f;
                spriteRenderer.color = color;

                if (iFrameTimer <= 0) EnterState(PlayerStateMachine.Normal);
                break;
        }
    }


    private void Move()
    {
        Vector3 position = transform.position;
        Vector3 velocity = move.ReadValue<Vector2>().normalized * speed;

        position += velocity;

        position = BattleManager.Instance.Arena.ClampToStage(position);

        transform.position = Vector3.SmoothDamp(transform.position, position, ref refVelocity, dampFactor);
    }

    public void TakeDamage(int damage)
    {
        if (state == PlayerStateMachine.Damage) { return; }
        EnterState(PlayerStateMachine.Damage);
        health -= damage;
        BattleManager.Instance.UpdatePlayerHealthUI(health);
    }
}
