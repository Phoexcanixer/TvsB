using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaengvsBug.Script
{

    public class UserInput : MonoBehaviour, IUser
    {
        Dictionary<string, Action> ExecuteMethod = new Dictionary<string, Action>();
        List<string> keyDic = new List<string>();
        public enum eturn { Action, ChooseTargetHeal, ChooseTargetAttack }
        public eturn actionOrChoose = eturn.Action;

        string _keyAction;
        int _keyTarget;
        int _player = 0;

        public void Start()
        {
            ExecuteMethod["A"] = () => this.Attack();
            ExecuteMethod["S"] = () => this.Def();
            ExecuteMethod["D"] = () => this.Heal();

            Debug.Log("Press: {0}--> ATK, {1}--> DEF, {2}--> HEAL" + "A" + "S" + "D");

            foreach (KeyValuePair<string, Action> item in ExecuteMethod)
            {
                keyDic.Add(item.Key);
            }
            
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
                case eturn.ChooseTargetHeal:
                    ChooseTargetHeal();
                    break;
                case eturn.ChooseTargetAttack:
                    ChooseTargetAtk();
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

        public string Execute()
        {
            string getKeyFromUser = Input.inputString;
            return getKeyFromUser.ToUpper();
        }

        void Attack()
        {
            actionOrChoose = eturn.ChooseTargetAttack;
        }

        void Def()
        {
            Controller.Instance.Def(_player);
            actionOrChoose = eturn.Action;
        }

        void Heal()
        {
            actionOrChoose = eturn.ChooseTargetHeal;
        }

        public void ChooseTargetHeal()
        {
            if (Input.anyKey)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    _keyTarget = Controller.Instance.countPlayer[0];
                    Target();
                }

                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    _keyTarget = Controller.Instance.countPlayer[1];
                    Target();
                }

                else if (Input.GetKey(KeyCode.Alpha3))
                {
                    _keyTarget = Controller.Instance.countPlayer[2];
                    Target();
                }

                else if (Input.GetKey(KeyCode.Alpha4))
                {
                    _keyTarget = Controller.Instance.countPlayer[3];
                    Target();
                }
            }
        }

        public void ChooseTargetAtk()
        {
            if (Input.anyKey)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    _keyTarget = Controller.Instance.countPlayer[0];
                    CheckTarget();
                }
                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    _keyTarget = Controller.Instance.countPlayer[1];
                    CheckTarget();
                }
                else if (Input.GetKey(KeyCode.Alpha3))
                {
                    _keyTarget = Controller.Instance.countPlayer[2];
                    CheckTarget();
                }
                else if (Input.GetKey(KeyCode.Alpha4))
                {
                    _keyTarget = Controller.Instance.countPlayer[3];
                    CheckTarget();
                }
            }
        }

        void CheckTarget()
        {
            if (_keyTarget == _player)
            {
                Debug.Log("Can't Atk self");
                return;
            }
            else if (_keyTarget != _player)
            {
                Target();
            }
        }

        void Target()
        {
            actionOrChoose = eturn.Action;
            if (_keyAction == keyDic[0]) Controller.Instance.Attack(_player, _keyTarget);
            else if (_keyAction == keyDic[2]) Controller.Instance.Heal(_player, _keyTarget);

            if (_player >= Controller.Instance.countPlayer.Count - 1) { _player = 0; }
            else _player++;
            
        }
    }//Class
}//Namespace
