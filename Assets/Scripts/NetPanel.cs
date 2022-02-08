using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetPanel : MonoBehaviour {
    public Sprite bgImage, bgIcon;
    public TextMeshProUGUI tpAmount, xpAmount, extraTpAmount, trainButtonLabel, timeRequired, titleText;
    public GameObject training_text;
    public TextMeshProUGUI cashCost;
    public Button trainButton;
    public GameObject FinishTraining;


    public NetsBusyPanel netsBusyPanel;

    public int current_nets_id;

    private void Awake() {
        trainButton.onClick.AddListener(TrainButtonPressed);
        
    }

    public void TrainButtonPressed() {
        FinishTraining.SetActive(true);
        training_text.SetActive(false);
        
        GameEventSystem.RaiseGameEvent(EVENT_TYPE.NETS_UPDATE);
        GameEventSystem.RaiseGameEvent(EVENT_TYPE.START_TIMER, current_nets_id);
        netsBusyPanel.RenderBusyPanel(bgIcon, bgImage, extraTpAmount, xpAmount, current_nets_id);
    }


}
