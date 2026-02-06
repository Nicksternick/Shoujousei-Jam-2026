using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    [SerializeField] protected GameObject interactText;

    public abstract void OnInteract(OverworldPlayerController player);
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<OverworldPlayerController>();
        if (player)
        {
            player.Interactable = this;
            interactText.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<OverworldPlayerController>();
        if (player)
        {
            player.Interactable = null;
            interactText.SetActive(false);
        }
    }


}
