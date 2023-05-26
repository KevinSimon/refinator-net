using Refinator.IRepositories;
using Refinator.Models.Base;
using Refinator.Models.Rooms;
using Refinator.Repositories.Base;
using System.Collections.Concurrent;

namespace Refinator.Repositories
{
    public class MainRepository : BaseRepository, IMainRepository
    {
        private static ConcurrentDictionary<Guid, RoomModel> _Rooms = new ConcurrentDictionary<Guid, RoomModel>();


        public Guid CreateEmptyRoom(RoomModel model)
        {
            model.Id = Guid.NewGuid();
            _Rooms.TryAdd(model.Id, model);
            return model.Id;
        }

        public RoomModel GetRoom(Guid roomId)
        {
            _Rooms.TryGetValue(roomId, out RoomModel result);
            return result;
        }

        public void CreateOrUpdateRoom(RoomModel model)
        {
            SaveChanges(model);
            _Rooms.AddOrUpdate(model.Id, model, (k, v) => model);
        }

        public bool DeleteRoom(RoomModel model)
        {
            bool result = _Rooms.TryRemove(model.Id, out model);
            return result;
        }

        private void SaveChanges<T>(T model) where T : BaseModel
        {
            if (model != null)
            {
                DateTime date = DateTime.Now;
                if (model.Id == Guid.Empty) // Create
                {
                    model.Id = Guid.NewGuid();
                    model.IsActive = true;
                    model.CreatedDate = date;
                    model.UpdatedDate = date;
                }
                else // Update
                {
                    model.UpdatedDate = date;
                }
            }
        }
    }
}