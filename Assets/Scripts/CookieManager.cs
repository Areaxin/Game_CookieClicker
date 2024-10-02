using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookieManager : MonoBehaviour
{
    public int clicks;
    public int cps;
    public float nextTime;
    public int grandmaCount;
    public int grandmaPrice;

    [Header("References")]
    public TextMeshProUGUI cookieText;
    public AudioSource source;
    public Button grandmaButton;
    public TextMeshProUGUI grandmaCountText;
    public TextMeshProUGUI grandmaPriceText;
    
    private void Start()
    {
        Load();
        InvokeRepeating(nameof(AddCookies),0,1);
        InvokeRepeating(nameof(Save),10,10);
        
        grandmaCountText.text = grandmaCount.ToString();
        grandmaPriceText.text = "price: " + grandmaPrice;
    }

    void Save()
    {
        PlayerPrefs.SetInt("clicks",clicks);
        PlayerPrefs.SetInt("grandmas",grandmaCount);
        PlayerPrefs.SetInt("grandma_price",grandmaPrice);
        PlayerPrefs.SetInt("cps",cps);
    }

    void Load()
    {
        if (!PlayerPrefs.HasKey("grandma_price")) return; // guard clause
        
        clicks = PlayerPrefs.GetInt("clicks");
        grandmaCount = PlayerPrefs.GetInt("grandmas");
        grandmaPrice = PlayerPrefs.GetInt("grandma_price");
        cps = PlayerPrefs.GetInt("cps");
    }

    private void Update()
    {
        grandmaButton.interactable = clicks >= grandmaPrice;
        cookieText.text = clicks.ToString();
    }

    public void AddCookies()
    {
        //nextTime = Time.time + 1;
        clicks += cps;
    }

    public void BuyGrandma()
    {
        if (clicks >= grandmaPrice)
        {
            clicks -= grandmaPrice;
            cps += 2;
            source.Play();
            grandmaCount++;
            grandmaCountText.text = grandmaCount.ToString();

            grandmaPrice *= 2;
            grandmaPriceText.text = "Price: " + grandmaPrice;
        }
    }
}
