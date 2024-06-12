using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //Karakter collider'ý olan finish line'a temas ettiðinde 
    {
        if (collision.tag == "Player") //Temas eden tag Player ise
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Aktif olan sahneye 1 ekle ve diðer build indexi sahneye getir.  
        }
    }
}
