using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class SceneChange : MonoBehaviour
{
    [Scene]
    public string sceneName;

    [ContextMenu("ChangeToScene")]
    public void ChangeToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ChangeToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
