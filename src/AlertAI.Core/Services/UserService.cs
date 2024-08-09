using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlertAI.Core.Models;
using AlertAI.Infrastructure.Repositories;

namespace AlertAI.Core.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> CreateUser(User user)
        {
            // Add any additional logic for user creation here
            return await _userRepository.CreateUser(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            // Add any additional logic for user update here
            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            // Add any additional logic for user deletion here
            return await _userRepository.DeleteUser(userId);
        }
    }
}