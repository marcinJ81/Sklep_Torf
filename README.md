# Sklep_Torf Project
This project is an exercise based on a DNA course.
[Description of the task](http://ismartdev.pl/dna-zadania/dna-zadania-wstep/)
### Authors of Event Storming all level:
-  [Jakub Wiącek](https://www.linkedin.com/in/jakub-wi%C4%85cek-512551b6/ "Jakub Wiącek")
-  [Paweł Liszka](https://pl.linkedin.com/in/pawe%C5%82-liszka-a88240184?trk=people-guest_profile-result-card_result-card_full-click "Paweł Liszka")
-  [Marcin Juranek](https://www.linkedin.com/in/marcin-juranek-abb09899/ "Marcin Juranek")
### Author of code:
- [Marcin Juranek](https://www.linkedin.com/in/marcin-juranek-abb09899/ "Marcin Juranek")
## Event Storming Big Picture
[![](https://github.com/marcinJ81/Sklep_Torf/blob/master/ES_image/ESBP_main.PNG)](https://github.com/marcinJ81/Sklep_Torf/blob/master/ES_image/ESBP_main.PNG "Big Picture")

## Event Storming designation of subdomains
[![](https://github.com/marcinJ81/Sklep_Torf/blob/master/ES_image/SB_ekran_glowny.PNG)](https://github.com/marcinJ81/Sklep_Torf/blob/master/ES_image/SB_ekran_glowny.PNG "Subdomains")

## Event Storming Procces Level
[![](https://github.com/marcinJ81/Sklep_Torf/blob/master/ES_image/BC_glowny_widok.PNG)](https://github.com/marcinJ81/Sklep_Torf/blob/master/ES_image/BC_glowny_widok.PNG "Procces Level")

## Event Storming Design Level
[![](https://github.com/marcinJ81/Sklep_Torf/blob/master/ES_image/ES_DL_User.jpg)](https://github.com/marcinJ81/Sklep_Torf/blob/master/ES_image/ES_DL_User.jpg "First BC in Design Level")

#### Database Switch
In user repository I adding new layer for database switching. This layer I put in abstract class. This class is specific because she has two constructors. First is private, where I choise database type , second is public where i choise table. In my application I have SQLite in memory and in file.
Constructors
```csharp
public abstract class AQueryDefinition
    {
        private AQueryDefinition(DataBaseType choise)
        {
            if ((int)choise == 0)
            {
                this.testDataBase = new TestDataBase_InMemmory();
            }
            if ((int)choise == 1)
            {
                this.testDataBase = new TestDataBase_InFile();
            }
            this.dbType = choise;
        }
public AQueryDefinition(TableName tableName, DataBaseType choise) :
            this(choise)
        {
            if ((int)tableName == 1)
            {
                if ((int)choise == 1)
                    dropTable = @"DROP TABLE IF EXISTS user_register; ";
                else
                    dropTable = string.Empty;

                this.createTable =dropTable + @"CREATE TABLE IF NOT EXISTS user_register
                (
                    user_id INTEGER IDENTITY PRIMARY KEY,
                    user_name VARCHAR NOT NULL,
                    user_sname VARCHAR NOT NULL,
                    user_login VARCHAR UNIQUE,
                    user_email VARCHAR NOT NULL,
                    user_account_active INT NOT NULL,
                    user_ban BIT NOT NULL,
                    external_id VARCHAR NOT NULL
                );";
                this.selectUserTable = @"select user_id, user_name,user_sname," +
                                       "user_login,user_email, user_account_active " +
                                       " user_ban, external_id from user_register";
            }
        }
```
TableName and DataBaseType are Enum.
```csharp
    public enum TableName
    {
        User_table = 1
    }

    public enum DataBaseType
    {
        InMemmory = 0,
        InFile = 1
    }
```
In unit test
```csharp
public class UserRegisterTests
    {
        private IUserRegistration userRegistration;
        private ICheckingAvailabilityUserLogin usernameAvability;
        private IUsersRepository userRepository;
        [SetUp]
        public void Setup()
        {
            this.userRepository = new UsersRepository(TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers.TableName.User_table,
                TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers.DataBaseType.InFile);
            usernameAvability =  new Fake_UserLoginAvability();
            //usernameAvability = new UserNameAvability(userRepository);
            this.userRegistration = new UserRegistration(userRepository, usernameAvability);
```
In this unit test i have class switch between fake Fake_UserLoginAvability and trusted UserNameAvability(userRepository).
All of properties are interfaces
UserRepository inherits of AQueryDefinition abstract class and interfaces IUserRepository. In class constructor I have constructor from abstract class.
```csharp
 public class UsersRepository : AQueryDefinition, IUsersRepository
    {
        public UsersRepository(TableName tableName, DataBaseType choice)
        :base(tableName,choice){}
```