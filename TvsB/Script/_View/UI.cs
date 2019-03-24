using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TaengvsBug.Script
{
    public class UI : MonoBehaviour
    {
        public List<Text> playerShow = new List<Text>();
        // Start is called before the first frame update
        void Start()
        {
            Show();
            Controller.Instance.showUI += Show;
        }

        public void Show()
        {
            playerShow[0].text = ("Player: 1" + " ATK: " + Controller.Instance.players[1].atk + " HP: " + Controller.Instance.players[1].hp);
            playerShow[1].text = ("Player: 2" + " ATK: " + Controller.Instance.players[2].atk + " HP: " + Controller.Instance.players[2].hp);
            playerShow[2].text = ("Player: 3" + " ATK: " + Controller.Instance.players[3].atk + " HP: " + Controller.Instance.players[3].hp);
            playerShow[3].text = ("Player: 4" + " ATK: " + Controller.Instance.players[4].atk + " HP: " + Controller.Instance.players[4].hp);
        }
    }
}
