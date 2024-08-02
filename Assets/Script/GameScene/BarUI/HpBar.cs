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
        Sethpslider();
        Settext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //최대 체력에 따라 길이 설정
    public void Sethpbar(){
        RectTransform rectTransform = gameObject.transform.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(maxhp*2, rectTransform.sizeDelta.y);
    }

    //hp비율 반환
    public float SetHp(){
        if(maxhp<=0&&curhp>=maxhp){
            return 0;
        }else{
            return (float)curhp/(float)maxhp;
        }
    }

    //피 비율에 따라 슬라이더 설정하기
    public void Sethpslider(){
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
