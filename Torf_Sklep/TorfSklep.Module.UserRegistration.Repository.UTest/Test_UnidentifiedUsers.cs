using NUnit.Framework;
using TorfSklep.Modules.UserRegistration.Respository;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace Tests
{
    public class Test_UnidentifiedUsers
    {
        private IUsersRepository userRepo;
        [SetUp]
        public void Setup()
        {
            this.userRepo = new UsersRepository(TableName.User_table);
        }

        [Test]
        [Ignore("Not implemented")]
        public void Test_GetUnidentifiedUsersList()
        {
            Assert.Fail();
        }

        [Test]
        public void Test_AddUnidentifiedUser()
        {
            //given

            //when
            bool result = userRepo.AddUser(new User());
            //then
            Assert.IsTrue(result);
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void Test_DeleteUserFromUnidentifiedList()
        {
            Assert.Fail();
        }
    }
}