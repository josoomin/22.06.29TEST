using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemItem : MonoBehaviour
{
    public Text _nameTxt;
    public Image _itemIcon;
    public Text _priceTxt;


    private void Start()
    {
        _nameTxt = transform.Find("name").GetComponent<Text>();
        _itemIcon = transform.Find("sprite").GetComponent<Image>();
        _priceTxt = transform.Find("price").GetComponent<Text>();
    }

    public void SetData(GameData_ShopList data)
    {
        // 데이터를 받아서 실제 그 데이터로
        // 각종 표시를 한다.

        // 미션 이름
        _nameTxt.text = data.name;

        // 아이템 아이콘
        _itemIcon.sprite = data.item_icon_sp;

        // 가격
        _priceTxt.text = data.price.ToString();
    }
}

