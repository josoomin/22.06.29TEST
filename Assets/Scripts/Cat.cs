using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCat
{
    public class Cat : MonoBehaviour
    {
        public AudioSource audioSource;

        void Start()
        {
            float time = Random.Range(3.0f, 10.0f);
            Invoke("CatSound", time);
        }

        void Update()
        {
            
        }

        void CatSound()
        {
            audioSource.Play();
            Debug.Log("야옹");
        }
    }
}
