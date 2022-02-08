using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NetsBusyPanel : MonoBehaviour {

	public JsonNetDataContoller jsonNetDataContoller;

	public Image bg_instant, bg_icon, icon_instant;
	public TextMeshProUGUI instant_amount, speedup_amount, extra_tp, tp_amount, xp_amount, TimeRemaining;
	
	public Button instant_button, speedup_button;
	int panel_id = 0;


    private void GetFromJson() {
		tp_amount.text = "+"+jsonNetDataContoller.GetOutcomeQuantity(panel_id).ToString();
		TimeRemaining.text = jsonNetDataContoller.GetRequiredTime(panel_id).ToString();
		
		Debug.Log(tp_amount.text);
		Debug.Log(TimeRemaining.text);
    }

    public void RenderBusyPanel(Sprite bg_icon, Sprite bg, TextMeshProUGUI extraTp, TextMeshProUGUI xpAmount, int panel_id) {
		this.bg_icon.sprite = bg_icon;
		this.bg_instant.sprite = bg;
		this.panel_id = panel_id;
        if (panel_id == 2) {
			xp_amount.text = "+" + 10;
			extra_tp.text = "+" + 20;
			instant_amount.text = "2";
		}
        if (panel_id == 5) {
			xp_amount.text = "+" + 30;
			extra_tp.text = "+" + 160;
			instant_amount.text = "19";
        }
		GetFromJson();

	}

}