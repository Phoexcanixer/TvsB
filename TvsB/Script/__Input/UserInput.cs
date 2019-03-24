using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaengvsBug.Script
{
    public class UserInput : MonoBehaviour,IUser
    {
        Dictionary<string, Action> ExecuteMethod = new Dictionary<string, Action>();
        int turn = 1;
        string action;
        int target;
        bool isCheck = true;

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
                    Debug.Log("1");
                    ChooseAction();
                    ChooseTarget();
                    break;
                case 2:
                    Debug.Log("2");
                    ChooseAction();
                    ChooseTarget();
                    break;
                case 3:
                    Debug.Log("3");
                    ChooseAction();
                    ChooseTarget();
                    break;
                case 4:
                    Debug.Log("4");
                    ChooseAction();
                    ChooseTarget();
                    break;
            }
        }

        public void ChooseAction()
        {
            if (Input.anyKey && isCheck == true)
            {
                if (ExecuteMethod.ContainsKey(Execute()))
                {
                    action = Execute();
                    isCheck = false;
                }
                return;
            }
        }

        public void ChooseTarget()
        {
            if (Input.anyKey && isCheck == false)
            {
                if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4))
                {
                    if (Input.GetKey(KeyCode.Alpha1)) target = 1;
                    if (Input.GetKey(KeyCode.Alpha2)) target = 2;
                    if (Input.GetKey(KeyCode.Alpha3)) target = 3;
                    if (Input.GetKey(KeyCode.Alpha4)) target = 4;
                    ExecuteMethod[action]?.Invoke(); 
                    isCheck = true;

                    turn++;
                }
                return;
            }
        }

        void Attack() { Controller.Instance.Attack(turn, target); }
        void Def() { Controller.Instance.Def(turn); }
        void Heal() { Controller.Instance.Heal(turn, target); }

        //----- 
        public string Execute()
        {
            string getKeyFromUser = Input.inputString;
            return getKeyFromUser.ToUpper();
        }

    }//Class
}//Namespace
