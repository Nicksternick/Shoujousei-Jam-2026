using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
public class TalkSpriteController : MonoBehaviour
{
    [SerializeField]
    private GameObject emilySpriteObj;
    [SerializeField]
    private GameObject otherSpriteObj;
    private Image otherSpriteRenderer;
    [SerializeField]
    private Sprite jubileeSprite;
    [SerializeField]
    private Sprite spiderSprite;
    [SerializeField]
    private Sprite queenSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        otherSpriteRenderer = otherSpriteObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("ShowEmily")]
    public void ShowEmily()
    {
        emilySpriteObj.SetActive(true);
        otherSpriteObj.SetActive(false);
    }

    [YarnCommand("ShowJubilee")]
    public void ShowJubilee()
    {
        emilySpriteObj.SetActive(false);
        otherSpriteRenderer.sprite = jubileeSprite;
        otherSpriteObj.SetActive(true);
    }

    [YarnCommand("ShowSpider")]
    public void ShowSpider()
    {
        emilySpriteObj.SetActive(false);
        otherSpriteRenderer.sprite = spiderSprite;
        otherSpriteObj.SetActive(true);
    }

    [YarnCommand("ShowQueen")]
    public void ShowQueen()
    {
        emilySpriteObj.SetActive(false);
        otherSpriteRenderer.sprite = queenSprite;
        otherSpriteObj.SetActive(true);
    }
    [YarnCommand("Hide")]
    public void HideSprites()
    {
        emilySpriteObj.SetActive(false);
        otherSpriteObj.SetActive(false);
    }
}
