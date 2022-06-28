using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    // For Wakid on Player
    public PlayerPick pick;
    public int durianTally;
    public float durianPrice;
    public float tupaiBounty;
    private float totalPrice;
    public TextMeshProUGUI durianText;
    public TextMeshProUGUI ringgitText;

    // For Sliders of Cart
    public Slider durianCartMoneySlider;
    public Slider durianCartDurianSlider;
    public float durianCartMoney;
    public float durianCartDurian;

    // Start is called before the first frame update
    void Start()
    {
        durianTally = 0;
        totalPrice = 0.0f ;
        durianText.text = "0 biji";
        ringgitText.text = "RM 0.0";

        durianCartDurianSlider.value = 0;
        durianCartDurianSlider.wholeNumbers = true;
        durianCartDurianSlider.maxValue = 200;
        durianCartMoneySlider.value = 0.0f;
        durianCartMoneySlider.maxValue = 2000f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDurian(int amount)
    {
        durianTally += amount;
        durianText.text = durianTally.ToString() + " bijies";
        AddRinggit(durianPrice * amount);
    }

    public void MinusDurian(int amount)
    {
        durianTally -= amount;
        durianText.text = durianTally.ToString() + " bijies";
        MinusRinggit(durianPrice * amount);
    }

    public void AddRinggit(float ringgit)
    {
        totalPrice += ringgit;
        ringgitText.text = "RM " + totalPrice.ToString();
    }

    public void MinusRinggit(float ringgit)
    {
        totalPrice -= ringgit;
        ringgitText.text = "RM " + totalPrice.ToString();
    }

    public void LoadToCart()
    {
        durianCartDurian += durianTally;
        durianCartMoney += totalPrice;

        MinusDurian(durianTally);
        if(totalPrice > 0)
        {
            MinusRinggit(totalPrice);
        }

        durianCartMoneySlider.value = durianCartMoney;
        durianCartDurianSlider.value = durianCartDurian;

        if(durianCartMoney == durianCartMoneySlider.maxValue && durianCartDurian == durianCartDurianSlider.maxValue)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }

    public void EnemyIsKilled(float bounty)
    {
        totalPrice += bounty;
        ringgitText.text = "RM " + totalPrice.ToString();
    }
}
