using UnityEngine;
using System.Linq;


public class JsonNetDataContoller: MonoBehaviour  {

    
    public TextAsset JsonData;
    public NetData NetData;


    private void Awake() {
        NetData = JsonUtility.FromJson<NetData>(JsonData.text);
    }

    // Get required time by panel id
    public int GetRequiredTime(int panel_id) {
        var items = NetData.sessions.Where(i => i.id == panel_id);
        foreach(var item in items) {
            return item.required_time;
        }
        return 0;
    }

    // Get outcome quantity by panel id
    public int GetOutcomeQuantity(int panel_id) {
        var items = NetData.sessions.Where(i => i.id == panel_id);
        foreach (var item in items) {
            var invest = item.outcome;
            foreach(var inv in invest) {
                return inv.quantity;
            }
        }
        return 0;
    }

 
}