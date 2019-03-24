using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaengvsBug.Script
{
    public class UserInput : IUser
    {
        Dictionary<ConsoleKey, Action> ExecuteMethod = new Dictionary<ConsoleKey, Action>();

        public UserInput()
        {
            ExecuteMethod[ConsoleKey.A] = () => this.Attack();
            ExecuteMethod[ConsoleKey.S] = () => this.Def();
            ExecuteMethod[ConsoleKey.D] = () => this.Heal();

            Console.WriteLine("Press: {0}--> ATK, {1}--> DEF, {2}--> HEAL", "A", "S", "D");

            InputKey();
        }

        public void InputKey()
        {
            do
            {
                if (!ExecuteMethod.ContainsKey(Execute()))
                {
                    Debug.Log("Don't Have Key: " + Input.inputString);
                }
                else ExecuteMethod[Execute()]?.Invoke();
            }
            while (true);

        }

        void Attack() { Controller.Instance.Attack(); }
        void Def() { Controller.Instance.HideBug(); }
        void Heal() { Controller.Instance.PretendToDie(); }

        //----- 
        public ConsoleKey Execute()
        {
            Console.TreatControlCAsInput = true;
            ConsoleKeyInfo getKeyFromUser = Console.ReadKey();
            return getKeyFromUser.Key;
        }

    }//Class
}//Namespace
