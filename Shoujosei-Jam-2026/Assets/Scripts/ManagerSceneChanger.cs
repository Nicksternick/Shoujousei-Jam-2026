using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void Start()
    {
        SceneManager.LoadScene(sceneName);
    }
}
