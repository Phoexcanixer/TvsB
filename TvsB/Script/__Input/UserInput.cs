using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaengvsBug.Script
{
    public class UserInput : MonoBehaviour,IUser
    {
        Dictionary<string, Action> ExecuteMethod = new Dictionary<string, Action>();
        int turn = 1;

        public void Start()
        {
            ExecuteMethod["A"] = () => this.Attack();
            ExecuteMethod["S"] = () => this.Def();
            ExecuteMethod["D"] = () => this.Heal();

            Debug.Log("Press: {0}--> ATK, {1}--> DEF, {2}--> HEAL" + "A" + "S" + "D");

            Controller.Instance.SetPlayer();
        }

        public void Update()
        {
            Turn();
        }

        public void Turn()
        {
            switch (turn)
            {
                case 1:
                    ChooseKey();
                    break;
                case 2:
                    ChooseKey();
                    break;
                case 3:
                    ChooseKey();
                    break;
                case 4:
                    ChooseKey();
                    break;
            }
        }

        public void ChooseKey()
        {
            if (Input.anyKey)
            {
                if (ExecuteMethod.ContainsKey(Execute()))
                {
                    ExecuteMethod[Execute()]?.Invoke();
                }
            }
        }

        void Attack()
        {
            Controller.Instance.Attack(turn, 2);
        }
        void Def()
        {
            Controller.Instance.Def(turn);
        }
        void Heal()
        {
            Controller.Instance.Heal(turn, 2);
        }

        //----- 
        public string Execute()
        {
            string getKeyFromUser = Input.inputString;
            return getKeyFromUser.ToUpper();
        }

    }//Class
}//Namespace
