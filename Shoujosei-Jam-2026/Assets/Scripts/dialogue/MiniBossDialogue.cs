using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class MiniBossDialogue : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;
    [SerializeField]
    private string preFightNodeName;
    [SerializeField]
    private string postFightNodeName;
    [SerializeField]
    private EnemyData enemyData;
    [SerializeField]
    private OverworldPlayerController player;
    private bool postFightDialogueActive;
    private bool jubileeExit;
    [SerializeField]
    private GameObject jubilee;
    [SerializeField]
    private float speed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<OverworldPlayerController>();
        if ( player != null)
        {
            if (!dialogueRunner.IsDialogueRunning)
            {
                dialogueRunner.StartDialogue(preFightNodeName);
                player.OnDialogueStart();
            }
               
        }
    }

    [YarnCommand("BeginBattle")]
    public void OnDialogueEnd()
    {
        SceneChangeDataManager.Instance.EnemyData = enemyData;
        SceneChangeDataManager.Instance.OverWorldPlayerPosition = player.transform.position;
        SceneChangeDataManager.Instance.MiniBossComplete = true;
        //Debug.Log("Starting mini boss fight");
        SceneManager.LoadScene("BattleScene");
    }

    private void Start()
    {
        
    }

    public void Update()
    {
        if (SceneChangeDataManager.Instance.MiniBossComplete && !postFightDialogueActive)
        {
            dialogueRunner.StartDialogue(postFightNodeName);
            player.OnDialogueStart();
            postFightDialogueActive = true;
        }

        if (jubileeExit)
        {
            jubilee.transform.position = new Vector3(jubilee.transform.position.x, jubilee.transform.position.y + (speed * Time.deltaTime), jubilee.transform.position.z);
            jubilee.GetComponent<Animator>().SetFloat("Walk", 1);
            if(jubilee.transform.position.y >= 34.5)
            {
                jubilee.SetActive(false);
                player.OnDialogueEnd();
            }
        }
    }

    [YarnCommand("EndPostFight")]
    public void OnPostDialogueEnd()
    {
        jubileeExit = true;
    }
}
