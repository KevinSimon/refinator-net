using Refinator.Models.Rooms;

namespace Refinator.IRepositories
{
    public interface IMainRepository
    {
        RoomModel GetRoom(Guid roomId);
        void CreateOrUpdateRoom(RoomModel model);
        bool DeleteRoom(RoomModel model);
    }
}