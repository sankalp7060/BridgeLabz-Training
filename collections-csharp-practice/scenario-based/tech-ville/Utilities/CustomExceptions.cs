using System;

namespace TechVilleSmartCity.Utilities
{
    /// <summary>
    /// Custom exceptions for TechVille business rules
    /// Module 5: Custom exception creation
    /// Module 19: Comprehensive exception hierarchy
    /// </summary>
    #region Age-related Exceptions
    [Serializable]
    public class UnderageException : Exception
    {
        public UnderageException()
            : base("Citizen is underage for this service") { }

        public UnderageException(string message)
            : base(message) { }

        public UnderageException(string message, Exception inner)
            : base(message, inner) { }
    }

    [Serializable]
    public class OverageException : Exception
    {
        public OverageException()
            : base("Citizen exceeds maximum age limit") { }

        public OverageException(string message)
            : base(message) { }

        public OverageException(string message, Exception inner)
            : base(message, inner) { }
    }
    #endregion

    #region Registration-related Exceptions
    [Serializable]
    public class DuplicateCitizenException : Exception
    {
        public DuplicateCitizenException()
            : base("Citizen already exists in the system") { }

        public DuplicateCitizenException(string message)
            : base(message) { }

        public DuplicateCitizenException(string message, Exception inner)
            : base(message, inner) { }
    }

    [Serializable]
    public class InvalidCitizenIDException : Exception
    {
        public InvalidCitizenIDException()
            : base("Invalid citizen ID format") { }

        public InvalidCitizenIDException(string message)
            : base(message) { }

        public InvalidCitizenIDException(string message, Exception inner)
            : base(message, inner) { }
    }
    #endregion

    #region Service-related Exceptions
    [Serializable]
    public class ServiceNotAvailableException : Exception
    {
        public ServiceNotAvailableException()
            : base("Service is not available") { }

        public ServiceNotAvailableException(string message)
            : base(message) { }

        public ServiceNotAvailableException(string message, Exception inner)
            : base(message, inner) { }
    }

    [Serializable]
    public class ServiceQuotaExceededException : Exception
    {
        public ServiceQuotaExceededException()
            : base("Service quota has been exceeded") { }

        public ServiceQuotaExceededException(string message)
            : base(message) { }

        public ServiceQuotaExceededException(string message, Exception inner)
            : base(message, inner) { }
    }
    #endregion

    #region Zone-related Exceptions
    [Serializable]
    public class ServiceUnavailableInZoneException : Exception
    {
        public ServiceUnavailableInZoneException()
            : base("Service is not available in this zone") { }

        public ServiceUnavailableInZoneException(string message)
            : base(message) { }

        public ServiceUnavailableInZoneException(string message, Exception inner)
            : base(message, inner) { }
    }

    [Serializable]
    public class InvalidZoneException : Exception
    {
        public InvalidZoneException()
            : base("Invalid zone specified") { }

        public InvalidZoneException(string message)
            : base(message) { }

        public InvalidZoneException(string message, Exception inner)
            : base(message, inner) { }
    }
    #endregion

    #region Payment-related Exceptions
    [Serializable]
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException()
            : base("Insufficient balance for this transaction") { }

        public InsufficientBalanceException(string message)
            : base(message) { }

        public InsufficientBalanceException(string message, Exception inner)
            : base(message, inner) { }
    }

    [Serializable]
    public class TransactionFailedException : Exception
    {
        public TransactionFailedException()
            : base("Transaction failed") { }

        public TransactionFailedException(string message)
            : base(message) { }

        public TransactionFailedException(string message, Exception inner)
            : base(message, inner) { }
    }
    #endregion

    #region Data-related Exceptions
    [Serializable]
    public class DataCorruptionException : Exception
    {
        public DataCorruptionException()
            : base("Data is corrupted or in invalid format") { }

        public DataCorruptionException(string message)
            : base(message) { }

        public DataCorruptionException(string message, Exception inner)
            : base(message, inner) { }
    }

    [Serializable]
    public class InvalidDataFormatException : Exception
    {
        public InvalidDataFormatException()
            : base("Data format is invalid") { }

        public InvalidDataFormatException(string message)
            : base(message) { }

        public InvalidDataFormatException(string message, Exception inner)
            : base(message, inner) { }
    }
    #endregion
}
