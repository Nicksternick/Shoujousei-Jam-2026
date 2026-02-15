using UnityEngine;
using Yarn.Unity;

public class IntroMaskController : MonoBehaviour
{
    private bool fadingFromBlack;
    private bool fadingToBlack;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    [Range(0, 1)]
    private float speed;

    [SerializeField] private SpriteRenderer castle;

    public bool FadingFromBlack
    {
        get { return fadingFromBlack; }
    }
    public bool FadingToBlack
    {
        get { return fadingToBlack; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingFromBlack)
        {
            float alpha = spriteRenderer.color.a;
            if(alpha <= 0)
            {
                fadingFromBlack = false;
            }
            spriteRenderer.color = new Color(0, 0, 0, alpha - (speed * Time.deltaTime));
           
            
        }
        else if(fadingToBlack)
        {
            float alpha = spriteRenderer.color.a;
            if (alpha >= 1)
            {
                fadingToBlack = false;
            }
            spriteRenderer.color = new Color(0, 0, 0, alpha + (speed * Time.deltaTime));
        }
    }

    [YarnCommand("StartFade")]
    public void FadeFromBlack()
    {
        castle.gameObject.SetActive(false);
        fadingFromBlack = true;
    }

    public void StartFadeToBlack()
    {
        fadingToBlack = true;
    }
}
