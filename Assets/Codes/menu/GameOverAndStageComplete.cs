using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverAndStageComplete : MonoBehaviour
{

    public void OnRestartFloor1Click()
    {
        SceneManager.LoadScene("floor 1");
    }
    public void OnRestartFloor2Click()
    {
        SceneManager.LoadScene("floor 2");
    }
    public void OnRestartFloor3Click()
    {
        SceneManager.LoadScene("floor 3");
    }
    public void OnRestartFloor4Click()
    {
        SceneManager.LoadScene("floor 4");
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void StageSelection()
    {
        SceneManager.LoadScene("Stages");
    }
    public void NextFloorClick()
    {
        UnlockedNewLevel();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void UnlockedNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
        