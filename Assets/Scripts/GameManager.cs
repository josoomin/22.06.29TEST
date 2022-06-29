using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyCat
{


    public class GameManager : MonoBehaviour
    {
        public Text _nowTimeText;
        public GameObject button;
        public GameObject _ShopUI;

        void Start()
        {

        }

        void Update()
        {
            //현재시간 표시(계속 업데이트 되도록)
            DateTime dt = DateTime.Now;
            //_nowTimeText.text = dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)");
            _nowTimeText.text = string.Format("{0: yyyy년 M월 d일 HH:mm:ss (dddd)}", dt);

        }

        public void OnClickShopButton()
        {
            _ShopUI.SetActive(true);
        }

    }
}
