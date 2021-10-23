using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    private int sceneGame = 0;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Level);
    }

    private void Level()
    {
        SceneManager.LoadScene(sceneGame);
    }
}
