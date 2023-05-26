using Refinator.Models.Rooms;

namespace Refinator.IFacades
{
    public interface IRoomFacade
    {
        RoomModel CreateRoom(Guid userId, string roomLabel);
        bool DeleteRoom(Guid userId, Guid roomId);
        RoomModel JoinRoom(Guid userId, Guid roomId);
        RoomModel LeaveRoom(Guid userId, Guid roomId);
        RoomModel DeleteRoomUser(Guid userId, Guid roomId);
    }
}