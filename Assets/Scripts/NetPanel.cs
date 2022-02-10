using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class NetPanel : MonoBehaviour {
    public Sprite bgImage, bgIcon;
    public TextMeshProUGUI tpAmount, xpAmount, extraTpAmount, trainButtonLabel, timeRequired, titleText;
    public GameObject training_text;
    public TextMeshProUGUI cashCost,drillText;
    public Button trainButton;
    public GameObject FinishTraining;
    public JsonNetDataContoller jsonNetDataContoller;
    public List<Sprite> list = new List<Sprite>();
    public GameObject icon_new;
    public NetsBusyPanel netsBusyPanel;
    
    private int current_nets_id=1;

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
    
    public void RenderPanel(int panel_id) {
        GetjsonData(panel_id);
        current_nets_id = panel_id;
        var img = icon_new.GetComponent<Image>();
        if (panel_id == 2) {
            img.sprite = list[1];
        }
        if (panel_id == 5) {
            img.sprite = list[2];
        }
    }

    public void GetjsonData(int panel_id) {
        drillText.text = jsonNetDataContoller.GetRequiredTitle(panel_id).ToString();
        tpAmount.text = "+" + jsonNetDataContoller.GetOutcomeQuantity(panel_id).ToString();
        if (panel_id == 2) {
            this.bgIcon = list[1];
            xpAmount.text = "+" + 10;
            cashCost.text = 800.ToString();
            timeRequired.text = "5" + " Minutes";
        }
        if (panel_id == 5) {
            xpAmount.text = "+" + 30;
            cashCost.text = "1"+"k";
            timeRequired.text = "1" + " Hour";
            this.bgIcon = list[2];
        }
    }

}
