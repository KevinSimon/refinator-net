using Refinator.IFacades;
using Refinator.IRepositories;
using Refinator.Models.Rooms;

namespace Refinator.Facades
{
    public class RoomFacade : IRoomFacade
    {
        private readonly IMainRepository _mainRepository;

        public RoomFacade(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        #region Room edition

        public RoomModel CreateRoom(Guid userId, string roomLabel)
        {
            RoomModel result = new()
            {
                Label = roomLabel,
                UserId = userId,
            };
            _mainRepository.CreateOrUpdateRoom(result);
            return result;
        }

        public bool DeleteRoom(Guid userId, Guid roomId)
        {
            RoomModel model = _mainRepository.GetRoom(roomId);
            if (model == null || model.IsDelete || model.UserId != userId)
            {
                return false;
            }
            bool result = _mainRepository.DeleteRoom(model);
            return result;
        }

        #endregion

        #region Room interactions

        public RoomModel JoinRoom(Guid userId, Guid roomId)
        {
            RoomModel result = _mainRepository.GetRoom(roomId);
            result.IsUse = true;

            RoomUserModel roomUser = result.RoomUsers.FirstOrDefault(x => x.UserId == userId);
            if (roomUser == null)
            {
                roomUser = new RoomUserModel()
                {
                    UserId = userId,
                    IsConnected = true,
                    IsModerator = result.UserId == userId || result.RoomUsers.Count(x => x.IsModerator) == 0,
                    IsOwner = result.UserId == userId,
                    RoomId = roomId,
                    CurrentVote = null
                };
                result.RoomUsers.Add(roomUser);
            }
            else
            {
                roomUser.IsConnected = true;
                roomUser.IsModerator = result.RoomUsers.Count(x => x.IsModerator) == 0;
                roomUser.CurrentVote = null;
            }
            _mainRepository.CreateOrUpdateRoom(result);
            // TODO: Notify client to refresh data
            return result;
        }

        public RoomModel LeaveRoom(Guid userId, Guid roomId)
        {
            RoomModel result = _mainRepository.GetRoom(roomId);
            result.IsUse = result.RoomUsers.Any(x => x.IsConnected);
            RoomUserModel roomUser = result.RoomUsers.FirstOrDefault(x => x.UserId == userId);
            if (roomUser != null)
            {
                roomUser.IsConnected = false;
            }
            _mainRepository.CreateOrUpdateRoom(result);
            return result;
            // TODO: Notify client to refresh data
        }

        public RoomModel DeleteRoomUser(Guid userId, Guid roomId)
        {
            RoomModel result = _mainRepository.GetRoom(roomId);
            result.IsUse = result.RoomUsers.Any(x => x.IsConnected);
            RoomUserModel roomUser = result.RoomUsers.FirstOrDefault(x => x.UserId == userId);
            if (roomUser != null)
            {
                result.RoomUsers.Remove(roomUser);
            }
            _mainRepository.CreateOrUpdateRoom(result);
            return result;
        }

        //TODO: SwitchUserRole(Guid userId, int rolId)
        //TODO: StartVote(Guid roomId)
        //TODO: EndVote(Guid roomId)

        #endregion

    }
}