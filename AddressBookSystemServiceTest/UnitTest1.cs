using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSystemService;

namespace AddressBookSystemServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepo addressBookRepo;

        [TestInitialize]
        public void SetUp()
        {
            addressBookRepo = new AddressBookRepo();
        }
        [TestMethod]
        public void UpdateTableInDataBase()
        {
            bool expected = true;
            bool actual = addressBookRepo.UpdateTables();
            Assert.AreEqual(actual, expected);
        }
    }
}
