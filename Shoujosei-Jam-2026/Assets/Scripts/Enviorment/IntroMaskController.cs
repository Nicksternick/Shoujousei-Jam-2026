using UnityEngine;
using Yarn.Unity;

public class IntroMaskController : MonoBehaviour
{
    private bool startFade;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    [Range(0, 1)]
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startFade)
        {
            float alpha = spriteRenderer.color.a;
            spriteRenderer.color = new Color(0, 0, 0, alpha - (speed * Time.deltaTime));
            
        }
    }

    [YarnCommand("StartFade")]
    public void OnStartFade()
    {
        startFade = true;
    }
}
