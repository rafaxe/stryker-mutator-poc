using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var user = User.Create(1, new List<string>{ "Generosity", "Loyalty" }, Username.Create("John123"), Email.Create("john@gmail.com"));

            Assert.False(user.IsActive);
            Assert.False(user.IsBlocked);
            Assert.Equal("John123", user.UserName.ToString());
            Assert.Equal("john@gmail.com", user.Email.ToString());
        }

        [Fact]
        [DisplayName("The email address does not match the domain")]
        public void EmailDoesNotMatchTheDomain()
        {
            var exception = Assert.Throws<ArgumentException>
            (
                () => Email.Create("john@wrongdomain.com")
            );
            Assert.Equal("InvalidMailDomain", exception.Message);
        }

        [Fact]
        [DisplayName("The username does not have length permission")]
        public void UsernameMustHaveAllowedLength()
        {
            const string longName = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam augue enim, tincidunt sit amet maximus id, facilisis porta ante. Nulla eget pharetra nisi. Suspendisse eu tincidunt mauris. Pellentesque scelerisque tristique magna. Maecenas vel tortor ac dui finibus elementum. Aliquam mollis pellentesque odio, eget ultricies libero tincidunt non. Pellentesque sed iaculis sem, id ultricies purus. Mauris vehicula nulla nec metus sollicitudin, a elementum orci tristique. Donec a est porta, mollis metus ut, volutpat mi. In aliquam vestibulum nisl, non vestibulum mi";

            var exception = Assert.Throws<ArgumentException>
            (
                () => Username.Create(longName)
            );

            Assert.Equal("UserNameTooLongException", exception.Message);
        }

        [Fact]
        [DisplayName("User is already active")]
        public void UserIsAlreadyActive()
        {
            var user = User.Create(1, new List<string> { "Devotion", "Loving" }, Username.Create("John123"), Email.Create("john@gmail.com"));
            user.ActiveUser();

            Assert.True(user.IsActive);
            var exception = Assert.Throws<OperationCanceledException>
            (
                () => user.ActiveUser()
            );
            Assert.Equal("UserAlreadyActive", exception.Message);
        }

        [Fact]
        [DisplayName("User is already blocked")]
        public void UserIsAlreadyBlocked()
        {
            var user = User.Create(1, new List<string> { "Sincerity", "Self-control" }, Username.Create("John123"), Email.Create("john@gmail.com"));
            user.BlockUser();

            Assert.True(user.IsBlocked);


            var exception = Assert.Throws<OperationCanceledException>
            (
                () => user.BlockUser()
            );

            Assert.Equal("UserAlreadyBlocked", exception.Message);
        }

        //
        [Fact]
        [DisplayName("Username has the minimum allowed length")]
        public void UsernameMustHaveMinimumAllowedLength()
        {
            const string longName = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam augue enim, tincidunt sit amet maxi";
            var username = Username.Create(longName);
            Assert.NotNull(username);
        }

        [Fact]
        [DisplayName("The user after creation should be smart")]
        public void UserShouldBeSmart()
        {
            var user = User.Create(1, new List<string> { "Generosity", "Loyalty" }, Username.Create("John123"), Email.Create("john@gmail.com"));

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
            var exception = Assert.Throws<ArgumentException>
            (
                () => User.Create(1, new List<string>{ "Flat-earther" }, Username.Create("John123"), Email.Create("john@gmail.com"))
            );
            Assert.Equal("ProhibitedCharacteristic", exception.Message);
        }

        //[Test()]
        //[DisplayName("Username does not have length permission")]
        //public void UserMustHaveAllowedAge()
        //{
        //    var user = new User(1, 18, Username.Create("John123"), Email.Create("john@gmail.com"));
        //    Assert.NotNull(user);
        //}


  
    }
}