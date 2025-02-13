using System;
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
        
        public void Fire(Transform[] launchingPoints)
        {
            if (launchingPoints == null || launchingPoints.Length <= 0)
            {
                return;
            }

            foreach (var launchingPoint in launchingPoints)
            {
                var projectile = _projectileFactory.Create(launchingPoint.position, launchingPoint.forward);
                projectile.Fire(_weaponParams.ProjectileSpeed, _weaponParams.ProjectileMaxDistance, _weaponParams.Damage);
            }
        }
    }
}