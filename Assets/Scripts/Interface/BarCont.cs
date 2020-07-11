using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCont : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject steamBar;

    public int health = 5;
    public int steam = 5;

    public void HurtPlayer(int amt) {
        health -= amt;
        healthBar.GetComponent<UnityEngine.UI.Text>().text = health.ToString();
    }
    
    public void HealthPlayer(int amt) {
        health += amt;
        healthBar.GetComponent<UnityEngine.UI.Text>().text = health.ToString();
    }
    
    public void LoseSteam(int amt) {
        steam -= amt;
        steamBar.GetComponent<UnityEngine.UI.Text>().text = steam.ToString();
    }
    
    public void GainSteam(int amt) {
        steam += amt;
        steamBar.GetComponent<UnityEngine.UI.Text>().text = steam.ToString();
    }
}
