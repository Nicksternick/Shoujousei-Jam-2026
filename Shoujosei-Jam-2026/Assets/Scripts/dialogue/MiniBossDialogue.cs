using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class MiniBossDialogue : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;
    [SerializeField]
    private string nodeName;
    [SerializeField]
    private EnemyData enemyData;
    [SerializeField]
    private OverworldPlayerController player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<OverworldPlayerController>();
        if ( player != null)
        {
            if (!dialogueRunner.IsDialogueRunning)
                dialogueRunner.StartDialogue(nodeName);
        }
    }

    [YarnCommand("EndDialogue")]
    public void OnDialogueEnd()
    {
        SceneChangeDataManager.Instance.EnemyData = enemyData;
        SceneChangeDataManager.Instance.OverWorldPlayerPosition = player.transform.position;
        Debug.Log("Starting mini boss fight");
        //SceneManager.LoadScene("BattleScene");
    }
}
