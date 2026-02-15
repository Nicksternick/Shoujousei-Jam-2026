using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Image fadeSprite;
    private bool fadeIn = true;
    private bool startBattle = false;
    private void Start()
    {
        AudioManager.Instance.PlayMusic(MusicTrack.Death);
    }

    public void StartGame()
    {
        if (fadeIn) { return; }
        startBattle = true;
    }

    private void FixedUpdate()
    {
        if (fadeIn)
        {
            if (fadeSprite.color.a >= 0)
            {
                Color color = fadeSprite.color;
                color.a -= 0.02f;
                fadeSprite.color = color;
            }
            else
            {
                fadeIn = false;
            }
        }

        if (startBattle)
        {
            if (fadeSprite.color.a < 1)
            {
                Color color = fadeSprite.color;
                color.a += 0.05f;
                fadeSprite.color = color;
            }
            else
            {
                AudioManager.Instance.StopMusic();
                SceneManager.LoadScene("BattleScene");
            }
        }
    }

    public void Quit()
    {
        AudioManager.Instance.StopMusic();
        SceneManager.LoadScene("TitleScreen");
    }
}
