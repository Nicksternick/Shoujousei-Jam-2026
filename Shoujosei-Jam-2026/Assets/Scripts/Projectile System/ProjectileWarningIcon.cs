using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileWarningIcon : MonoBehaviour
{
    public Action OnComplete;
    [SerializeField] private SpriteRenderer warningSprite;
    public int DisplayTime;

    private void FixedUpdate()
    {
        DisplayTime--;
        warningSprite.color = DisplayTime % 2 == 0 ? Color.red : Color.white;

        if (DisplayTime <= 0)
        {
            OnComplete();
            Destroy(this.gameObject);
        }
    }
}
