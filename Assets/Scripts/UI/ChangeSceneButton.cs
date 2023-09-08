using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] private string scene_name;

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene_name);
    }
}
