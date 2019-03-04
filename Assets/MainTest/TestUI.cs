using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : UIBase {

    [SerializeField]
    private Button btn;
    [SerializeField]
    private Text txt;

    private void Start()
    {
        btn.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        //发送消息的人
        txt.text += "1";
        Dispatch(AreaCode.AUDIO, AudioEvent.PLAY_AUDIO, "audio1");
    }
}
