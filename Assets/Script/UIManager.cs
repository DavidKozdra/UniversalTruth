using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlanetDislpay, PlanetShopDisplay, BuyButton,msglist, PlanetMapItem;
    public Planet CurrentPlanet;
    public ScrollRect PlanetViewer;
    public TMP_Text BuyText,MoneyText,PoorText,CostText,EarningText;
    public TMP_Text MineCostText, Lifeaddtext, FarmCostText;
    public Slider LifeSlider, ReasourceSlider;
    public Image PlanetPicture;
    public TMP_InputField NameText;
    bool changename;
    public Player Player;
    private ToolTip ToolTip;
    public AudioClip[] clips;

    //if an object is addded or bought add to scroll rect values 

    // buy mine
    public void SellLife()
    {
        if (CurrentPlanet.Life >= 1)
        {
            int num = CurrentPlanet.Life / 2;
            CurrentPlanet.Life /= 2;
            Player.Currency += num /3;
            PoorText.text = "";
        }
        else
        {
            PoorText.text = "Not engough Life";
        }
    }

    // sell native life

    public void BuyFarm()
    {
        if (Player.Currency > 25)
        {
            Player.Currency -= 25; //adabtive cost 
            CurrentPlanet.Farm += 1;
        }
        else
        {
            PoorText.text = "Too Poor";
        }
    }

    public void BuyMine() {
        if (Player.Currency > CurrentPlanet.MineCost) {
            Player.Currency -= CurrentPlanet.MineCost;
            Player.EarningRate += 10;
            CurrentPlanet.Reasource -= 100;
            CurrentPlanet.MineCost *= 5;
        } else {
            PoorText.text = "Too Poor";
        }
    }

    public void TransportTo() { 
    
    }
    private void playsound(int index) {
        gameObject.GetComponent<AudioSource>().clip = clips[index];
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void Purchase() {
        if (Player.Currency >= CurrentPlanet.Cost)
        {
            playsound(0);
            Player.EarningRate += 1;
            CurrentPlanet.Owned = true;
            Player.Currency -= CurrentPlanet.Cost;
            CurrentPlanet.Owned = true;
            CurrentPlanet.Medal.SetActive(true);
            Player.OwnedPlanets.Add(CurrentPlanet.GetComponentInParent<Transform>());
            GameObject msg = Instantiate(PlanetMapItem, msglist.transform);
            msg.GetComponent<PlanetMapItem>().SavedPostion = CurrentPlanet.transform.position;

            PoorText.text = " ";
        }
        else {
            PoorText.text = "Too Poor";
        }
    }
    
    //onclicks for predefined buttons with scroll view
    void Awake()
    {
        ToolTip = FindObjectOfType<ToolTip>();
        Player = FindObjectOfType<Player>();
        LifeSlider.maxValue = 700;
        ReasourceSlider.maxValue = 1000;
    }
    public void NameChange() {
        print("namechange");
        if (CurrentPlanet != null && CurrentPlanet.Owned)
        {
            changename = true;
            CurrentPlanet.name = NameText.text;
        }
        else { 
        
        }
    }
    public void Deselectname() {
        print("edit done");
        changename = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (CurrentPlanet != null) {
            MineCostText.text = "Add a Mine" +" - "+ CurrentPlanet.MineCost.ToString();
            Lifeaddtext.text = "Sell Life" + " +"+ (CurrentPlanet.Life/6).ToString();
            LifeSlider.value = CurrentPlanet.Life;
            ReasourceSlider.value = CurrentPlanet.Reasource;
        }
        MoneyText.text = Player.Currency.ToString();
        EarningText.text = "Income: "+Player.EarningRate.ToString();
        if (CurrentPlanet != null)
        {
            ToolTip.IsTooltipVisable(false);
            PlanetDislpay.SetActive(true);
            if (!changename) {
                NameText.text = CurrentPlanet.name;
            }
            PlanetPicture.sprite = CurrentPlanet.image;
            if (CurrentPlanet.Owned)
            {
                //button off
                BuyButton.SetActive(false);
               
                PlanetShopDisplay.SetActive(true);

            }
            else {
                //button on
                PlanetShopDisplay.SetActive(false);
                BuyButton.SetActive(true);
                NameText.text = "Purchase " + CurrentPlanet.name +" \n  "+ CurrentPlanet.Cost.ToString();
            }
        }
        else {
            PoorText.text = " ";
            NameText.text = " ";
            PlanetDislpay.SetActive(false);
        }
        if (CurrentPlanet != null && !CurrentPlanet.Owned)
        {
            NameText.interactable = false;
        }
        else {
            NameText.interactable = true;
        }
            if (Input.GetKeyDown(KeyCode.Escape)) {
            CurrentPlanet = null;
        }
    }
}
