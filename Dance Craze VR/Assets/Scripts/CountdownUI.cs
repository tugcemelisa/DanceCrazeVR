using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownUI : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject countdownPanel;
    public DanceManager danceManager;

    public void StartCountdown(int danceIndex)
    {
        StartCoroutine(CountdownCoroutine(danceIndex));
    }

    IEnumerator CountdownCoroutine(int danceIndex)
    {
        countdownPanel.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        countdownText.text = "Dance!";
        yield return new WaitForSeconds(0.5f);

        countdownPanel.SetActive(false);
        danceManager.StartDance(danceIndex);
    }
}
