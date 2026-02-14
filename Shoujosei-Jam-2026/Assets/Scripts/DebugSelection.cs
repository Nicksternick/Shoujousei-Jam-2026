using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugSelection : MonoBehaviour
{
    [SerializeField] private Button basicEnemy;
    [SerializeField] private Button miniBoss;
    [SerializeField] private Button finalBoss;

    [SerializeField] private EnemyData basic;
    [SerializeField] private EnemyData mid;
    [SerializeField] private EnemyData final;

    [SerializeField] private SpriteRenderer sprite;

    bool transition = false;

    private void Start()
    {
        basicEnemy.onClick.AddListener(() => { SceneChangeDataManager.Instance.EnemyData = basic; transition = true; });
        miniBoss.onClick.AddListener(() => { SceneChangeDataManager.Instance.EnemyData = mid; transition = true; });
        finalBoss.onClick.AddListener(() => { SceneChangeDataManager.Instance.EnemyData = final; transition = true; });
    }

    private void FixedUpdate()
    {
        if (transition)
        {
            if (sprite.color.a <= 1)
            {
                Color color = sprite.color;
                color.a += 0.05f;
                Debug.Log(color.a);
                sprite.color = color;
            }
            else
            {
                SceneManager.LoadScene("BattleScene");
            }
        }
    }
}
