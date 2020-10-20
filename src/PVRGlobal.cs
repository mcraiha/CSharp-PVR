using System;
using System.IO;

namespace CSharp_PVR
{
	public enum PvrVersion
	{
		Unknown = 0,
		Version1 = 1,
		Version2 = 2,
		Version3 = 3,
	}

	public static class PVRGlobal
	{
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