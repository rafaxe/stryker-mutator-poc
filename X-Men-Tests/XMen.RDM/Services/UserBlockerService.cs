using XMen.RDM.Repositories;
using System.Collections.Generic;

namespace XMen.RDM.Services
{
    public class UserBlockerService
    {

        private readonly IUserRepository _userRepository;

        public UserBlockerService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Block(int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
                throw new KeyNotFoundException("UserNotFound");

            user.BlockUser();
            _userRepository.Save(user);
        }
    }
}
