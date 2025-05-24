using UnityEngine;

public class DanceJudge : MonoBehaviour
{
    public Transform[] playerBones;
    public Transform[] partnerBones;

    private float totalScore = 0f;
    private int frameCount = 0;

    void Update()
    {
        if (playerBones.Length != partnerBones.Length)
        {
            Debug.LogWarning("Bone array lengths do not match!");
            return;
        }

        float frameScore = 0f;
        for (int i = 0; i < playerBones.Length; i++)
        {
            Vector3 playerDir = playerBones[i].forward;
            Vector3 partnerDir = partnerBones[i].forward;

            float angleDiff = Vector3.Angle(playerDir, partnerDir);
            float alignmentScore = Mathf.Clamp01(1f - angleDiff / 120f); 
            frameScore += alignmentScore;
        }

        float averageFrameScore = frameScore / playerBones.Length;
        totalScore += averageFrameScore;
        frameCount++;

        Debug.Log("Current Frame Score: " + averageFrameScore);
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