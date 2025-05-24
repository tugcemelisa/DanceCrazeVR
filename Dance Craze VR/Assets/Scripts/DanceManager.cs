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
    public AudioSource backgroundMusic;
    public AudioSource applauseSound;
    public float danceDuration = 10f;

    private float timer = 0f;
    private bool isDancing = false;
    private int selectedDance = 0;

    void Start()
    {
        backgroundMusic.Play();
    }

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

        backgroundMusic.Pause();

        dancePartner1.SetActive(false);
        dancePartner2.SetActive(false);
        music1.Stop();
        music2.Stop();

        if (selectedDance == 0)
        {
            dancePartner1.SetActive(true);
            dancePartner1.GetComponent<Animator>().enabled = true;
            dancePartner1.transform.rotation = Quaternion.Euler(0, 180f, 0);
            music1.Play();
        }
        else
        {
            dancePartner2.SetActive(true);
            dancePartner2.GetComponent<Animator>().enabled = true;
            dancePartner2.transform.rotation = Quaternion.Euler(0, 180f, 0);
            music2.Play();
        }
    }

    void EndDance()
    {
        isDancing = false;
        music1.Stop();
        music2.Stop();
        backgroundMusic.Play();

        if (selectedDance == 0)
        {
            dancePartner1.GetComponent<Animator>().enabled = false;
        }
        else
        {
            dancePartner2.GetComponent<Animator>().enabled = false;
        }

        float finalScore = judge.GetScorePercentage();
        Debug.Log("Final Score %: " + finalScore);

        if (resultText != null)
        {
            string rating = GetRating(finalScore);
            string scoreText = "Score: " + Mathf.RoundToInt(finalScore * 100f) + "%";

            if (rating == "Try Again")
            {
                resultText.text = rating + "!\n" + scoreText;
            }
            else
            {
                resultText.text = "You are " + rating + "!\n" + scoreText;
            }
        }
        else
        {
            Debug.LogWarning("Result Text is not assigned.");
        }

        if (resultPanel != null)
        {
            resultPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Result Panel is not assigned.");
        }

        applauseSound.Play();
    }

    string GetRating(float score)
    {
        if (score > 0.6f) return "Perfect";
        if (score > 0.45f) return "Great";
        if (score > 0.25f) return "Good";
        return "Try Again";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
