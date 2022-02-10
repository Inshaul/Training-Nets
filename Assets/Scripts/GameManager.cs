using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour{
    public Button nets;
    
    public GameObject t_text;
    public GameObject main_menu;
    public GameObject dark_bgImage;
    public Button cross;
    public GameObject bg_UI;
    public GameObject finishTraining;
    public Transform bg_UI_posi;
    public GameObject scroll_menu;
    public Button potential;
   
    public int flag1 = 0;
    public int flag2 = 0;

    public GameObject shortDrill;
    public GameObject parentDrill;

    public Button FinishButton;
    private int i=2;

    private void Awake() {

        scroll_menu.SetActive(false);
        finishTraining.SetActive(false);
        dark_bgImage.SetActive(false);
        bg_UI.SetActive(true);
        t_text.SetActive(true);
        bg_UI_posi.localPosition = new Vector2(0, -5000);
        potential.onClick.AddListener(CloseUI);
        
        cross.onClick.AddListener(CloseUI);
        nets.onClick.AddListener(OpenSlider);
        FinishButton.onClick.AddListener(EndTraining);
        

    }
    private void Update() {
        if (finishTraining.active == true ) {
            if (flag2 == 1) {
                scroll_menu.SetActive(false);
            }
           
        }
        if (finishTraining.active == false ) {
            if (flag2 == 1) {
                scroll_menu.SetActive(true);
            }
            
        }

        CheckEnabled();
    }

    public void CheckEnabled() {
        if (parentDrill.active == true) {
            SpawnDrill();
        }
    }

    public void SpawnDrill() {
        for(; i <= 5; i++) {
            if(i==3 || i == 4) {
                continue;
            }
            GameObject obj = Instantiate(shortDrill, parentDrill.transform);
            NetPanel net = obj.GetComponent<NetPanel>();
            net.RenderPanel(i);
        }
    }


    public void EndTraining() {

        finishTraining.SetActive(false);
   
        flag1 = 0;

        t_text.SetActive(true);
        scroll_menu.SetActive(true);

    } 


    public void CloseUI() {

        dark_bgImage.SetActive(false);
        MoveOut();
        main_menu.SetActive(true);
    }

    public void OpenSlider() {

        main_menu.SetActive(false);
        dark_bgImage.SetActive(true);
        Move();

        if(flag1==0) {
            scroll_menu.SetActive(true);
            finishTraining.SetActive(false);
        }
    }
    public void Move() {
        scroll_menu.SetActive(true);
        bg_UI_posi.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutExpo);
        flag2 = 1;
    }
    public void MoveOut() {

        bg_UI_posi.DOLocalMoveY(-5000, 0.5f).SetEase(Ease.InExpo);
    }
}
