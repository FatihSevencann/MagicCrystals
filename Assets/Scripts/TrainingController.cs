using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrainingController : MonoBehaviour
{
 
public static int clickCount=0;
  

  public void trainingText(Text text ){

      clickCount++;
      switch(clickCount){

          case 1:
          text.text=" \n YÖN TUŞLARIYLA KRİSTALLERİ HAREKET ETTİREBİLİRSİN ";
          break;

          case 2:
           text.text="\nKRİSTALLERİ BİRLEŞTİREREK DAHA DEĞERLİ BİR KRİSTAL ELDE ETMELİSİN ";
          break;
            
            
           case 3:
           text.text=" AYNI İKİ KRİSTAL YANYANA GELDİYSE HAREKET ETTİREREK KRİSTALİ BİRLEŞTİR VE DAHA DEĞERLİ BİR KRİSTAL ELDE ET";
          break;

          case 4:
           text.text="\nBİR SONRAKİ SEVİYEYE GEÇMEN İÇİN SENDEN İSTEYECEĞİM KRİSTALLERİ BANA GETİRMEN GEREK";
          break;

          case 5:
           text.text="\n ELİNİ ÇABUK TUT AMAN SÜRE BİTMESİN :)";
          break;

          case 6:
           text.text="KRİSTALLERİ DÖNÜŞTÜRÜRKEN DİKKATLİ OL EĞER BOŞTA KUTU KALMAZ VE HAREKET EDEMEZ İSEN ELENİRSİN :( ";
          break;

          case 7:
          text.text="\nKRİSTALLERİ DÖNÜŞTÜREREK HEDEFE ULAŞMAYA HAZIR MISIN ?";
          break;

          case 8:
          text.text="\nO ZAMAN MACERA BAŞLASIN :) ";
          break;


          case 9:
          SceneManager.LoadScene(2);
          break;
          

      }

  }  
}


