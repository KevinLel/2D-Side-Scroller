using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    private bool m_isPlayerInside;
    private bool m_ActionButtonPlayerPressed;

    private GameObject NextLoadSceneManager; 
    private GameObject m_Player;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        m_ActionButtonPlayerPressed = m_Player.gameObject.GetComponent<PlayerScript>().Action; 
        if(m_isPlayerInside && m_ActionButtonPlayerPressed){
            SceneManager.LoadScene("LoadScene"); 
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            m_isPlayerInside = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            m_isPlayerInside = false;
        }
    }
}
