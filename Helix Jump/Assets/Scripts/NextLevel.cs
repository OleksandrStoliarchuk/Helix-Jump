using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject levelBtn;

    public void Level()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
