using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    [SerializeField] string nomeDaCena;

   public void MudarCena()
   {
        SceneManager.LoadScene(nomeDaCena);
   }

   public void CreditoCena()
   {
       SceneManager.LoadScene(nomeDaCena);
   }

   public void MenuCena()
   {
       SceneManager.LoadScene(nomeDaCena);
   }

   public void SairCena()
   {
       Debug.Log("O jogo saiu");
       Application.Quit();
   }
}
