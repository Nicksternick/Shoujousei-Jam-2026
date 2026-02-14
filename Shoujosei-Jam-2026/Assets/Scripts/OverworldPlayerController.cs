using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class OverworldPlayerController : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 refVel;
    private bool inDialogue = true; // set to true by default for intro dialogue

    [SerializeField] private float speed;
    [SerializeField] private float dampValue;
    [SerializeField] private Animator animController;
    [SerializeField] private IntroMaskController fadeSprite;
    [SerializeField] private DialogueRunner dialogueRunner;

    private Interactable interactable;
    public Interactable Interactable 
    { 
        set { interactable = value; } 
    }

    public IntroMaskController FadeSprite
    {
        get { return fadeSprite; }
    }

    public void OnMove (InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (interactable != null)
        {
            interactable.OnInteract(this);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneChangeDataManager.Instance.OverWorldPlayerPosition != Vector3.zero)
        {
            transform.position = SceneChangeDataManager.Instance.OverWorldPlayerPosition;
        }

        if (!SceneChangeDataManager.Instance.IntroComplete)
        {
            dialogueRunner.StartDialogue("Intro");
        }
        else
        {
            fadeSprite.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!inDialogue)
        {
            Vector3 position = transform.position;
            Vector3 velocity = direction * speed * Time.deltaTime;
            position += velocity;
            transform.position = position;

            if(direction.x > 0 || direction.y > 0)
            {
                animController.SetFloat("Direction", 1);
                animController.SetFloat("Mag", 1);
            }
            else if(direction.x < 0 || direction.y < 0)
            {
                animController.SetFloat("Direction", -1);
                animController.SetFloat("Mag", 1);
            }
            else
            {
                animController.SetFloat("Direction", 0);
                animController.SetFloat("Mag", 0);
            }
        }
    }

    [YarnCommand("EndIntroDialogue")]
    public void EndIntroDialogue()
    {
        OnDialogueEnd();
    }
    [YarnCommand("FirstIntro")]
    public void FixedUpdate()
    {
        SceneChangeDataManager.Instance.IntroComplete = true;
    }

    public void OnDialogueEnd()
    {
        inDialogue = false;
    }

    public void OnDialogueStart() 
    {
        inDialogue = true;
        direction = Vector3.zero;
        animController.SetFloat("Direction", 0);
        animController.SetFloat("Mag", 0);
    }

}
