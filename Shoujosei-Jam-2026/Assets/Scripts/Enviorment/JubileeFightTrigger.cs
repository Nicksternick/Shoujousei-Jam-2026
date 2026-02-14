using UnityEngine;
using Yarn.Unity;

public class JubileeFightTrigger : MonologueTrigger
{
    private bool eventStarted = false;
    private OverworldPlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (eventStarted)
        {
            if (!player.FadeSprite.FadingToBlack)
            {
                player.transform.position = new Vector3(42.55f, 26.86f, player.transform.position.z);
                if (!dialogueRunner.IsDialogueRunning)
                {
                    dialogueRunner.StartDialogue(nodeName);
                }
                
            }
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
         player = other.GetComponent<OverworldPlayerController>();
        if (player != null)
        {
            player.FadeSprite.StartFadeToBlack();
            player.OnDialogueStart();
            eventStarted = true;
        }
    }

    [YarnCommand("ReturnFromFade")]
    public void ReturnFromFade()
    {
        player.FadeSprite.FadeFromBlack();
        eventStarted = false;
    }
}
