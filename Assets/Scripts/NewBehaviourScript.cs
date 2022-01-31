using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class NewBehaviourScript : MonoBehaviour{
    public Button nets;
    
    public GameObject t_text;
    public GameObject main_menu;
    public GameObject dark_bgImage;
    public Button cross;
    public GameObject bg_UI;
    public GameObject ft1;
    public GameObject ft2;
    public GameObject ft3;
    public Transform bg_UI_posi;
    public GameObject scroll_menu;
    public Button ui1;
    public Button ui2;
    public Button ui3;
    public Button ui4;
    public int flag1 = 0;
    public int flag2 = 0;
    public int flag3 = 0;
    public Button Fb1;
    public Button Fb2;
    public Button Fb3;

    private void Awake() {

        dark_bgImage.SetActive(false);
        bg_UI.SetActive(true);
        t_text.SetActive(true);
        bg_UI_posi.localPosition = new Vector2(0, -5000);
        ui1.onClick.AddListener(CloseUI);
        ui2.onClick.AddListener(FinishTraining_1);
        ui3.onClick.AddListener(FinishTraining_2);
        ui4.onClick.AddListener(FinishTraining_3);
        cross.onClick.AddListener(CloseUI);
        nets.onClick.AddListener(OpenSlider);
        Fb1.onClick.AddListener(EndTraining);
        Fb2.onClick.AddListener(EndTraining);
        Fb3.onClick.AddListener(EndTraining);

    }

    public void EndTraining() {

        ft1.SetActive(false);
        ft2.SetActive(false);
        ft3.SetActive(false);
        flag1 = 0;
        flag2 = 0;
        flag3 = 0;
        t_text.SetActive(true);
        scroll_menu.SetActive(true);

    } 
    public void FinishTraining_1() {

        t_text.SetActive(false);
        scroll_menu.SetActive(false);
        ft1.SetActive(true);
        flag1 = 1;

    }
    public void FinishTraining_2() {

        t_text.SetActive(false);
        scroll_menu.SetActive(false);
        ft2.SetActive(true);
        flag2 = 1;

    }
    public void FinishTraining_3() {

        t_text.SetActive(false);
        scroll_menu.SetActive(false);
        ft3.SetActive(true);
        flag3 = 1;

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

        if(flag1==0 && (flag2==0 && flag3==0)) {
            scroll_menu.SetActive(true);
        }

        if (flag1 == 0) {
            ft1.SetActive(false);
        }
        if (flag2 == 0) {
            ft2.SetActive(false);
        }
        if (flag3 == 0) {
            ft3.SetActive(false);
        }   

    }
    public void Move() {

        bg_UI_posi.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutExpo);
    }
    public void MoveOut() {

        bg_UI_posi.DOLocalMoveY(-5000, 0.5f).SetEase(Ease.InExpo);
    }
}
