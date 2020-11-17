namespace House.HLL.Alert.Interfaces
{
    public interface IAutoNewsConsumer
    {
        void Consume(int articlesToTake = 10);
    }
}