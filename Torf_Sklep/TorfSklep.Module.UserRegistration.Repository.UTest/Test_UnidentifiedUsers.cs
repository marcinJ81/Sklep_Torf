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
            User user = new User()
            {
                user_name = "julian",
                user_sname = "krol",
                user_email = "julian@madagaskar.pl",
                user_login = "kroljulian",
                user_account_active = 1,
                user_ban = false,
                user_id = 1,
                external_id = ""
            };
            //when
            bool result = userRepo.AddUser(user);
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