// <copyright file="TimeTests.cs" company="Majunga.co.uk">
// Copyright (c) Majunga.co.uk. All rights reserved.
// </copyright>

namespace MajungaLibraryTests.Helpers
{
    using MajungaLibrary.Helpers;
    using Xunit;

    /// <summary>
    /// Time Helper Tests
    /// </summary>
    public class TimeTests
    {
        [Fact]
        public void Validate_IsValidAndMoreThan20Hrs_ReturnsTrue()
        {
            Assert.True(Time.Validate("23:50:40"));
        }

        [Fact]
        public void Validate_IsValidAndIsInTensOfHrs_ReturnsTrue()
        {
            Assert.True(Time.Validate("12:50:40"));
        }

        [Fact]
        public void Validate_IsValidAndIsInUnitssOfHrs_ReturnsTrue()
        {
            Assert.True(Time.Validate("08:50:40"));
        }

        [Fact]
        public void Validate_IsMoreThan24Hrs_ReturnsFalse()
        {
            Assert.False(Time.Validate("33:50:40"));
        }

        [Fact]
        public void Validate_IsMoreThan59Minutes_ReturnsFalse()
        {
            Assert.False(Time.Validate("00:69:40"));
        }

        [Fact]
        public void Validate_IsMoreThan59Seconds_ReturnsFalse()
        {
            Assert.False(Time.Validate("00:00:69"));
        }
    }
}
