using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DanceManager : MonoBehaviour
{
    public DanceJudge judge;
    public GameObject startPanel;
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public GameObject dancePartner1;
    public GameObject dancePartner2;
    public AudioSource music1;
    public AudioSource music2;
    public AudioSource applauseSound;
    public float danceDuration = 10f;

    private float timer = 0f;
    private bool isDancing = false;
    private int selectedDance = 0;

    void Update()
    {
        if (isDancing)
        {
            timer += Time.deltaTime;

            if (timer >= danceDuration)
            {
                EndDance();
            }
        }
    }

    public void StartDance(int danceIndex)
    {
        selectedDance = danceIndex;
        startPanel.SetActive(false);
        isDancing = true;
        timer = 0f;
        judge.ResetScore();

        if (selectedDance == 0)
        {
            dancePartner1.SetActive(true);
            music1.Play();
        }
        else
        {
            dancePartner2.SetActive(true);
            music2.Play();
        }
    }

    void EndDance()
    {
        isDancing = false;
        music1.Stop();
        music2.Stop();
        float finalScore = judge.GetScorePercentage();
        resultText.text = "You are " + GetRating(finalScore) + "!\nScore: " + Mathf.RoundToInt(finalScore * 100f) + "%";
        resultPanel.SetActive(true);
        applauseSound.Play();
    }

    string GetRating(float score)
    {
        if (score > 0.9f) return "Perfect";
        if (score > 0.75f) return "Great";
        if (score > 0.5f) return "Good";
        return "Try Again";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
