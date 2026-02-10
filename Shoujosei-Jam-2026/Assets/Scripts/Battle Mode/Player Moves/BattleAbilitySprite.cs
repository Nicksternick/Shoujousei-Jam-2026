using UnityEngine;

public class BattleAbilitySprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer chargeSprite;

    public void SetScale(float scaleValue)
    {
        Vector3 scale = chargeSprite.transform.localScale;
        scale.x = scaleValue;
        scale.y = scaleValue;
        chargeSprite.transform.localScale = scale;
    }
}
