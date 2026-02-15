using UnityEngine;
using Yarn.Unity;
public class JubileeGlimpseTrigger : MonologueTrigger
{
    private static bool triggered;
    [SerializeField]
    private GameObject jubileeSprite;
    [SerializeField]
    private Animator jubileeAnim;
    private bool SpriteMoving;
    private int direction = 0;
    [SerializeField]
    private float speed;
    private OverworldPlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneChangeDataManager.Instance.GlimpseTriggered)
        {
            jubileeSprite.SetActive(false);
        }
       if(jubileeAnim == null)
       {
            jubileeAnim = jubileeSprite.GetComponent<Animator>();   
       } 
    }

    // Update is called once per frame
    void Update()
    {
        if(SpriteMoving)
        {
            //start of encounter
            if (direction == -1)
            {
                jubileeSprite.transform.position = new Vector3(jubileeSprite.transform.position.x, jubileeSprite.transform.position.y - speed * Time.deltaTime, jubileeSprite.transform.position.z);
                if (jubileeSprite.transform.position.y <= 27.3)
                {
                    dialogueRunner.StartDialogue(nodeName);
                    direction = 0;
                    jubileeAnim.SetFloat("Walk", 0);
                }
            }
            //end of encounter
            else if (direction == 1)
            {
                jubileeSprite.transform.position = new Vector3(jubileeSprite.transform.position.x, jubileeSprite.transform.position.y + speed * Time.deltaTime, jubileeSprite.transform.position.z);
                if (jubileeSprite.transform.position.y >= 30)
                {
                    jubileeSprite.SetActive(false);
                    player.OnDialogueEnd();
                    SceneChangeDataManager.Instance.GlimpseTriggered = true;
                }
            }
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<OverworldPlayerController>();
        if (player && !SceneChangeDataManager.Instance.GlimpseTriggered)
        {
            player.OnDialogueStart();
            SpriteMoving = true;
            direction = -1;
            jubileeAnim.SetFloat("Walk", 1);
        }
    }

    [YarnCommand("JubileeExit")]
    public void StartJubileeExit()
    {
        direction = 1;
        jubileeAnim.SetFloat("Walk", 1);
    }
}
