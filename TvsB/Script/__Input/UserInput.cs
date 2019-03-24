using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaengvsBug.Script
{
    public class UserInput : MonoBehaviour
    {
        Dictionary<string, Action> ExecuteMethod = new Dictionary<string, Action>();

        public void Awake()
        { 
            ExecuteMethod["A"] = () => this.Attack();
            ExecuteMethod["S"] = () => this.Def();
            ExecuteMethod["D"] = () => this.Heal();

            Debug.Log("Press: {0}--> ATK, {1}--> DEF, {2}--> HEAL"+ "A"+ "S"+ "D");
        }

        public void Update()
        {
            if (Input.anyKey)
            {
                if (!ExecuteMethod.ContainsKey(Execute()))
                {
                    Debug.Log("Don't Have" + Input.inputString);
                    return;
                }
                else ExecuteMethod[Execute()]?.Invoke();
            }

        }

        void Attack()
        {
            Controller.instance.Attack();
            Debug.Log("Attack");
        }
        void Def()
        {
            Controller.instance.HideBug();
            Debug.Log("Def");
        }
        void Heal()
        {
            Controller.instance.PretendToDie();
            Debug.Log("Heal");
        }

        //----- 
        public string Execute()
        {
            string getkey = Input.inputString;
            return getkey.ToUpper();
        }

    }//Class
}//Namespace
