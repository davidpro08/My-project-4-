using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    //최대 체력
    public int maxhp;
    //현재 체력
    public int curhp;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        Sethpbar();
        Settext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //hp비율 반환
    public float SetHp(){
        return (float)curhp/(float)maxhp;
    }

    //피 비율에 따라 슬라이더 설정하기
    public void Sethpbar(){
        Slider slider = GetComponent<Slider>();
        slider.value = SetHp();
    }

    //텍스트 설정하기
    public void Settext(){
        string hptext = "";
        hptext += curhp.ToString();
        hptext += " / ";
        hptext += maxhp.ToString();

        text.transform.GetComponent<TextMeshProUGUI>().text = hptext;
    }
}
