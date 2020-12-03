using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    float gameTime;
    int season;
    int days;
    int gameHour;
    int gameMinute;
    string seasonString;
    [SerializeField]
    Text dateText;
    
    // Start is called before the first frame update
    void Start()
    {
        gameTime = 80000;
        season = 1;
        days = 30;
        gameHour = 0;
        gameMinute = 0;
        SetSeason();
        // TODO get time of day from save.
    }

    public static event Action SeasonChangeSpring;
    public static event Action SeasonChangeSummer;
    public static event Action SeasonChangeFall;
    public static event Action SeasonChangeWinter;


    // Updates game time and UI display.
    void FixedUpdate()
    {
        gameTime += Time.deltaTime * 500;

        // changes days and seasons.
        if (gameTime >= 86000)
        {
            UpdateDay();
        }
        dateText.text = FormattedGameTime();
    }

    // Returns the day formatted d/hh/mm
    public string FormattedGameTime()
    {
        gameHour = (int)Mathf.Floor(gameTime / 3600);
        gameMinute = (int)Mathf.Floor(((gameTime - (gameHour * 3600)) / (60)));
        string addzeroMin = gameMinute > 9 ? "" : "0";
        return seasonString + " " + "Day " + days + " " + gameHour + ":" + addzeroMin + gameMinute;
    }

    public void UpdateSeason()
    {
        days = 0;
        season ++ ;
        if (season > 3)
        {
            season = 0;
        }
       SetSeason();
    }
    
    public void UpdateDay()
    {
        days += 1;
        gameTime = 0;
        if (days >= 30)
        {
            UpdateSeason();
        }
    }

    public void JumpToNewDay() 
    {
        gameTime = 86400;
    }

    public void SetSeason()
    {
        switch (season) {
            case 0:
                seasonString = "Spring";
                SeasonChangeSpring?.Invoke();
                break;
            case 1:
                seasonString = "Summer";
                SeasonChangeSummer?.Invoke();
                break;
            case 2:
                seasonString = "Fall";
                SeasonChangeFall?.Invoke();
                break;
            case 3:
                seasonString = "Winter";
                SeasonChangeWinter?.Invoke();
                break;
            default:
                throw new KeyNotFoundException("No such season.");
        }
    }
}