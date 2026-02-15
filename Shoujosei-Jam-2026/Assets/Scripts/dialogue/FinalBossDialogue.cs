using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class FinalBossDialogue : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;
    [SerializeField]
    private string preFightNodeName;
    [SerializeField]
    private string postFightNodeName;
    [SerializeField]
    private string finalDialogueNodeName;
    private bool postFightDialogueActive;
    private bool postBossFadeActive;
    [SerializeField]
    private EnemyData enemyData;
    [SerializeField]
    private OverworldPlayerController player;

    [SerializeField] private SpriteRenderer reveal;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!SceneChangeDataManager.Instance.FinalBossComplete)
        {
            player = collision.GetComponent<OverworldPlayerController>();
            if (player != null)
            {
                if (!dialogueRunner.IsDialogueRunning)
                {
                    dialogueRunner.StartDialogue(preFightNodeName);
                    player.OnDialogueStart();
                }

            }
        }
    }

    [YarnCommand("BeginFinalBattle")]
    public void OnDialogueEnd()
    {
        SceneChangeDataManager.Instance.EnemyData = enemyData;
        SceneChangeDataManager.Instance.OverWorldPlayerPosition = player.transform.position;
        SceneChangeDataManager.Instance.FinalBossComplete = true;
        //Debug.Log("Starting mini boss fight");
        SceneManager.LoadScene("BattleScene");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneChangeDataManager.Instance.FinalBossComplete && !postFightDialogueActive)
        {
            dialogueRunner.StartDialogue(postFightNodeName);
            player.OnDialogueStart();
            postFightDialogueActive = true;
        }

        if(postBossFadeActive && postBossFadeActive)
        {
            if (!player.FadeSprite.FadingToBlack)
            {
                dialogueRunner.StartDialogue(finalDialogueNodeName);
                postBossFadeActive = false;
            }
        }
    }

    [YarnCommand("PostBossFadeOut")]
    public void StartFadeToEnd()
    {
        player.FadeSprite.StartFadeToBlack();
        postBossFadeActive = true;
    }

    [YarnCommand("RevealJubilee")]
    public void RevealJubilee()
    {
        reveal.gameObject.SetActive(true);
    }

    [YarnCommand("GoToTitle")]
    public void GoToTitle()
    {
        AudioManager.Instance.StopMusic();
        SceneManager.LoadScene("TitleScreen");
    }
}
