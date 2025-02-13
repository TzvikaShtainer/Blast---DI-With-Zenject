using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Weapons.Logic.SameTime
{
    [CreateAssetMenu(menuName = "Blast/Weapons/Same Time Logic Installer", fileName = "Same Time Logic")]
    public class SameTimeWeaponLogicInstaller :ScriptableObjectInstaller<SameTimeWeaponLogicInstaller>
    {
        [SerializeField]
        private WeaponLogicParams _params;
        
        public override void InstallBindings()
        {
            Container
                .Bind<WeaponLogicParams>()
                .FromInstance(_params)
                .AsSingle();
            
            Container
                .Bind<IWeaponLogic>()
                .To<SameTimeWeaponLogic>()
                .AsSingle();
        }
    }
}