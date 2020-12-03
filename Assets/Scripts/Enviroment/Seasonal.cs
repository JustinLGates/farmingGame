using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasonal : MonoBehaviour
{
    protected string season;
    [SerializeField]
    GameObject springSummer, fall, winter;

    List<GameObject> seasonalObjects = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 Pos = transform.position;
        Quaternion Rot = transform.rotation;
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        sr.forceRenderingOff = true;
        springSummer = Instantiate(springSummer,Pos,Rot);
        fall = Instantiate(fall,Pos,Rot);
        winter = Instantiate(winter,Pos,Rot);
        DisableAll();
        winter.SetActive(true);
    }

    private void OnEnable() 
    {
        Calendar.SeasonChangeSpring += changeSeasonSpring;
        Calendar.SeasonChangeSummer += changeSeasonSummer;
        Calendar.SeasonChangeFall += changeSeasonFall;    
        Calendar.SeasonChangeWinter += changeSeasonWinter;
    }                                                     
                                                          
    private void OnDisable()                              
    {                                                     
        Calendar.SeasonChangeSpring -= changeSeasonSpring;
        Calendar.SeasonChangeSummer -= changeSeasonSummer;
        Calendar.SeasonChangeFall -= changeSeasonFall;
        Calendar.SeasonChangeWinter -= changeSeasonWinter;
    }

    private void changeSeasonSpring()
    {
        DisableAll();
        springSummer.SetActive(true);
    }
    private void changeSeasonSummer()
    {
        DisableAll();
        springSummer.SetActive(true);
    }
    private void changeSeasonFall()
    {
        DisableAll();
        fall.SetActive(true);
    }
    private void changeSeasonWinter()
    {
        DisableAll();
        winter.SetActive(true);
    }

    private void DisableAll()
    {
        springSummer.SetActive(false);
        fall.SetActive(false);
        winter.SetActive(false);
    }
    
}
