using Blast.ServiceLayer.Signals.Payloads;
using Blast.VisualLayer.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Cannons.Components
{
    public class PlayerCannon : MonoBehaviour
    {
        #region Injets

        [Inject] 
        private SignalBus _signalBus;
        
        #endregion
        
        #region Editor

        [SerializeField]
        private Damageable _damageable;
        
        [SerializeField]
        private InputDrivenWeaponTrigger _weaponTrigger;

        #endregion
        
        #region Methods

        private void Awake()
        {
            if (_damageable == null)
            {
                _damageable = GetComponent<Damageable>();
            }

            enabled = _damageable != null;
            
            _weaponTrigger.OnFire.AddListener(OnWeaponFire);
        }

        private void OnWeaponFire() 
        {
            _signalBus.Fire<PlayerCannonFired>();
        }

        private void Start()
        {
            _damageable.Destroyed += OnCannonDestroyed;
        }

        private void OnCannonDestroyed()
        {
            _signalBus.Fire<PlayerCannonDestroyed>();
        }

        #endregion
    }
}