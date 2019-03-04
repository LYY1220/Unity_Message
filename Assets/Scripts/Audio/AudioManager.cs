using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : ManagerBase {

    public const int PLAY_AUDIO = 0;
    public static AudioManager Instance = null;
    private void Awake()
    {
        Instance = this;

    }
}
