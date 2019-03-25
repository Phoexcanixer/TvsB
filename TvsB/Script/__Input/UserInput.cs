using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaengvsBug.Script
{
    
    public class UserInput : MonoBehaviour,IUser
    {
        Dictionary<string, Action> ExecuteMethod = new Dictionary<string, Action>();
        public enum eturn { Action, ChooseTarget }
        public eturn actionOrChoose = eturn.Action;

        string _keyAction;
        int _keyTarget;

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
            Turn(actionOrChoose);
        }

        public void Turn(eturn turn)
        {
            switch (turn)
            {
                case eturn.Action:
                    ChooseAction();
                    break;
                case eturn.ChooseTarget:
                    ChooseTarget();
                    break;
                default:
                    break;
            }
        }

        public void ChooseAction()
        {
            if (Input.anyKey)
            {
                if (ExecuteMethod.ContainsKey(Execute()))
                {
                    _keyAction = Execute();
                    ExecuteMethod[Execute()]?.Invoke();
                }
            }
        }

        public void ChooseTarget()
        {
            if (Input.anyKey)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    _keyTarget = 0;
                    Target();
                }

                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    _keyTarget = 1;
                    Target();
                }

                else if(Input.GetKey(KeyCode.Alpha3))
                {
                    _keyTarget = 2;
                    Target();
                }

                else if(Input.GetKey(KeyCode.Alpha4))
                {
                    _keyTarget = 3;
                    Target();
                }
            }
        }

        void Target()
        {
            actionOrChoose = eturn.Action;
            if(_keyAction == "A") Controller.Instance.Attack(0, _keyTarget);
            else if(_keyAction == "D") Controller.Instance.Heal(0, _keyTarget);
        }

        void Attack()
        {
            actionOrChoose = eturn.ChooseTarget;
        }
        void Def()
        {
            Controller.Instance.Def(0);
            actionOrChoose = eturn.Action;
        }
        void Heal()
        {
            actionOrChoose = eturn.ChooseTarget;
        }

        //----- 
        public string Execute()
        {
            string getKeyFromUser = Input.inputString;
            return getKeyFromUser.ToUpper();
        }

    }//Class
}//Namespace
