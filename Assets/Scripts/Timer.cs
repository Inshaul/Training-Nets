using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour{
    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    public float gameTime;
    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    private bool stopTimer;
    public NewBehaviourScript nbs;
    
    
    private void Start() {

        Dostuff();
        
    }

    private void Dostuff() {
        if (f1.activeInHierarchy == true || f2.activeInHierarchy == true || f3.activeInHierarchy == true) {
            stopTimer = false;
            timerSlider.maxValue = gameTime;
            timerSlider.value = gameTime;
        }
        
    }

    private void Update() {

        if(f1.activeInHierarchy == true || f2.activeInHierarchy == true || f3.activeInHierarchy == true) {
            float time = gameTime - Time.time;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);
            string textTime = string.Format("{0:0}m {1:00}s", minutes, seconds);
            if (time <= 0) {
                stopTimer = true;
                if (nbs.ft1.activeInHierarchy == true) {

                    nbs.flag1 = 0;
                    nbs.scroll_menu.SetActive(true);
                    nbs.t_text.SetActive(true);
                    nbs.ft1.SetActive(false);
                }
                if (nbs.ft2.activeInHierarchy == true) {

                    nbs.flag2 = 0;
                    nbs.scroll_menu.SetActive(true);
                    nbs.t_text.SetActive(true);
                    nbs.ft2.SetActive(false);
                }
                if (nbs.ft3.activeInHierarchy == true) {

                    nbs.flag3 = 0;
                    nbs.scroll_menu.SetActive(true);
                    nbs.t_text.SetActive(true);
                    nbs.ft3.SetActive(false);
                }
            }
            if (stopTimer == false) {
                timerText.text = textTime;
                timerSlider.value = time;
            }
        } 
        else {
            Dostuff();
        }
        
    }

    
}
