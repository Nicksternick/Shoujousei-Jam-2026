using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Image fadeSprite;
    private bool start = false;
    public void StartGame()
    {
        start = true;
    }

    private void FixedUpdate()
    {
        if (start)
        {
            if (fadeSprite.color.a < 1)
            {
                Color color = fadeSprite.color;
                color.a += 0.05f;
                fadeSprite.color = color;
            }
            else
            {
                SceneChangeDataManager.Instance.ResetValues();
                SceneManager.LoadScene("OverWorld");
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
