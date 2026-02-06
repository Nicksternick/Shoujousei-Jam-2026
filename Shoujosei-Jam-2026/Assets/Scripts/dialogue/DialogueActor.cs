using UnityEditor.SearchService;
using UnityEngine;
using Yarn.Unity;

public class DialogueActor : Interactable
{
    [SerializeField]
    private DialogueRunner dialogueRunner;
    [SerializeField]
    private string nodeName;


    public override void OnInteract(OverworldPlayerController player)
    {
        Debug.Log("interact");
        if (!dialogueRunner.IsDialogueRunning)
        dialogueRunner.StartDialogue(nodeName);
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<OverworldPlayerController>();
        if (player)
        {
            player.Interactable = null;
            interactText.SetActive(false);
            dialogueRunner.Stop();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(dialogueRunner == null) {
            Debug.Log("Dialogue Runner not set on " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
