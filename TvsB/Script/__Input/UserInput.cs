using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaengvsBug.Script
{
    public class UserInput : MonoBehaviour,IUser
    {
        Dictionary<string, Action> ExecuteMethod = new Dictionary<string, Action>();

        public void Awake()
        {
            ExecuteMethod["A"] = () => this.Attack();
            ExecuteMethod["S"] = () => this.Def();
            ExecuteMethod["D"] = () => this.Heal();

            Debug.Log("Press: {0}--> ATK, {1}--> DEF, {2}--> HEAL" + "A" + "S" + "D");

            Controller.Instance.SetPlayer();

            
        }

        public void Update()
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
            Controller.Instance.Attack();
        }
        void Def()
        {
            Controller.Instance.HideBug();
        }
        void Heal()
        {
            Controller.Instance.PretendToDie();
        }

        //----- 
        public string Execute()
        {
            string getKeyFromUser = Input.inputString;
            return getKeyFromUser.ToUpper();
        }

    }//Class
}//Namespace
