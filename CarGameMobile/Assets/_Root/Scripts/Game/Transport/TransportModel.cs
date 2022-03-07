using Features.Shed.Upgrade;

namespace Game.Transport
{
    internal class TransportModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly float _defaultJump;
        public readonly TransportType Type;

        public float Speed { get; set; }
        public float Jump { get; set; }

        public TransportModel(float speed, float jump, TransportType type)
        {
            _defaultSpeed = speed;
            _defaultJump = jump;
            Speed = speed;
            Jump = jump;
            Type = type;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
            Jump = _defaultJump;
        }
    }
}
