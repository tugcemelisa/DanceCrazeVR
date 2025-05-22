using UnityEngine;

public class AvatarSelector : MonoBehaviour
{
    public GameObject[] avatars;
    private int currentAvatarIndex = 0;

    void Start()
    {
        UpdateAvatar();
    }

    public void NextAvatar()
    {
        avatars[currentAvatarIndex].SetActive(false);
        currentAvatarIndex = (currentAvatarIndex + 1) % avatars.Length;
        avatars[currentAvatarIndex].SetActive(true);
    }

    public void PreviousAvatar()
    {
        avatars[currentAvatarIndex].SetActive(false);
        currentAvatarIndex = (currentAvatarIndex - 1 + avatars.Length) % avatars.Length;
        avatars[currentAvatarIndex].SetActive(true);
    }

    void UpdateAvatar()
    {
        for (int i = 0; i < avatars.Length; i++)
        {
            avatars[i].SetActive(i == currentAvatarIndex);
        }
    }
}
