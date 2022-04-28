using UnityEngine;
internal class PlayerModifier
{
    protected Player _player;
    protected PlayerModifier _next;

    public PlayerModifier(Player player)
    {
        _player = player;
    }

    public void Add(PlayerModifier playerModifier)
    {
        if(_next!=null)
        {
            _next.Add(playerModifier);
        }
        else
        {
            _next = playerModifier;
        }
    }

    public virtual void Handle() => _next?.Handle();
}

