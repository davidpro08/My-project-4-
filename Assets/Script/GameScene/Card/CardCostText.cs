using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardCostText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextUp(){
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.SetAsFirstSibling();
    }
}
