using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// F�r att anv�nda UI-delar i Unity m�ste vi inkludera UnityEngine.UI
using UnityEngine.UI;

public class ProgressionBarExample : GameManager
{
    // Dessa variabler �r referenser till RectTransforms (position och storlek f�r UI element). Just dessa tv�
    // motsvarar d� bakgrunden f�r "progression" och den andra �r punkten som f�rflyttar sig �ver bakgrunden.
    // SerializeField g�r d� variablen synlig i Unity Editor.
    [SerializeField] RectTransform backgroundBar;
    [SerializeField] RectTransform currentProgression;

    List<Transform> levelCheckpoints;

    // Denna raden g�r variablen synlig i editor (SerializeField) och Range s�ger vilka v�rden vi godk�nner 
    // Variablen �r mellan. I detta l�get s� kan progressionValue bara vara mellan 0 och 100.
    [SerializeField][Range(0, 100)] float progressionValue;
    public Transform Player;
    public Transform length;

    void Update()
    {
        // Omvandla progressionen till 0-1 (att multiplicera med 0 inneb�r l�ngst till v�nster, 1 l�ngst till h�ger)
       // int PointCount = levelCheckpoints.Count;

        
        
        float progressAsDecimal = progressionValue/100f;
        if (procent > 0)
        progressAsDecimal = procent % 1;
        

       float position = (backgroundBar.rect.width - currentProgression.rect.width ) * progressAsDecimal;

        // Denna metoden f�rflyttar currentProgression (den r�da kuben) position �r f�rflyttningen l�ngs progression-baren.
      currentProgression.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, position, currentProgression.rect.width);
    }
}
