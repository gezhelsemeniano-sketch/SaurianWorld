using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Transform BrainsContainer;
    [SerializeField] private Transform HeartsContainer;

    private List<Image> playersBrain;
    private List<Image> bossHeart;

    public int playersHealth = 3;
    public int bossHealth = 3;

    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite fullBrain;
    public Sprite emptyBrain;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject stageCompletePanel;


    private void Start()
    {
        playersBrain = new List<Image>(BrainsContainer.GetComponentsInChildren<Image>(true));
        bossHeart = new List<Image>(HeartsContainer.GetComponentsInChildren<Image>(true));
    }

    private void Update()
    {
        if (playersBrain == null || bossHeart == null)
            return;

        PlayersBrainCounts();
        BossHealthCounts();
    }
    //counters
    void PlayersBrainCounts()
    {
        for (int i = 0; i < playersBrain.Count; i++)
            playersBrain[i].sprite = i < playersHealth ? fullBrain : emptyBrain;
    }
    void BossHealthCounts()
    {
        for (int i = 0; i < bossHeart.Count; i++)
            bossHeart[i].sprite = i < bossHealth ? fullHeart : emptyHeart;
    }
    //damage thinginings
    public void DamagePlayer(int amount = 1)
    {
        playersHealth = Mathf.Max(playersHealth - amount, 0);
        if (playersHealth <= 0)
        {
            GameOver();
        }
    }
    public void DamageBoss(int amount = 1)
    {
        bossHealth = Mathf.Max(bossHealth - amount, 0);
        if (bossHealth <= 0)
        {
            StageComplete();
        }
    }
    //Gameover
    public void GameOver()
    {
        Debug.Log("GAME OVER triggered");
        gameOverPanel.SetActive(true);
    }
    public void StageComplete()
    {
        Debug.Log("STAGE COMPLETE triggered");
        stageCompletePanel.SetActive(true);
    }

}