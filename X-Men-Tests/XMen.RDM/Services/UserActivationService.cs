﻿using System.Collections.Generic;
using XMen.RDM.Repositories;

namespace XMen.RDM.Services
{
    public class UserActivationService
    {

        private readonly IUserRepository _userRepository;

        public UserActivationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ActivateUser(int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
                throw new KeyNotFoundException("UserNotFound");

            user.ActiveUser();
            _userRepository.Save(user);
        }
    }
}