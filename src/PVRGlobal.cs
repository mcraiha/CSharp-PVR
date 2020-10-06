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
			if (IsV3FormatFile(inputStream, returnToOriginalPosition: true))
			{
				return PvrVersion.Version3;
			}

			return PvrVersion.Unknown;
		}

		public static bool IsV3FormatFile(Stream inputStream, bool returnToOriginalPosition = true)
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
	}
}