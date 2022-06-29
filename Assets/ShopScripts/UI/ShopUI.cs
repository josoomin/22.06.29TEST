using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameData _gameData;

    public List<ShopItemItem> _itemList;

    void Start()
    {
        ShopItemItem[] array = GetComponentsInChildren<ShopItemItem>();
        //List에 여러개(배열)를 집어넣을 때는 AddRange 함수 쓴다.
        _itemList.AddRange(array);

        List<GameData_ShopList> missionDataList = _gameData._shop_item_data;

        for (int i = 0; i < _itemList.Count; i++)
        {
            GameData_ShopList data = missionDataList[i];
            ShopItemItem item = _itemList[i];
            item.SetData(data);  // 일일미션데이터를 각 항목(item)에 넣어준다.
        }
    }

    void Update()
    {

    }
}