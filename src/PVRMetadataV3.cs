using System;

namespace CSharp_PVR
{
	sealed public class PVRMetadataV3
	{
		private readonly PVRMetadataElementV3[] elements;
		public PVRMetadataV3(byte[] inputBytes, int startPos, int length)
		{
			if (inputBytes == null)
			{
				throw new NullReferenceException("inputBytes is null");
			}

			if (startPos < 0)
			{
				throw new ArgumentException($"Start position cannot be negative!");
			}
			else if (startPos > inputBytes.Length)
			{
				throw new ArgumentException($"Start position cannot be larger than input!");
			}

			if (length < 0)
			{
				throw new ArgumentException($"Length cannot be negative!");
			}
			else if (length + startPos > inputBytes.Length)
			{
				throw new ArgumentException($"Start position + Length would index over the input bytes!");
			}
		}
	}
}