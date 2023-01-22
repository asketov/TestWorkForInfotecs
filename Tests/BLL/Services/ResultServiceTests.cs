using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using Tests.BLL.Common;

namespace Tests.BLL.Services
{
    public class ResultServiceTests
    {
        [Fact]
        public void GetMedianaFromValues()
        {
            // Arrange
            var valueModelsFiveCount = ValueModelFactory.GetValueModels().GetRange(0, 5).OrderBy(x => x.Index).ToList();
            var valueModelsFourCount = ValueModelFactory.GetValueModels().GetRange(0, 4).OrderBy(x=>x.Index).ToList();
            // Act
            var medianaFiveCount = ResultService.GetMedianaValues(valueModelsFiveCount);
            var medianaFourCount = ResultService.GetMedianaValues(valueModelsFourCount);

            // Assert
            Assert.Equal(medianaFiveCount, valueModelsFiveCount[3].Index);
            Assert.Equal(medianaFourCount, (valueModelsFourCount[2].Index + valueModelsFourCount[3].Index) / 2);
        }


        [Fact]
        public void GetMinimumIndexFromValues()
        {
            // Arrange
            var valueModels = ValueModelFactory.GetValueModels().GetRange(0, 3);
            var result = valueModels.OrderBy(x=>x.Index).ToList();
            // Act
            var minimumIndex = ResultService.GetMinimumIndexValues(valueModels);
            // Assert
            Assert.Equal(result[0].Index, minimumIndex);
        }

        [Fact]
        public void GetMaximumIndexFromValues()
        {
            // Arrange
            var valueModels = ValueModelFactory.GetValueModels().GetRange(0, 3);
            var result = valueModels.OrderByDescending(x => x.Index).ToList();
            // Act
            var maximumIndex = ResultService.GetMaximumIndexValues(valueModels);
            // Assert
            Assert.Equal(result[0].Index, maximumIndex);
        }

        [Fact]
        public void GetLastOperationFromValues()
        {
            // Arrange
            var valueModels = ValueModelFactory.GetValueModels().GetRange(0, 3);
            var result = valueModels.OrderByDescending(x => x.Date).ToList();
            // Act
            var lastOperation = ResultService.GetLastOperationValues(valueModels);
            // Assert
            Assert.Equal(result[0].Date, lastOperation);
        }

        [Fact]
        public void GetFirstOperationFromValues()
        {
            // Arrange
            var valueModels = ValueModelFactory.GetValueModels().GetRange(0, 3);
            var result = valueModels.OrderBy(x => x.Date).ToList();
            // Act
            var firstOperation = ResultService.GetFirstOperationValues(valueModels);
            // Assert
            Assert.Equal(result[0].Date, firstOperation);
        }
    }
}
