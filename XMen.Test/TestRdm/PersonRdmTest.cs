using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XMen.RDM.Models;
using Xunit;

namespace XMen.Test.TestRdm
{
    public class PersonRdmTest
    {
        [Fact]
        [DisplayName("The user after creation should not be active")]
        public void ShouldNotBeActiveAfterCreation()
        {
            //Arrange //Act
            var user = User.Create(1, new List<string>{ "Generosity", "Loyalty" }, Username.Create("John123"), Email.Create("john@gmail.com"));

            //Assert
            Assert.False(user.IsActive);
            Assert.False(user.IsBlocked);
            Assert.Equal("John123", user.UserName.ToString());
            Assert.Equal("john@gmail.com", user.Email.ToString());
        }

        [Fact]
        [DisplayName("The email address does not match the domain")]
        public void EmailDoesNotMatchTheDomain()
        {
            //Arrange //Act
            var exception = Assert.Throws<ArgumentException>
            (
                () => Email.Create("john@wrongdomain.com")
            );

            //Assert
            Assert.Equal("InvalidMailDomain", exception.Message);
        }

        [Fact]
        [DisplayName("The username does not have length permission")]
        public void UsernameMustHaveAllowedLength()
        {
            //Arrange 
            const string longName = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam augue enim, tincidunt sit amet maximus id, facilisis porta ante. Nulla eget pharetra nisi. Suspendisse eu tincidunt mauris. Pellentesque scelerisque tristique magna. Maecenas vel tortor ac dui finibus elementum. Aliquam mollis pellentesque odio, eget ultricies libero tincidunt non. Pellentesque sed iaculis sem, id ultricies purus. Mauris vehicula nulla nec metus sollicitudin, a elementum orci tristique. Donec a est porta, mollis metus ut, volutpat mi. In aliquam vestibulum nisl, non vestibulum mi";

            //Act
            var exception = Assert.Throws<ArgumentException>
            (
                () => Username.Create(longName)
            );

            //Assert
            Assert.Equal("UserNameTooLongException", exception.Message);
        }

        [Fact]
        [DisplayName("User is already active")]
        public void UserIsAlreadyActive()
        {
            //Arrange 
            var user = User.Create(1, new List<string> { "Devotion", "Loving" }, Username.Create("John123"), Email.Create("john@gmail.com"));
            user.ActiveUser();
            bool previousStatus = user.IsActive;

            //Act 
            var exception = Assert.Throws<OperationCanceledException>
            (
                () => user.ActiveUser()
            );

            //Assert
            Assert.True(previousStatus);
            Assert.Equal("UserAlreadyActive", exception.Message);
        }

        [Fact]
        [DisplayName("User is already blocked")]
        public void UserIsAlreadyBlocked()
        {
            //Arrange
            var user = User.Create(1, new List<string> { "Sincerity", "Self-control" }, Username.Create("John123"), Email.Create("john@gmail.com"));
            user.BlockUser();
            bool previousStatus = user.IsBlocked;

            //Act 
            var exception = Assert.Throws<OperationCanceledException>
            (
                () => user.BlockUser()
            );

            //Assert
            Assert.True(previousStatus);
            Assert.Equal("UserAlreadyBlocked", exception.Message);
        }

        [Fact]
        [DisplayName("The user after creation should be smart")]
        public void UserShouldBeSmart()
        {
            //Arrange //Act
            var user = User.Create(1, new List<string> { "Generosity", "Loyalty" }, Username.Create("John123"), Email.Create("john@gmail.com"));

            //Assert
            Assert.False(user.IsActive);
            Assert.False(user.IsBlocked);
            Assert.Equal("John123", user.UserName.ToString());
            Assert.Equal("john@gmail.com", user.Email.ToString());
            Assert.Contains("Smart", user.Characteristics);

        }


        [Fact]
        [DisplayName("User must have allowed characteristics")]
        public void UserMustHaveAllowedCharacteristic()
        {
            //Arrange //Act 
            var exception = Assert.Throws<ArgumentException>
            (
                () => User.Create(1, new List<string>{ "Flat-earther" }, Username.Create("John123"), Email.Create("john@gmail.com"))
            );

            //Assert
            Assert.Equal("ProhibitedCharacteristic", exception.Message);
        }

        [Fact]
        [DisplayName("Username has the minimum allowed length")]
        public void UsernameMustHaveMinimumAllowedLength()
        {
            //Arrange 
            const string longName = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam augue enim, tincidunt sit amet maxi";

            //Act
            var username = Username.Create(longName);

            //Assert
            Assert.NotNull(username);
        }

        [Fact]
        [DisplayName("The user after creation should be smart")]
        public void UserShouldBeSmartNotDuplicated()
        {
            //Arrange //Act
            var user = User.Create(1, new List<string> { "Generosity", "Loyalty", "Smart" }, Username.Create("John123"), Email.Create("john@gmail.com"));

            //Assert
            Assert.False(user.IsActive);
            Assert.False(user.IsBlocked);
            Assert.Equal("John123", user.UserName.ToString());
            Assert.Equal("john@gmail.com", user.Email.ToString());
            Assert.Equal(1, user.Characteristics.Count(x => x.Equals("Smart")));
        }
    }
}