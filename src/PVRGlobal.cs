using System;
using System.IO;

namespace CSharp_PVR
{
	/// <summary>
	/// Pvr Version
	/// </summary>
	public enum PvrVersion
	{
		/// <summary>
		/// Unknown version
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Version 1
		/// </summary>
		Version1 = 1,

		/// <summary>
		/// Version 2
		/// </summary>
		Version2 = 2,

		/// <summary>
		/// Version 3
		/// </summary>
		Version3 = 3,
	}

	/// <summary>
	/// Static global tools
	/// </summary>
	public static class PVRGlobal
	{
		/// <summary>
		/// Detect version from input stream. Seeks back to start position after check
		/// </summary>
		/// <param name="inputStream">input stream</param>
		/// <returns>PvrVersion</returns>
		public static PvrVersion DetectVersion(Stream inputStream)
		{
			if (IsV3Format(inputStream, returnToOriginalPosition: true))
			{
				return PvrVersion.Version3;
			}
			else if (IsV2Format(inputStream, returnToOriginalPosition: true))
			{
				return PvrVersion.Version2;
			}

			return PvrVersion.Unknown;
		}

		/// <summary>
		/// Check if input stream contains PVR V3 format input 
		/// </summary>
		/// <param name="inputStream">Input stream</param>
		/// <param name="returnToOriginalPosition">Should stream seek back to original position after check</param>
		/// <returns>True if is; False otherwise</returns>
		public static bool IsV3Format(Stream inputStream, bool returnToOriginalPosition = true)
		{
			if (returnToOriginalPosition && !inputStream.CanSeek)
			{
				throw new ArgumentException("Cannot return to original position since inputStream does not support seeking!");
			}

			long originalPosition = inputStream.Position;

			bool returnValue = true;

			try
			{
				PVRContainerV3 containerV3 = new PVRContainerV3(inputStream);
			}
			catch
			{
				returnValue = false;
			}

			if (returnToOriginalPosition)
			{
				inputStream.Position = originalPosition;
			}

			return returnValue;
		}

		/// <summary>
		/// Check if input stream contains PVR V2 format input 
		/// </summary>
		/// <param name="inputStream">Input stream</param>
		/// <param name="returnToOriginalPosition">Should stream seek back to original position after check</param>
		/// <returns>True if is; False otherwise</returns>
		public static bool IsV2Format(Stream inputStream, bool returnToOriginalPosition = true)
		{
			if (returnToOriginalPosition && !inputStream.CanSeek)
			{
				throw new ArgumentException("Cannot return to original position since inputStream does not support seeking!");
			}

			long originalPosition = inputStream.Position;

			bool returnValue = true;

			try
			{
				PVRContainerV2 containerV2 = new PVRContainerV2(inputStream);
			}
			catch
			{
				returnValue = false;
			}

			if (returnToOriginalPosition)
			{
				inputStream.Position = originalPosition;
			}

			return returnValue;
		}
	}
}