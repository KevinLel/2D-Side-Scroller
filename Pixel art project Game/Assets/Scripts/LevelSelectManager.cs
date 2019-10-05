using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class LevelSelectManager : MonoBehaviour
{
    public Text TimerText, EnergyText; 
    private static int Energy, EnergyReloadValue;
    private int MinEnergy = 0,MaxEnergy = 20;
    private float SecondeReloadOneEnergy = 5.0f, TimerReload = 1.0f;
    private int BufferEnergy;
    private int LoadLevelEnergyCost = 5;  
    public static int NbCouronneLVL1;
    private int MaxCouronne = 6, MinCouronne = 0; 
     private int SecondeVisualTimerValue, MinuteVisualTimerValue;
    private float ValueVisualTimer, ValueBeforeEnergy;
    //Variable de changement de monde
    private static int WorldNumber;
    public Button LeftButton, RightButton;

    

    #region Variable de Changement de monde
        //Liste de tout le mondes (Panel)
        public List<GameObject> Worlds = new List<GameObject>();
        //IndexDuNuemroDeMonde
        private int WorldIndex; 
        private GameObject m_GameobjectInstance; 
        private GameObject UICanvas;
    #endregion
    public GameObject EnergyPanel;
    void Start()
    {
        UICanvas = GameObject.Find("Canvas"); 
        WorldIndex = 0;
        MinuteVisualTimerValue = 1;
        SecondeVisualTimerValue = 1;
        LevelChange(WorldIndex);
    }

    // Update is called once per frame
    void Update()
    {   
        //Timer Visual Effect & Energy Reload
        if(Time.time > ValueVisualTimer){ //Visible Timer Actual
            ValueVisualTimer = Time.time + TimerReload;
            SecondeVisualTimerValue--;
        }
        if(SecondeVisualTimerValue == 0){
                SecondeVisualTimerValue = 59;
                MinuteVisualTimerValue--;
                if(MinuteVisualTimerValue == 0 && SecondeVisualTimerValue == 0){
                    MinuteVisualTimerValue = 1;
                    Energy += EnergyReloadValue;
                    if(Energy > MaxEnergy){
                        Energy = MaxEnergy;
                    } 
        }
        }
        //Actualisation des textes de l'UI
        TimerText.text = MinuteVisualTimerValue.ToString() + " : " + SecondeVisualTimerValue.ToString();
        EnergyText.text = Energy.ToString() + "/ 20"; 

        //Gestion du deplacement entre le choix du monde
        if(WorldIndex == 0){
            LeftButton.gameObject.SetActive(false);
        }
        else{
            LeftButton.gameObject.SetActive(true);
        }
        if(WorldIndex == 1){
            RightButton.gameObject.SetActive(false);
        }
        else{
            RightButton.gameObject.SetActive(true);
        }
    }
    /*
        Chargement du niveau en fonction du nom du bouton pressé. Sans avoir a envoyer des paramètre
    */
    public void LoadLevel(){
        GameObject PressedButton;
        string PressedButtonName;
        PressedButton = EventSystem.current.currentSelectedGameObject;
        PressedButtonName = PressedButton.name; 

        if(Energy < LoadLevelEnergyCost){
            EnergyPanel.SetActive(true);
        }
        else{
            Energy -= LoadLevelEnergyCost;
            SceneManager.LoadScene("SceneDeTest");
        }
    }
    //Fonction du bouton Retour du Panel de rechargement d'energie via pub
    public void Retour(){
        EnergyPanel.SetActive(false);
    }
    //Fonction de lancement de la pub et de rechargement d'energie
    public void RechargementEnergy(){
        //On joue la publicité (A integrer plus tard)
    }
    public void TestReloadEnergy(){
        Energy += 5;
    }


    #region Changement de Monde
    //Fonction pour se déplacer sur le monde de gauche
    public void WorldChangeLeft(){
        WorldIndex--; 
        LevelChange(WorldIndex);
    }
    //Fonction pour se déplacer sur le monde de droite
    public void WorldChangeRight(){
        WorldIndex++;
        LevelChange(WorldIndex);
    }
    void LevelChange(int Index){
        if(m_GameobjectInstance != null)
        {
            Destroy(m_GameobjectInstance);
        }
        m_GameobjectInstance = Instantiate(Worlds[Index]);
        
    }
    #endregion
}
