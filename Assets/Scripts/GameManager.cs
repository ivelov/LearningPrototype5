using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleObj;
    public Button restartBtn;
    public bool isActive = false;
    private float spawnRate = 1;
    private int score = 0;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isActive = true;
        StartCoroutine(SpawnTarget());
        titleObj.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: "+score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isActive = false;
        restartBtn.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator SpawnTarget()
    {
        while (isActive)
        {
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            yield return new WaitForSeconds(spawnRate);
        }
        yield break;
    }
    
}
