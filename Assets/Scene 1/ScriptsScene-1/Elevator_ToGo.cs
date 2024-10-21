using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_ToGo : MonoBehaviour
{   public GameObject One_buttonIn;
    public GameObject One_buttonOut;
    public GameObject Two_buttonIn;
    public GameObject Two_buttonOut;
    public GameObject Four_buttonIn;
    public GameObject Four_buttonOut;
    public GameObject SceneWantGo1flr1;
    public GameObject SceneWantGo1flr2;
    public GameObject SceneWantGo2flr1;
    public GameObject SceneWantGo2flr2;
    public GameObject SceneWantGo4flr1;
    public GameObject SceneWantGo4flr2;
    public GameObject SceneWantOut;
    public GameObject SceneWantOut2;

    public GameObject Lift_Bell;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Use_Lift(int flr)
    {   if ( flr ==1)
        {
            if (Two_buttonIn != null) Two_buttonIn.SetActive(false);
            if (Two_buttonOut != null) Two_buttonOut.SetActive(false);
            if (Four_buttonIn != null) Four_buttonIn.SetActive(false);
            if (Four_buttonOut != null) Four_buttonOut.SetActive(false);

            StartCoroutine(Lift1());
        }

        else if (flr == 2 || flr == 3)
        {
            
            if (Four_buttonIn != null) Four_buttonIn.SetActive(false);
            if (Four_buttonOut != null) Four_buttonOut.SetActive(false);
            if (Two_buttonIn != null) Two_buttonIn.SetActive(true);
            if (Two_buttonOut != null) Two_buttonOut.SetActive(true);
            StartCoroutine(Lift2());
           
        }
        else if (flr == 4)
        {
            if (Two_buttonIn != null) Two_buttonIn.SetActive(false);
            if (Two_buttonOut != null) Two_buttonOut.SetActive(false);
            if (Four_buttonIn != null) Four_buttonIn.SetActive(true);
            if (Four_buttonOut != null) Four_buttonOut.SetActive(true);
            StartCoroutine(Lift4());
        }
        IEnumerator Lift1()
        {
            StartCoroutine(Lift_Bell_Set());
            yield return new WaitForSeconds(2);
            
            if (SceneWantOut != null) SceneWantOut.SetActive(false);
            if (SceneWantOut2 != null) SceneWantOut2.SetActive(false);
            if (Two_buttonIn != null) Two_buttonIn.SetActive(false);
            if (Two_buttonOut != null) Two_buttonOut.SetActive(false);
            if (Four_buttonIn != null) Four_buttonIn.SetActive(false);
            if (Four_buttonOut != null) Four_buttonOut.SetActive(false);
            if (SceneWantGo1flr1 != null) SceneWantGo1flr1.SetActive(true);
            if (SceneWantGo1flr2 != null) SceneWantGo1flr2.SetActive(true);
        }
            IEnumerator Lift2()
        {
            StartCoroutine(Lift_Bell_Set());
            yield return new WaitForSeconds(2);
           
            if (SceneWantOut != null) SceneWantOut.SetActive(false);
            if (SceneWantOut2 != null) SceneWantOut2.SetActive(false);
            if (Two_buttonIn != null) Two_buttonIn.SetActive(false);
            if (Two_buttonOut != null) Two_buttonOut.SetActive(false);
            if (SceneWantGo2flr1 != null) SceneWantGo2flr1.SetActive(true);
            if (SceneWantGo2flr2 != null) SceneWantGo2flr2.SetActive(true);
        }
        IEnumerator Lift4()
        {
            StartCoroutine(Lift_Bell_Set());
            yield return new WaitForSeconds(2);
          
            if (SceneWantOut != null) SceneWantOut.SetActive(false);
            if (SceneWantOut2 != null) SceneWantOut2.SetActive(false);
            if (Four_buttonIn != null) Four_buttonIn.SetActive(false);
            if (Four_buttonOut != null) Four_buttonOut.SetActive(false);
            if (SceneWantGo4flr1 != null) SceneWantGo4flr1.SetActive(true);
            if (SceneWantGo4flr2 != null) SceneWantGo4flr2.SetActive(true);
        }
        IEnumerator Lift_Bell_Set()
        {
            yield return new WaitForSeconds(0.7f);
            Lift_Bell.SetActive(true);
            yield return new WaitForSeconds(2);
            Lift_Bell.SetActive(false);
        }
    }
}
