using System;
using Interface;
using UnityEngine;
using ViewModel;

namespace Controller
{
    public class PlayerStatController : MonoBehaviour
    {
        private PlayerStatsViewModel _psvm;

        public PlayerStatController()
        {
            _psvm = new PlayerStatsViewModel();
        }
        

        public PlayerStatsViewModel Psvm
        {
            get => _psvm;
            set => _psvm = value;
        }

        public void Attach(IObserver observer)
        {
            _psvm.PlayerStatsModel.Attach(observer);
        }
    }
}