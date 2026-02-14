using UnityEngine;

public class BossDoor : Interactable
{
    [SerializeField]
    private GameObject bossRoomMask;
    [SerializeField]
    private GameObject doorcollider;
    [SerializeField]
    private Sprite openSprite; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //mask is hidden by default so boss room is visible in editor
        if(!SceneChangeDataManager.Instance.FinalBossComplete)
            bossRoomMask.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInteract(OverworldPlayerController player)
    {
        bossRoomMask.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = openSprite;
        interactText.SetActive(false);
        doorcollider.SetActive(false);
    }
}
