using UnityEngine;
using UnityEngine.SceneManagement;

public class Debug_Scene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
