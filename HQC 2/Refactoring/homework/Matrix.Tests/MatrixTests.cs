namespace Matrix.Tests
{
    using System;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void FillMatrix_WhenNullIsPassed_ShouldThrowArgumentException()
        {
            // arrange
            var manager = new MatrixManager();

            // act & assert
            Assert.Throws<ArgumentException>(() => manager.FillMatrix(null));
        }

        [Test]
        public void FillMatrix_WhenMatrixWithDiffrentDimensionSizesIsPassed_ShouldThrowArgumentException()
        {
            // arrange
            var manager = new MatrixManager();
            var badMatrix = new int[3, 4];

            // act & assert
            Assert.Throws<ArgumentException>(() => manager.FillMatrix(badMatrix));
        }

        [Test]
        public void FillMatrix_WhenPassedMatrixIsCorrect_ShouldFillItCorrectly()
        {
            // arrange
            var manager = new MatrixManager();

            var matrix = new int[6, 6];
            var filledMatrix = new int[6, 6]
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            // act
            manager.FillMatrix(matrix);

            // assert
            bool areSame = CompareMatrixes(matrix, filledMatrix);
            Assert.IsTrue(areSame);
        }

        [Test]
        public void FillMatrix_WhenAnotherMatrixIsGettingFilled_ShouldReinitializePropertiesCorrectly()
        {
            // arrange
            var manager = new MatrixManager();

            int size = 6;
            var matrix = new int[size, size];
            var anotherMatrix = new int[size, size];

            // act
            manager.FillMatrix(matrix);
            manager.FillMatrix(anotherMatrix);

            // assert
            bool areSame = CompareMatrixes(matrix, anotherMatrix);
            Assert.IsTrue(areSame);
        }

        [Test]
        public void PrintMatrix_WhenNullMatrixIsPassed_ShouldThrowArgumentException()
        {
            // arrange
            var manager = new MatrixManager();
            var mockedPrinter = new Mock<IPrinter>();

            // act & assert
            Assert.Throws<ArgumentException>(() => manager.PrintMatrix(null, mockedPrinter.Object));
        }

        [Test]
        public void PrintMatrix_WhenMatrixWithDiffrentDimensionSizesIsPassed_ShouldThrowArgumentException()
        {
            // arrange
            var manager = new MatrixManager();

            var badMatrix = new int[3, 4];
            var mockedPrinter = new Mock<IPrinter>();

            // act & assert
            Assert.Throws<ArgumentException>(() => manager.PrintMatrix(badMatrix, mockedPrinter.Object));
        }

        [Test]
        public void PrintMatrix_WhenNullPrinterIsPassed_ShouldThrowArgumentException()
        {
            // arrange
            var manager = new MatrixManager();
            var matrix = new int[3, 3];

            // act & assert
            Assert.Throws<ArgumentException>(() => manager.PrintMatrix(matrix, null));
        }

        [Test]
        public void PrintMatrix_WhenPassedMatrixAndPrinterAreCorrect_ShouldCallPrinterCorrectly()
        {
            // arrange
            var manager = new MatrixManager();

            int size = 6;
            var matrix = new int[size, size];
            var filledMatrix = new int[6, 6]
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            var mockedPrinter = new Mock<IPrinter>();
            mockedPrinter.Setup(x => x.Write(It.IsAny<string>(), It.IsAny<int>()));
            mockedPrinter.Setup(x => x.WriteLine());

            // act
            manager.PrintMatrix(filledMatrix, mockedPrinter.Object);

            // assert
            mockedPrinter.Verify(x => x.Write(It.IsAny<string>(), It.IsAny<int>()), Times.Exactly(size * size));
            mockedPrinter.Verify(x => x.WriteLine(), Times.Exactly(size));
        }

        private static bool CompareMatrixes(int[,] matrix, int[,] anotherMatrix)
        {
            bool areSame = true;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != anotherMatrix[row, col])
                    {
                        areSame = false;
                        break;
                    }
                }

                if (!areSame)
                {
                    break;
                }
            }

            return areSame;
        }
    }
}
