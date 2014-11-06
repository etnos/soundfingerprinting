﻿namespace SoundFingerprinting.Tests.Unit.LCS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SoundFingerprinting.Data;
    using SoundFingerprinting.LCS;

    [TestClass]
    public class AudioSequencesAnalyzerTest : AbstractTest
    {
        private readonly IAudioSequencesAnalyzer audioSequencesAnalyzer = new AudioSequencesAnalyzer();

        [TestMethod]
        public void TestStriclyIncreasingSequenceIsAnalyzedCorrectly()
        {
            var sequence = GetSequence(1, 2, 3, 4, 5, 6);

            var subSequence = audioSequencesAnalyzer.GetLongestIncreasingSubSequence(sequence);

            Assert.AreEqual(sequence.Count, subSequence.Count());
        }

        [TestMethod]
        public void TestNotStriclyIncreasingSequenceIsAnalyzedCorrectly()
        {
            int[] expected = new[] { 1, 3, 4, 5 };
            int[] order = new[] { 1, 3, 0, 7, 8, 4, 5 };
            var sequence = GetSequence(order);

            var subSequence = audioSequencesAnalyzer.GetLongestIncreasingSubSequence(sequence).ToList();

            Assert.AreEqual(sequence.Count, 4);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], subSequence[i].SequenceNumber);
            }
        }

        [TestMethod]
        public void TestNotStriclyDecreasingSequenceIsAnalyzedCorrectly()
        {
            int[] expected = new[] { 1, 2 };
            var sequence = GetSequence(5, 4, 3, 2, 1);

            var subSequence = audioSequencesAnalyzer.GetLongestIncreasingSubSequence(sequence).ToList();

            Assert.AreEqual(1, subSequence.Count);
        }

        private static List<SubFingerprintData> GetSequence(params int[] orderNumbers)
        {
            var subfingerprints = orderNumbers.Select(t => new SubFingerprintData(null, t, null, null)).ToList();
            return subfingerprints;
        }
    }
}
