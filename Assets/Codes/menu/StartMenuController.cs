using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void OnStagesClick()
    {
        SceneManager.LoadScene("Stages");
    }

    public void OnPlayerSelectionClick()
    {
        SceneManager.LoadScene("Selection");
        PlayerPrefs.DeleteAll();

    }

    // Update is called once per frame
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
