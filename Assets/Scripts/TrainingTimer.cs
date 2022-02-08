using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TrainingTimer : MonoBehaviour {

    public JsonNetDataContoller jsonNetDataContoller;

    public  Image busyPannelSlider;
   
    public  TextMeshProUGUI BusyPopUpTimer;

    private float RemainingTime;
    private bool TimerStarted;
    private int currentNetId;
    private float Totaltime = 5f;
    private void Start() {
        GameEventSystem.GameEventHandler += HandleGameEvents;
       
    }
    private void HandleGameEvents(EVENT_TYPE type, System.Object data = null) {
        if(type == EVENT_TYPE.START_TIMER) {
            SetTimer(data);
        }
    }

    private void Update() {
        if (TimerStarted) {
            Timer();
        }
    }

    private void Timer() {
        if (RemainingTime > 0) {  
            StartTimer();
            
        } else {
            
            TimerStarted = false;
        }
    }

    private void StartTimer() {
        RemainingTime -= Time.deltaTime;
        busyPannelSlider.fillAmount = 1 - (RemainingTime / Totaltime);   
        FormatText();
    }
    private void SetTimer(object time) {
        currentNetId = (int)time;
        RemainingTime = jsonNetDataContoller.GetRequiredTime(currentNetId);
        
        Totaltime = RemainingTime;
        Debug.Log("SetTimer: "+ RemainingTime);
        TimerStarted = true;
       
    }

    
    private void FormatText() {
        int days = (int) (RemainingTime / 86400) % 365;
        int hours = (int) (RemainingTime / 3600) % 24;
        int minutes = (int) (RemainingTime / 60) % 60;
        int seconds = (int) (RemainingTime % 60);
        BusyPopUpTimer.text = "";
       
        if (days > 0) {
            BusyPopUpTimer.text += days + "d ";
            
        }
        if(hours > 0) {
            BusyPopUpTimer.text += hours + "h ";
            
        }
        if (minutes > 0) {
            BusyPopUpTimer.text += minutes + "m ";
            
        }
        if (seconds > 0) {
            BusyPopUpTimer.text += seconds + "s ";
            
        }
    }
}
