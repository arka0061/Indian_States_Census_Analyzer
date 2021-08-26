using Indian_State_Census_Analyzer;
using Indian_State_Census_Analyzer.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace CensusAnalyserTest
{  
    public class Tests
    {
        string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string indianStateCensusFilePath = @"E:\Bridglabz\Indian_States_Census_Analyzer\CensusAnalyserTest\CSVFiles\IndianStateCensusData.csv";
        string indianStateCodeFilePath = @"E:\Bridglabz\Indian_States_Census_Analyzer\CensusAnalyserTest\CSVFiles\IndianStateCode.csv";
        string wrongIndianStateCensusFilePath = @"E:\Bridglabz\Indian_States_Census_Analyzer\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        string wrongIndianStateCodeFilePath = @"E:\Bridglabz\Indian_States_Census_Analyzer\CensusAnalyserTest\CSVFiles\IndiaCode.csv";
        string wrongIndianStateCensusFiletype = @"E:\Bridglabz\Indian_States_Census_Analyzer\CensusAnalyserTest\CSVFiles\IndianStateCensusData.txt";
        string wrongIndianStateCodeFiletype = @"E:\Bridglabz\Indian_States_Census_Analyzer\CensusAnalyserTest\CSVFiles\IndianStateCode.txt";
        string wrongIndianStateCensusFileDelimiter = @"E:\Bridglabz\Indian_States_Census_Analyzer\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongIndianStateCodeFileDelimeter = @"E:\Bridglabz\Indian_States_Census_Analyzer\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongIndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm,Rank";
        string wrongIndianStateCodeHeaders = "SrNo,State Name,TIN,StateCode,Popularity";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        /// <summary>
        /// TC-1.1
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        /// <summary>
        /// TC-1.2
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.type);
        }
        /// <summary>
        /// TC-1.3
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFiletype, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFiletype, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.type);
        }
        /// <summary>
        /// TC-1.4
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileDelimeter_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileDelimiter, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.type);
        }
        /// <summary>
        /// TC-1.5
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileNotProperHeader_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileDelimiter, wrongIndianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, wrongIndianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.type);
        }
        /// <summary>
        /// TC 2.1
        /// </summary>
        [Test]
        public void GivenStateCodeDataFile_WhenRead_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA,indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        /// <summary>
        /// TC 2.2 
        /// </summary>
        [Test]
        public void GivenWrongStateCodeDataFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.type);
        }
        /// <summary>
        /// TC 2.3 
        /// </summary>
        [Test]
        public void GivenWrongStateCodeDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFiletype, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.type);
        }
        /// <summary>
        /// TC 2.4
        /// </summary>
        [Test]
        public void GivenWrongStateCodeDataFileNotProperDelimeter_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.type);
        }
        /// <summary>
        /// TC 2.5 
        /// </summary>
        [Test]
        public void GivenWrongStateCodeDataFileNotProperHeaders_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, wrongIndianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.type);
        }
    }
}
    
