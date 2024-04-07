using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbstractDataTypes;
using ADT;

namespace LinkedListTest
{
    [TestClass]
    public class UnitTest3
    {
        ClubMember c1, c2, c3, c4, c5;
        ILinkedList list;
        ILinkedList<ClubMember> listGeneric;

        [TestInitialize]
        public void Init()
        {
            list = new DoublyLinkedList();
            listGeneric = new ADT.DoublyLinkedList<ClubMember>();

            c1 = new ClubMember
            {
                Id = 1,
                FirstName = "Anders",
                LastName = "And",
                Gender = Gender.Male,
                Age = 15
            };
            c2 = new ClubMember
            {
                Id = 2,
                FirstName = "Bjørn",
                LastName = "Borg",
                Gender = Gender.Male,
                Age = 30
            };
            c3 = new ClubMember
            {
                Id = 3,
                FirstName = "Cristian",
                LastName = "Nielsen",
                Gender = Gender.Male,
                Age = 20
            };
            c4 = new ClubMember
            {
                Id = 4,
                FirstName = "Kurt",
                LastName = "Nielsen",
                Gender = Gender.Male,
                Age = 33
            };
            c5 = new ClubMember
            {
                Id = 5,
                FirstName = "Lis",
                LastName = "Sørensen",
                Gender = Gender.Female,
                Age = 18
            };
        }
        [TestMethod]
        public void TestSwap()
        {
            list.Insert(c3); // c3           3: Cristian Nielsen (Male, 20 years)
            list.Insert(c1); // c1, c3       1: Anders And (Male, 15 years)   3: Cristian Nielsen (Male, 20 years)
            list.Insert(c2); // c2, c1, c3   2: Bjørn Borg (Male, 30 years)   1: Anders And (Male, 15 years)   3: Cristian Nielsen (Male, 20 years)
            list.Swap(1); // c2, c3, c1      2: Bjørn Borg (Male, 30 years)   3: Cristian Nielsen (Male, 20 years)   1: Anders And (Male, 15 years)
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("2: Bjørn Borg (Male, 30 years)\n3: Cristian Nielsen (Male, 20 years)\n1: Anders And (Male, 15 years)", list.ToString());

            list.Swap(0); // c3, c2, c1
            Assert.AreEqual("3: Cristian Nielsen (Male, 20 years)\n2: Bjørn Borg (Male, 30 years)\n1: Anders And (Male, 15 years)", list.ToString());
        }
        [TestMethod]
        public void TestSwapGeneric()
        {
            listGeneric.Insert(c3);
            listGeneric.Insert(c1);
            listGeneric.Insert(c2); // c2, c1, c3
            listGeneric.Swap(1); // c2, c3, c1
            Assert.AreEqual(3, listGeneric.Count);
            Assert.AreEqual("2: Bjørn Borg (Male, 30 years)\n3: Cristian Nielsen (Male, 20 years)\n1: Anders And (Male, 15 years)", listGeneric.ToString());

            listGeneric.Swap(0); // c3, c2, c1
            Assert.AreEqual("3: Cristian Nielsen (Male, 20 years)\n2: Bjørn Borg (Male, 30 years)\n1: Anders And (Male, 15 years)", listGeneric.ToString());
        }
    }
}