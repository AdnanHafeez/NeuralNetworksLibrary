using System.Collections.Generic;
using System.Linq;
using NeuralNetworks.Library.Data;

namespace NeuralNetworks.Tests.IntegrationTests.DatasetCaseStudies.IrisDatasetCaseStudy
{
    public static class IrisDataSet
    {
        private static IrisDataRow[] RowsToBeUsedForTraining => 
            AllRows
                .GroupBy(row => row.Species)
                .SelectMany(group => group.Take(group.Count() / 2))
                .ToArray(); 

        public static List<IrisDataRow> RowsToBeUsedForPredictions => 
            AllRows
                .Intersect(RowsToBeUsedForTraining)
                .Select(IrisDataRowNormaliser.NormaliseDataRow)
                .ToList(); 

        public static TrainingDataSet[] TrainingData => 
            RowsToBeUsedForTraining
                .Select(IrisDataRowNormaliser.NormaliseDataRow)
                .Select(IrisDataRow.TrainingDataFromRow)
                .ToArray();

        public static IrisDataRow[] AllRows => new[] 
        {
            IrisDataRow.For(1, 5.1,3.5,1.4,0.2,1),
            IrisDataRow.For(2, 4.9,3,1.4,0.2,1),
            IrisDataRow.For(3, 4.7,3.2,1.3,0.2,1),
            IrisDataRow.For(4, 4.6,3.1,1.5,0.2,1),
            IrisDataRow.For(5, 5,3.6,1.4,0.2,1),
            IrisDataRow.For(6, 5.4,3.9,1.7,0.4,1),
            IrisDataRow.For(7, 4.6,3.4,1.4,0.3,1),
            IrisDataRow.For(8, 5,3.4,1.5,0.2,1),
            IrisDataRow.For(9, 4.4,2.9,1.4,0.2,1),
            IrisDataRow.For(10, 4.9,3.1,1.5,0.1,1),
            IrisDataRow.For(11, 5.4,3.7,1.5,0.2,1),
            IrisDataRow.For(12, 4.8,3.4,1.6,0.2,1),
            IrisDataRow.For(13, 4.8,3,1.4,0.1,1),
            IrisDataRow.For(14, 4.3,3,1.1,0.1,1),
            IrisDataRow.For(15, 5.8,4,1.2,0.2,1),
            IrisDataRow.For(16, 5.7,4.4,1.5,0.4,1),
            IrisDataRow.For(17, 5.4,3.9,1.3,0.4,1),
            IrisDataRow.For(18, 5.1,3.5,1.4,0.3,1),
            IrisDataRow.For(19, 5.7,3.8,1.7,0.3,1),
            IrisDataRow.For(20, 5.1,3.8,1.5,0.3,1),
            IrisDataRow.For(21, 5.4,3.4,1.7,0.2,1),
            IrisDataRow.For(22, 5.1,3.7,1.5,0.4,1),
            IrisDataRow.For(23, 4.6,3.6,1,0.2,1),
            IrisDataRow.For(24, 5.1,3.3,1.7,0.5,1),
            IrisDataRow.For(25, 4.8,3.4,1.9,0.2,1),
            IrisDataRow.For(26, 5,3,1.6,0.2,1),
            IrisDataRow.For(27, 5,3.4,1.6,0.4,1),
            IrisDataRow.For(28, 5.2,3.5,1.5,0.2,1),
            IrisDataRow.For(29, 5.2,3.4,1.4,0.2,1),
            IrisDataRow.For(30, 4.7,3.2,1.6,0.2,1),
            IrisDataRow.For(31, 4.8,3.1,1.6,0.2,1),
            IrisDataRow.For(32, 5.4,3.4,1.5,0.4,1),
            IrisDataRow.For(33, 5.2,4.1,1.5,0.1,1),
            IrisDataRow.For(34, 5.5,4.2,1.4,0.2,1),
            IrisDataRow.For(35, 4.9,3.1,1.5,0.1,1),
            IrisDataRow.For(36, 5,3.2,1.2,0.2,1),
            IrisDataRow.For(37, 5.5,3.5,1.3,0.2,1),
            IrisDataRow.For(38, 4.9,3.1,1.5,0.1,1),
            IrisDataRow.For(39, 4.4,3,1.3,0.2,1),
            IrisDataRow.For(40, 5.1,3.4,1.5,0.2,1),
            IrisDataRow.For(41, 5,3.5,1.3,0.3,1),
            IrisDataRow.For(42, 4.5,2.3,1.3,0.3,1),
            IrisDataRow.For(43, 4.4,3.2,1.3,0.2,1),
            IrisDataRow.For(44, 5,3.5,1.6,0.6,1),
            IrisDataRow.For(45, 5.1,3.8,1.9,0.4,1),
            IrisDataRow.For(46, 4.8,3,1.4,0.3,1),
            IrisDataRow.For(47, 5.1,3.8,1.6,0.2,1),
            IrisDataRow.For(48, 4.6,3.2,1.4,0.2,1),
            IrisDataRow.For(49, 5.3,3.7,1.5,0.2,1),
            IrisDataRow.For(50, 5,3.3,1.4,0.2,1),
            IrisDataRow.For(51, 7,3.2,4.7,1.4,2),
            IrisDataRow.For(52, 6.4,3.2,4.5,1.5,2),
            IrisDataRow.For(53, 6.9,3.1,4.9,1.5,2),
            IrisDataRow.For(54, 5.5,2.3,4,1.3,2),
            IrisDataRow.For(55, 6.5,2.8,4.6,1.5,2),
            IrisDataRow.For(56, 5.7,2.8,4.5,1.3,2),
            IrisDataRow.For(57, 6.3,3.3,4.7,1.6,2),
            IrisDataRow.For(58, 4.9,2.4,3.3,1,2),
            IrisDataRow.For(59, 6.6,2.9,4.6,1.3,2),
            IrisDataRow.For(60, 5.2,2.7,3.9,1.4,2),
            IrisDataRow.For(61, 5,2,3.5,1,2),
            IrisDataRow.For(62, 5.9,3,4.2,1.5,2),
            IrisDataRow.For(63, 6,2.2,4,1,2),
            IrisDataRow.For(64, 6.1,2.9,4.7,1.4,2),
            IrisDataRow.For(65, 5.6,2.9,3.6,1.3,2),
            IrisDataRow.For(66, 6.7,3.1,4.4,1.4,2),
            IrisDataRow.For(67, 5.6,3,4.5,1.5,2),
            IrisDataRow.For(68, 5.8,2.7,4.1,1,2),
            IrisDataRow.For(69, 6.2,2.2,4.5,1.5,2),
            IrisDataRow.For(70, 5.6,2.5,3.9,1.1,2),
            IrisDataRow.For(71, 5.9,3.2,4.8,1.8,2),
            IrisDataRow.For(72, 6.1,2.8,4,1.3,2),
            IrisDataRow.For(73, 6.3,2.5,4.9,1.5,2),
            IrisDataRow.For(74, 6.1,2.8,4.7,1.2,2),
            IrisDataRow.For(75, 6.4,2.9,4.3,1.3,2),
            IrisDataRow.For(76, 6.6,3,4.4,1.4,2),
            IrisDataRow.For(77, 6.8,2.8,4.8,1.4,2),
            IrisDataRow.For(78, 6.7,3,5,1.7,2),
            IrisDataRow.For(79, 6,2.9,4.5,1.5,2),
            IrisDataRow.For(80, 5.7,2.6,3.5,1,2),
            IrisDataRow.For(81, 5.5,2.4,3.8,1.1,2),
            IrisDataRow.For(82, 5.5,2.4,3.7,1,2),
            IrisDataRow.For(83, 5.8,2.7,3.9,1.2,2),
            IrisDataRow.For(84, 6,2.7,5.1,1.6,2),
            IrisDataRow.For(85, 5.4,3,4.5,1.5,2),
            IrisDataRow.For(86, 6,3.4,4.5,1.6,2),
            IrisDataRow.For(87, 6.7,3.1,4.7,1.5,2),
            IrisDataRow.For(88, 6.3,2.3,4.4,1.3,2),
            IrisDataRow.For(89, 5.6,3,4.1,1.3,2),
            IrisDataRow.For(90, 5.5,2.5,4,1.3,2),
            IrisDataRow.For(91, 5.5,2.6,4.4,1.2,2),
            IrisDataRow.For(92, 6.1,3,4.6,1.4,2),
            IrisDataRow.For(93, 5.8,2.6,4,1.2,2),
            IrisDataRow.For(94, 5,2.3,3.3,1,2),
            IrisDataRow.For(95, 5.6,2.7,4.2,1.3,2),
            IrisDataRow.For(96, 5.7,3,4.2,1.2,2),
            IrisDataRow.For(97, 5.7,2.9,4.2,1.3,2),
            IrisDataRow.For(98, 6.2,2.9,4.3,1.3,2),
            IrisDataRow.For(99, 5.1,2.5,3,1.1,2),
            IrisDataRow.For(100, 5.7,2.8,4.1,1.3,2),
            IrisDataRow.For(101, 6.3,3.3,6,2.5,3),
            IrisDataRow.For(102, 5.8,2.7,5.1,1.9,3),
            IrisDataRow.For(103, 7.1,3,5.9,2.1,3),
            IrisDataRow.For(104, 6.3,2.9,5.6,1.8,3),
            IrisDataRow.For(105, 6.5,3,5.8,2.2,3),
            IrisDataRow.For(106, 7.6,3,6.6,2.1,3),
            IrisDataRow.For(107, 4.9,2.5,4.5,1.7,3),
            IrisDataRow.For(108, 7.3,2.9,6.3,1.8,3),
            IrisDataRow.For(109, 6.7,2.5,5.8,1.8,3),
            IrisDataRow.For(110, 7.2,3.6,6.1,2.5,3),
            IrisDataRow.For(111, 6.5,3.2,5.1,2,3),
            IrisDataRow.For(112, 6.4,2.7,5.3,1.9,3),
            IrisDataRow.For(113, 6.8,3,5.5,2.1,3),
            IrisDataRow.For(114, 5.7,2.5,5,2,3),
            IrisDataRow.For(115, 5.8,2.8,5.1,2.4,3),
            IrisDataRow.For(116, 6.4,3.2,5.3,2.3,3),
            IrisDataRow.For(117, 6.5,3,5.5,1.8,3),
            IrisDataRow.For(118, 7.7,3.8,6.7,2.2,3),
            IrisDataRow.For(119, 7.7,2.6,6.9,2.3,3),
            IrisDataRow.For(120, 6,2.2,5,1.5,3),
            IrisDataRow.For(121, 6.9,3.2,5.7,2.3,3),
            IrisDataRow.For(122, 5.6,2.8,4.9,2,3),
            IrisDataRow.For(123, 7.7,2.8,6.7,2,3),
            IrisDataRow.For(124, 6.3,2.7,4.9,1.8,3),
            IrisDataRow.For(125, 6.7,3.3,5.7,2.1,3),
            IrisDataRow.For(126, 7.2,3.2,6,1.8,3),
            IrisDataRow.For(127, 6.2,2.8,4.8,1.8,3),
            IrisDataRow.For(128, 6.1,3,4.9,1.8,3),
            IrisDataRow.For(129, 6.4,2.8,5.6,2.1,3),
            IrisDataRow.For(130, 7.2,3,5.8,1.6,3),
            IrisDataRow.For(131, 7.4,2.8,6.1,1.9,3),
            IrisDataRow.For(132, 7.9,3.8,6.4,2,3),
            IrisDataRow.For(133, 6.4,2.8,5.6,2.2,3),
            IrisDataRow.For(134, 6.3,2.8,5.1,1.5,3),
            IrisDataRow.For(135, 6.1,2.6,5.6,1.4,3),
            IrisDataRow.For(136, 7.7,3,6.1,2.3,3),
            IrisDataRow.For(137, 6.3,3.4,5.6,2.4,3),
            IrisDataRow.For(138, 6.4,3.1,5.5,1.8,3),
            IrisDataRow.For(139, 6,3,4.8,1.8,3),
            IrisDataRow.For(140, 6.9,3.1,5.4,2.1,3),
            IrisDataRow.For(141, 6.7,3.1,5.6,2.4,3),
            IrisDataRow.For(142, 6.9,3.1,5.1,2.3,3),
            IrisDataRow.For(143, 5.8,2.7,5.1,1.9,3),
            IrisDataRow.For(144, 6.8,3.2,5.9,2.3,3),
            IrisDataRow.For(145, 6.7,3.3,5.7,2.5,3),
            IrisDataRow.For(146, 6.7,3,5.2,2.3,3),
            IrisDataRow.For(147, 6.3,2.5,5,1.9,3),
            IrisDataRow.For(148, 6.5,3,5.2,2,3),
            IrisDataRow.For(149, 6.2,3.4,5.4,2.3,3),
            IrisDataRow.For(150, 5.9,3,5.1,1.8,3),
        };
    }
}