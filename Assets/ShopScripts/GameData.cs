using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameData : MonoBehaviour
{
    // 상점 아이템 데이터
    public TextAsset _shop_item_csv;
    public List<GameData_ShopList> _shop_item_data;

    void Start()
    {
        Init_ShopItemData();
    }

    void Init_ShopItemData()
    {
        _shop_item_csv = Resources.Load<TextAsset>("GameData/shop_item"); //리소스 폴더 안에 GameData폴더 안에 있는 엑셀의 데이터를 가져온다.

        _shop_item_data = new List<GameData_ShopList>(); //

        string text = _shop_item_csv.text;
        using (StringReader reader = new StringReader(text))
        {
            string line = reader.ReadLine(); // 첫번째줄은 읽고 쓰지 않는다(컬럼 이름들이므로)
            if (line != null)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    // csv 값이므로, ',' seperator로 데이터들을 분리해서 저장
                    string[] record = line.Split(',');

                    Debug.Assert(record.Length == 4);

                    GameData_ShopList temp = new GameData_ShopList();
                    temp.id = Convert.ToInt32(record[0]);
                    temp.name = record[1];
                    temp.price = Convert.ToInt32(record[2]);
                    temp.item_icon = record[3];

                    Sprite[] spList = Resources.LoadAll<Sprite>("spritesheet_48x48");
                    for (int i = 0; i < spList.Length; i++) // 배열의 갯수(Length)만큼 반복
                    {
                        Sprite sp = spList[i];
                        if (sp.name == temp.item_icon)
                        {
                            temp.item_icon_sp = sp;
                            break;
                        }
                    }

                    // List에 하나를 집어넣을 때는 Add 함수 쓴다
                    _shop_item_data.Add(temp);
                }
            }
        }
    }

    void Update()
    {

    }
}

