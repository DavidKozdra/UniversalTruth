using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Reflection;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlanetDislpay, PlanetShopDisplay, BuyButton,msglist, PlanetMapItem;
    public Planet CurrentPlanet;
    public ScrollRect PlanetViewer;
    public TMP_Text BuyText,MoneyText,PoorText,CostText,EarningText,FactoryText,schooltext;
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
    public void SellLife() //sell life forms 
    {
        if (CurrentPlanet.Life >= 1) //check life on planet
        {

            playsound(0);
            int num = CurrentPlanet.Life / 2; //sell half the life on planet
            CurrentPlanet.Life /= 2; //set to half
            Player.Currency += (num +CurrentPlanet.school*5)/3; // each life is worth 1/3
            PoorText.text = ""; // reset poor text
        }
        else
        {
            playsound(1);
            PoorText.text = "Not engough Life";
        }
    }


    public void BuyFactory()  
    {
        if (CurrentPlanet.MineCost >= 1350 ) 
        {
            if (Player.Currency >= CurrentPlanet.FactoryCost)
            {
                playsound(0);
                Player.Currency -= CurrentPlanet.FactoryCost;
                CurrentPlanet.FactoryCost *= 3;
                Player.EarningRate += 40;
                PoorText.text = ""; // reset poor text
            }
            else
            {
                playsound(1);
                PoorText.text = "Too Poor";
            }

        }
        else
        {
            playsound(1);
            PoorText.text = "Need " + (3) + " Mines";
        }
    }


    public void BuySchool() 
    {
        if (CurrentPlanet.Farm >= 3) 
        {
            if (Player.Currency >= CurrentPlanet.schoolcost)
            {
                playsound(0);
                CurrentPlanet.school++;
                Player.Currency -= CurrentPlanet.schoolcost;
                CurrentPlanet.schoolcost *= 4;
                PoorText.text = ""; // reset poor text
            }
            else {
                playsound(1);
                PoorText.text = "Too Poor";
            }

        }
        else
        {
            playsound(1);
            PoorText.text = "Need " +(CurrentPlanet.Farm-3) + " Farms"; //current amount of each item
        }
    }

    // sell native life

    public void BuyFarm()
    {
        if (Player.Currency >= CurrentPlanet.FarmCost)
        {

            playsound(0);
            Player.Currency -= CurrentPlanet.FarmCost; //adabtive cost 
            CurrentPlanet.Farm += 1;
            CurrentPlanet.FarmCost *= 4;
        }
        else
        {
            playsound(1);
            PoorText.text = "Too Poor";
        }
    }

    public void BuyMine() {
        if (Player.Currency >= CurrentPlanet.MineCost) {

            playsound(0);
            Player.Currency -= CurrentPlanet.MineCost;
            Player.EarningRate += 20;
            CurrentPlanet.Reasource -= 100;
            CurrentPlanet.MineCost *= 5;
        } else {
            playsound(1);
            PoorText.text = "Too Poor";
        }
    }
    public void BetterResources()
    {
        if (Player.Currency >= 100)
        {

            playsound(0);
            Player.Currency -= 100;
            CurrentPlanet.GetComponent<ObjectPooler>().Pooledobject.GetComponent<Collectable>().Reasource +=10;
        }
        else
        {
            playsound(1);
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
            Player.EarningRate += 2;
            CurrentPlanet.Owned = true;
            Player.Currency -= CurrentPlanet.Cost;
            CurrentPlanet.Owned = true;
            CurrentPlanet.Medal.SetActive(true);
            Player.OwnedPlanets.Add(CurrentPlanet.GetComponentInParent<Transform>());
            GameObject msg = Instantiate(PlanetMapItem, msglist.transform);
            msg.GetComponent<PlanetMapItem>().SavedPostion = CurrentPlanet.transform.position;
            msg.GetComponent<PlanetMapItem>().NameText.text = CurrentPlanet.name;
            msg.GetComponent<PlanetMapItem>().I.sprite = CurrentPlanet.GetComponent<SpriteRenderer>().sprite;

            PoorText.text = " ";
        }
        else {
            PoorText.text = "Too Poor";
            playsound(1);
        }
    }
    
    //onclicks for predefined buttons with scroll view
    void Awake()
    {
        ToolTip = FindObjectOfType<ToolTip>();
        Player = FindObjectOfType<Player>();
        LifeSlider.maxValue = 1500;
        ReasourceSlider.maxValue = 1000;
    }
    public void NameChange() {
        if (CurrentPlanet != null && CurrentPlanet.Owned)
        {
            print("Active");
            //changename = true;
            //Player.Paused = true;
            //CurrentPlanet.name = NameText.text;
        }
     
    }
    public void Deselectname() {
        //edit is done
        CurrentPlanet.name = NameText.text;
        print("Deactive");
        Player.Paused = false;
        changename = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (CurrentPlanet != null) {
            MineCostText.text = "Add a Mine" +" - "+ CurrentPlanet.MineCost.ToString();
            Lifeaddtext.text = "Sell Life" + " +"+ ((CurrentPlanet.Life + CurrentPlanet.school *5) / 3).ToString();
            FarmCostText.text = "Buy Farm" + "- " + CurrentPlanet.FarmCost.ToString();
            FactoryText.text = "Buy Factory" + "- " + CurrentPlanet.FactoryCost.ToString();
            schooltext.text = "Buy school" + "- " + CurrentPlanet.schoolcost.ToString();
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
                NameText.text = "Purchase " + CurrentPlanet.name + " \n  	₱" + CurrentPlanet.Cost.ToString();
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
           // NameText.interactable = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //turn map off
            CurrentPlanet = null;
        }
    }
}
