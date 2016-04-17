// Date   : 17.04.2016 02:08
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    public static MusicManager main;

    [SerializeField]
    private AudioSource theme;

    [SerializeField]
    [Range(0.2f, 1f)]
    private float pausePitch = 0.5f;

    [SerializeField]
    [Range(1f, 1.5f)]
    private float successPitch = 1.2f;

    [SerializeField]
    [Range(0.5f, 2.5f)]
    private float mainMenuPitch = 0.8f;

    private float originalPitch = 1f;

    private bool pitchHasChanged = false;

    private bool changingPitch = false;
    private float targetPitch;
    
    [SerializeField]
    [Range(0.05f, 5f)]
    private float pitchSmooth = 0.2f;

    void Awake()
    {
        main = this;
    }

    void Start()
    {
        originalPitch = theme.pitch;
        theme.pitch = mainMenuPitch;
    }

    public void StartGame()
    {
        pitchHasChanged = true;
    }

    void Update()
    {
        if (Time.timeScale == 0f && !pitchHasChanged)
        {
            
            if (GameManager.main.WaitForNextLevelConfirmation)
            {
                changingPitch = true;
                targetPitch = successPitch;
                pitchHasChanged = true;
            }
            else if (GameManager.main.WaitForPauseMenuConfirm)
            {
                changingPitch = true;
                targetPitch = pausePitch;
                pitchHasChanged = true;
            }
        }
        else if (Time.timeScale == 1f && pitchHasChanged)
        {
            changingPitch = true;
            targetPitch = originalPitch;
            pitchHasChanged = false;
        }

        if (changingPitch)
        {
            theme.pitch = Mathf.Lerp(theme.pitch, targetPitch, Time.unscaledDeltaTime * pitchSmooth);
            if (Mathf.Abs(theme.pitch - targetPitch) < 0.005f)
            {
                theme.pitch = targetPitch;
                changingPitch = false;
            }
        }
    }
}
