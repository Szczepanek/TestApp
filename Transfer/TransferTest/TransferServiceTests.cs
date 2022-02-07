using Logic.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace TransferTest
{
    public class TransferServiceTests
    {
        private ITransferService transferService;

        [SetUp]
        public void Setup()
        {
            var Logger = new Mock<ILogger<TransferService>>();
            transferService = new TransferService(Logger.Object);
        }

        [Test]
        public void TransferService_CheckCorrectnes_Correct()
        {
            //Arrange
            int[] generatedNumbers = new int[20] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19 };
            //Act
            var transferedNumbers = transferService.Transfer(generatedNumbers);
            //Asset
            for(int i = 0; i < generatedNumbers.Length; i++)
                Assert.AreEqual(generatedNumbers[i], transferedNumbers[i]);
        }

        [Test]
        public void TransferService_PassNullAsGeneretedNumbers_ReturnArray()
        {
            //Arrange
            int[] generatedNumbers = null;
            //Act
            var transferedNumbers = transferService.Transfer(generatedNumbers);
            //Asset
            Assert.AreEqual(1, transferedNumbers.Length);
        }
    }
}