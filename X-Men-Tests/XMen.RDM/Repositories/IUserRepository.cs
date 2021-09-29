using XMen.RDM.Models;

namespace XMen.RDM.Repositories
{
    public interface IUserRepository
    {
        public User GetById(int userId);

        public void Save(User user);
    }
}
