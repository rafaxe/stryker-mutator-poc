using System;
using System.Collections.Generic;
using System.Linq;

namespace XMen.RDM.Models
{
    public class User
    {
        private const string ProhibitedCharacteristic = "Flat-earther";

        public int UserId { get; }
        public Username UserName { get; }
        public Email Email { get; }
        public List<string> Characteristics { get; }
        public bool IsActive { get; private set; }
        public bool IsBlocked { get; private set; }

        private User(int userId, List<string> characteristics, Username userName, Email email)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Characteristics = CheckProhibitedCharacteristics(characteristics);
        }

        public static User Create(int userId, List<string> characteristics, Username userName, Email email)
        {
            return new(userId, characteristics, userName, email);
        }

        public void ActiveUser()
        {
            if (IsActive)
                throw new OperationCanceledException("UserAlreadyActive");

            IsActive = true;
        }

        private static List<string> CheckProhibitedCharacteristics(List<string> characteristics)
        {
            if (characteristics.Contains(ProhibitedCharacteristic))
            {
                throw new ArgumentException("ProhibitedCharacteristic");
            }

            characteristics.Add("Smart");
            return characteristics;
        }

        public void BlockUser()
        {
            if (IsBlocked)
                throw new OperationCanceledException("UserAlreadyBlocked");

            IsBlocked = true;
        }
    }
}
