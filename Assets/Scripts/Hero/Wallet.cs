using Scripts.Workflow;
using System;
using TMPro;
using UnityEngine;

namespace Scripts.Hero
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyText;

        private float _money;

        public  float Money => _money;

        public void AddMoney(float value)
        {
            if(value> 0)
            {
                _money += value;
                _moneyText.text = _money.ToString();
            }
        }
    }
}
