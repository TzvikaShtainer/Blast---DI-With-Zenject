using System;
using Blast.VisualLayer.Components;
using Blast.VisualLayer.Weapons.Projectiles;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Weapons.Logic.SameTime
{
    public class SameTimeWeaponLogic : IWeaponLogic
    {
        [Inject]
        private Projectile.Factory _projectileFactory;

        [Inject]
        private WeaponLogicParams _weaponParams;

        [Inject]
        ILaunchingPointsProvider _launchingPointsProvider;
        
        private float _lastTimeFire;
        
        public void Fire()
        {
            if (_launchingPointsProvider == null || _launchingPointsProvider.LaunchingPoints.Length <= 0)
            {
                return;
            }

            var isInDelay = Time.time - _lastTimeFire < _weaponParams.LaunchDelay;
            if (isInDelay)
            {
                return;
            }
            
            foreach (var launchingPoint in _launchingPointsProvider.LaunchingPoints)
            {
                var projectile = _projectileFactory.Create(launchingPoint.position, launchingPoint.forward);
                projectile.Fire(_weaponParams.ProjectileSpeed, _weaponParams.ProjectileMaxDistance, _weaponParams.Damage);
            }
            
            _lastTimeFire = Time.time;
        }
    }
}