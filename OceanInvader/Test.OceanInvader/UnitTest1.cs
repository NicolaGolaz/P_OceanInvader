using OceanInvader;

namespace Test.OceanInvader
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            int targetlife = 10;


            // Act
            Player player = new Player(400, 500);



            // Assert
            Assert.AreEqual(targetlife, player.PlayerHp);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            Player player = new Player(400, 500);
           

            // Act
            player.TakeDamage(1);
            
            
            // Assert
            Assert.AreEqual(9, player.PlayerHp);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            Player player = new Player(400, 500);
            player.TakeDamage(1);


            // Act           
            player.Heal(1);


            // Assert
            Assert.AreEqual(10, player.PlayerHp);
        }
    }
}