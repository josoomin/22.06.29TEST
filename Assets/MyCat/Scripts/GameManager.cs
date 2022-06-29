using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyCat
{
    public class GameManager : MonoBehaviour
    {
        public GameObject _coin;
        public GameObject _heart;

        public GameObject _worldObj;
        public GameObject _canvasObj;
        public Text _nowTimeText;
        public Text _coinTxt;
        public Text _heartTxt;

        public int _coincount;
        public int _heartcount;

        GameObject _dish;

        void Start()
        {
            //복사할 원본(템플릿)은 꺼주기
            _heart.SetActive(false);
            _coin.SetActive(false);

            _dish = _worldObj.transform.Find("CatDish").gameObject;
            _dish.SetActive(false);

            _heartTxt = _canvasObj.transform.Find("Heart interface").Find("heart_Txt").GetComponent<Text>();
            _coinTxt = _canvasObj.transform.Find("Coin interface").Find("coin_Txt").GetComponent<Text>();
        }

        public void AddCoin(int count)
        {
            _coincount += count;
            _coinTxt.text = _coincount.ToString("D4");
        }   
        public void AddHeart(int count)
        {
            _heartcount += count;
            _heartTxt.text = _heartcount.ToString("D4");
        }

        void Update()
        {
            //현재시간 표시(계속 업데이트 되도록)
            DateTime dt = DateTime.Now;
            //_nowTimeText.text = dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)");
            _nowTimeText.text = string.Format("{0: yyyy년 M월 d일 HH:mm:ss (dddd)}",dt);
        }

        //밥주기 버튼
        public void OnClick_Food()
        {
            _dish.SetActive(true);
        }

        public void OnFinish_Eat()
        {
            _dish.SetActive(false);
        }

        public void Dropcoin()
        {
            GameObject clonedObj = Instantiate(_coin);
            clonedObj.SetActive(true);
        }
        public void Dropheart(Transform target)
        {
            GameObject clonedObj = Instantiate(_heart);
            clonedObj.SetActive(true);

            //최대 1.0(0.1 + 0.9)반경 최소 0.1반경 안의 랜덤 위치
            float deltaRandius = 1.0f;
            float minRadius = 0.1f;
            Vector2 circleRange = UnityEngine.Random.insideUnitCircle * deltaRandius;

            Vector2 normalVector = circleRange.normalized;

            Vector2 randomPos = circleRange - normalVector * minRadius;

            clonedObj.transform.position = target.position + new Vector3(circleRange.x, circleRange.y);
            clonedObj.gameObject.name = "Heart";
        }
    }
}