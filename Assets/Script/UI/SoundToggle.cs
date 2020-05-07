using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    void Awake()
    {
        // GetComponentInChildren<Toggle>().isOn = Storage.mutedSound;
    }

    public void ToggleSoundMuted(bool v)
    {
        Storage.mutedSound = v;
    }
}
