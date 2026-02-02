using UnityEngine;
using Yarn.Unity;

public class MonologueTrigger : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;
    [SerializeField]
    private string nodeName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (dialogueRunner == null)
        {
            Debug.Log("Dialogue Runner not set on " + gameObject.name);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<OverworldPlayerController>();
        if (player)
        {
            if (!dialogueRunner.IsDialogueRunning)
                dialogueRunner.StartDialogue(nodeName);
        }
    }
}
