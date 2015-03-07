﻿namespace SoundFingerprinting.DAO.Data
{
    using System;

    [Serializable]
    public class HashData //TODO divide this class into 2 one for DAO other one for algorithm (similar to SpectralImage and Fingerprint classes)
    {
        public HashData()
        {
            // no op
        }

        public HashData(byte[] subFingerprint, long[] hashBins)
        {
            SubFingerprint = subFingerprint;
            HashBins = hashBins;
        }

        public HashData(byte[] subFingerprint, long[] hashBins, int sequenceNumber, double sequenceAt)
            : this(subFingerprint, hashBins)
        {
            SequenceNumber = sequenceNumber;
            SequenceAt = sequenceAt;
        }

        public byte[] SubFingerprint { get; set; }

        public long[] HashBins { get; set; }

        public int SequenceNumber { get; set; }

        public double SequenceAt { get; set; }
    }
}
