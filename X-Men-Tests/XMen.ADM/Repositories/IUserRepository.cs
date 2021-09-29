using XMen.ADM.Models;

namespace XMen.ADM.Repositories
{
    public interface IUserRepository
    {
        public User GetById(int userId);

        public void Save(User user);
    }
}
