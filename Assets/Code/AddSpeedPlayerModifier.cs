using UnityEngine;
internal class AddSpeedPlayerModifier: PlayerModifier
{
    private readonly float _speed;
    public AddSpeedPlayerModifier(Player player, float speed): base(player)
    {
        _speed = speed;
    }

    public override void Handle()
    {
        _player.Speed += _speed;
        base.Handle();
    }
}

