using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaengvsBug.Script
{

    public class UserInput : MonoBehaviour, IUser
    {
        Dictionary<string, Action> ExecuteMethod = new Dictionary<string, Action>();
        List<string> keyDic = new List<string>();
        public enum eturn { Action, ChooseTarget }
        public eturn actionOrChoose = eturn.Action;

        string _keyAction;
        int _keyTarget;
        int _player = 1;

        public void Start()
        {
            ExecuteMethod["A"] = () => this.Attack();
            ExecuteMethod["S"] = () => this.Def();
            ExecuteMethod["D"] = () => this.Heal();

            Debug.Log("Press: {0}--> ATK, {1}--> DEF, {2}--> HEAL" + "A" + "S" + "D");

            foreach (KeyValuePair<string, Action> item in ExecuteMethod) { keyDic.Add(item.Key); }
            
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

        public string Execute()
        {
            string getKeyFromUser = Input.inputString;
            return getKeyFromUser.ToUpper();
        }

        void Attack()
        {
            actionOrChoose = eturn.ChooseTarget;
        }

        void Def()
        {
            actionOrChoose = eturn.Action;
            Controller.Instance.Def(_player);
            NextPlayer();
        }

        void Heal()
        {
            actionOrChoose = eturn.ChooseTarget;
        }

        public void ChooseTarget()
        {
            if (int.TryParse(Input.inputString, out int check))
            {
                if (Input.GetKey(KeyCode.Alpha1)) { _keyTarget = Controller.Instance.countPlayer[0]; }
                else if (Input.GetKey(KeyCode.Alpha2)) { _keyTarget = Controller.Instance.countPlayer[1]; }
                else if (Input.GetKey(KeyCode.Alpha3)) { _keyTarget = Controller.Instance.countPlayer[2]; }
                else if (Input.GetKey(KeyCode.Alpha4)) { _keyTarget = Controller.Instance.countPlayer[3]; }
                else
                {
                    Debug.Log("No Target");
                    return;
                }
                CheckPlayer(_keyTarget);
            }
            else
            {
                Debug.Log("Press Numberic");
                return;
            }
        }

        void CheckPlayer(int player)
        {
            if (!Controller.Instance.players.ContainsKey(player))
            {
                Debug.Log("Don't Have Player");
                return;
            }
            else Target();
        }

        void Target()
        {
            if (_keyAction == keyDic[0])
            {
                if (_keyTarget == _player)
                {
                    Debug.Log("Can't Atk self");
                    return;
                }
                else if (_keyTarget != _player)
                {
                    Controller.Instance.Attack(_player, _keyTarget);
                } 
            } 
            else if (_keyAction == keyDic[2]) Controller.Instance.Heal(_player,_keyTarget);
            NextPlayer();
            actionOrChoose = eturn.Action;
        }

        void NextPlayer()
        {
            if (_player >= Controller.Instance.countPlayer.Count)
            {
                _player = 1;
                foreach (var check in Controller.Instance.players)
                {
                    if (Controller.Instance.players.ContainsKey(_player))
                    {
                        Debug.Log("Find Player Success");
                        break;
                    }
                    else
                    {
                        _player++;
                    }
                }
                
            }
            else _player++;
            Debug.Log("Turn Player: " + _player);
        }
    }//Class
}//Namespace
