using UnityEngine;

public class DanceJudge : MonoBehaviour
{
    public Transform[] playerBones;
    public Transform[] partnerBones;

    private float totalScore = 0f;
    private int frameCount = 0;

    void Update()
    {
        if (playerBones.Length != partnerBones.Length) return;

        float frameScore = 0f;
        for (int i = 0; i < playerBones.Length; i++)
        {
            float distance = Vector3.Distance(playerBones[i].position, partnerBones[i].position);
            frameScore += Mathf.Clamp01(1f - distance);
        }

        totalScore += frameScore / playerBones.Length;
        frameCount++;
    }

    public float GetScorePercentage()
    {
        if (frameCount == 0) return 0f;
        return totalScore / frameCount;
    }

    public void ResetScore()
    {
        totalScore = 0f;
        frameCount = 0;
    }
}
