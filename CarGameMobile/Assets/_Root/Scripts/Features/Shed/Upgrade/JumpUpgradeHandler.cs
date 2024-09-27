using Features.Shed.Upgrade;

namespace Features.Shed
{
    internal class JumpUpgradeHandler : IUpgradeHandler
    {
        private readonly float _jump;
        public JumpUpgradeHandler(float jump) =>
            _jump = jump;
        
        public void Upgrade(IUpgradable upgradable) => 
            upgradable.Jump = _jump;
    }
}
