public interface IMove
{
    float Speed { get; }
    void Move(float horizontal, float vertical, float deltatime);
    void Braking();
    
}

