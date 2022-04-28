using UnityEngine;
internal class AddHpPlayerModifier : PlayerModifier
{
    private readonly float _hp;
    public AddHpPlayerModifier(Player player, float hp): base(player)
    {
        _hp = hp;
    }

    public override void Handle()
    {
        _player.HP = _hp;
        base.Handle();
    }
}

