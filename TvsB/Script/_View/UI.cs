using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TaengvsBug.Script
{
    public class UI : MonoBehaviour
    {
        public List<Text> playerShow = new List<Text>();

        void Start()
        {
           Controller.Instance.showUI += Show;
        }

        public void Show()
        {
            playerShow[0].text = ("Player: 1" + " ATK: " + Controller.Instance.players[0].atk + " HP: " + Controller.Instance.players[0].hp + " Def: " + Controller.Instance.players[0].def + " Lv: " + Controller.Instance.players[0].lv + " Exp: " + Controller.Instance.players[0].exp);
            playerShow[1].text = ("Player: 2" + " ATK: " + Controller.Instance.players[1].atk + " HP: " + Controller.Instance.players[1].hp + " Def: " + Controller.Instance.players[1].def + " Lv: " + Controller.Instance.players[1].lv + " Exp: " + Controller.Instance.players[1].exp);
            playerShow[2].text = ("Player: 3" + " ATK: " + Controller.Instance.players[2].atk + " HP: " + Controller.Instance.players[2].hp + " Def: " + Controller.Instance.players[2].def + " Lv: " + Controller.Instance.players[2].lv + " Exp: " + Controller.Instance.players[2].exp);
            playerShow[3].text = ("Player: 4" + " ATK: " + Controller.Instance.players[3].atk + " HP: " + Controller.Instance.players[3].hp + " Def: " + Controller.Instance.players[3].def + " Lv: " + Controller.Instance.players[3].lv + " Exp: " + Controller.Instance.players[3].exp);
        }
    }
}
