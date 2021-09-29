using XMen.RDM.Models;
using XMen.RDM.Repositories;
using System.Reflection;

namespace XMen.RDM.Services
{
    public class UserRegistrationService
    {
        private readonly IUserRepository _userRepository;

        public UserRegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            if (_userRepository.GetById(user.UserId) != null)
                throw new AmbiguousMatchException("UserAlreadyExists");

            _userRepository.Save(user);
        }
    }
}